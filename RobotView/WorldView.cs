//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: WorldView.cs 771 2011-10-28 08:39:33Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{

    /// <summary>
    /// Diese Klasse visualisiert einen Ausschnitt der Welt
    /// </summary>
    public partial class WorldView : UserControl
    {

        #region members
        private Bitmap plot;
        private Pen penGrid1;
        private Pen penGrid2;
        private Pen penAngle;
        private Pen penRadar;
        private SolidBrush brushRobot;

        private ViewPort viewPort;
        private Timer updateTimer;
        #endregion


        #region constructor & destructor
        public WorldView()
        {
            penGrid1 = new Pen(Color.Gray, 3);
            penGrid2 = new Pen(Color.Gray, 1);
            penAngle = new Pen(Color.Black, 7);
            penRadar = new Pen(Color.Green, 9);

            brushRobot = new SolidBrush(Color.Gray);

            viewPort = new ViewPort(-1, 4, -2, 2);

            InitializeComponent();
            updateTimer = new Timer();
            updateTimer.Interval = 100;
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Enabled = true;
        }


        #endregion


        #region properties
        /// <summary>
        /// Liefert die Farbe für den Roboter
        /// </summary>
        private SolidBrush BrushRobot
        {
            get
            {
                if (World.Robot != null)
                {
                    if (World.Robot.Color != brushRobot.Color)
                    {
                        brushRobot = new SolidBrush(World.Robot.Color);
                    }
                }
                return brushRobot;
            }
        }


        /// <summary>
        /// Liefert bzw. setzt den Ausschnitt, den die WorldView darstellen soll
        /// </summary>
        public ViewPort ViewPort
        {
            get { return viewPort; }
            set
            {
                viewPort = value;
                UpdateView();
            }
        }
        #endregion


        #region methods

        void updateTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            UpdateView();
        }

        /// <summary>
        /// Sorgt dafür, dass der Inhalt neu gezeichnet wird, falls die Grösse
        /// der WorldView verändert wird.
        /// </summary>
        /// 
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateView();
        }


        /// <summary>
        /// Berechnet aus einer x-Pos [m] im Weltkoordinatensystem 
        /// eine x-Pos [Pixel] im Koordinatensystem der WorldView
        /// </summary>
        /// <param name="x">die x-Position im Weltkoordinatensystem in Meter</param>
        /// <returns>die x-Position im WorldView-Koordinatensystem in Pixel</returns>
        private int XtoScreen(double x)
        {
            double _distanceFromTopInM = x - viewPort.xMin;
            double _posOnScreen = _distanceFromTopInM * getScaleFactor();
            return Convert.ToInt32(_posOnScreen);
        }


        /// <summary>
        /// Berechnet aus einer y-Pos [m] im Weltkoordinatensystem 
        /// eine y-Pos [Pixel] im Koordinatensystem der WorldView
        /// </summary>
        /// <param name="y">die y-Position im Weltkoordinatensystem in Meter</param>
        /// <returns>die y-Position im WorldView-Koordinatensystem in Pixel</returns>
        private int YtoScreen(double y)
        {
            double _distanceFromBorderInM = viewPort.yMax-y;
            double _posOnScreen = _distanceFromBorderInM * getScaleFactor();
            return Convert.ToInt32(_posOnScreen);
        }


        /// <summary>
        /// Berechnet aus einer Distanz [m] in x-Richtung die Anzahl
        /// Pixel im Koordinatensystem der WorldView.
        /// </summary>
        /// <param name="width">die Distanz/Strecke in Metern</param>
        /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
        private int WidthToScreen(float aDistanceInM)
        {
            double _width = (aDistanceInM * getScaleFactor());

            return Convert.ToInt32(_width);
        }

        private double getScaleFactor()
        {

            //get scale factors for height and width of the current form
            double heightScaleFactor = this.Height / (viewPort.yMax - viewPort.yMin);
            double widthScaleFactor = this.Width / (viewPort.xMax - viewPort.xMin);

            //return the lower scale factor
            if (heightScaleFactor <= widthScaleFactor)
            {
                return heightScaleFactor;
            }
            else
            {
                return widthScaleFactor;
            }
        }


        /// <summary>
        /// Berechnet aus einer Distanz [m] in y-Richtung die Anzahl
        /// Pixel im Koordinatensystem der WorldView.
        /// </summary>
        /// <param name="height">die Distanz/Strecke in Metern</param>
        /// <returns>die Anzahl Pixel, die dieser Distanz/Strecke entsprechen</returns>
        private int HeightToScreen(float aDistanceInM)
        {
            double _height = (aDistanceInM * getScaleFactor());
            return Convert.ToInt32(_height);
        }


        /// <summary>
        /// Aktualisiert die View, d.h. es wird in ein Bitmap gezeichnet und
        /// anschliessend das Bitmap in der PictureBox dargestellt.
        /// Folgende Objekte werden gezeichnet:
        /// - Hindernis
        /// - Koordinaten-Netz
        /// - Roboter
        /// - Radar
        /// </summary>
        private void UpdateView()
        {
            // Verhindert Exception falls Fenster auf 0 verkleinert wird.
            if (pictureBox.Width == 0 || pictureBox.Height == 0) return;

            // Verhindert Designer-Absturz falls ViewPort auf 0 gesetzt wird.
            if (viewPort.Width == 0 || viewPort.Height == 0) return;

            // Bitmap erstellen auf das die WorldView gezeichnet werden kann
            if ((plot == null) || (plot.Size != pictureBox.Size))
            {
                plot = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            using (Graphics g = Graphics.FromImage(plot))
            {
                // Hintergrund löschen
                g.Clear(Color.White);

                #region Hindernisse zeichnen
                ObstacleMap obstMap = World.ObstacleMap;
                if (World.ObstacleMap != null)
                {
                    Bitmap bmp = obstMap.Image;
                    RectangleF area = obstMap.Area;
                    int rx1 = XtoScreen(area.Left);
                    int ry1 = YtoScreen(area.Bottom);
                    int rx2 = XtoScreen(area.Right);
                    int ry2 = YtoScreen(area.Top);
                    g.DrawImage(
                    World.ObstacleMap.Image,
                    new Rectangle(rx1, ry1, rx2 - rx1, ry2 - ry1),
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    GraphicsUnit.Pixel);
                }
                #endregion

                #region Koordinaten-Netz zeichnen
                 //draw vertical grid lines
                for (double x = viewPort.xMin-(viewPort.xMin%0.5); x <= viewPort.xMax; x = x + 0.5)
                {
                    g.DrawLine((x == 0 ? penGrid1 : penGrid2),
                        Convert.ToInt32(XtoScreen(x)),
                        Convert.ToInt32(YtoScreen(viewPort.yMax)),
                        Convert.ToInt32(XtoScreen(x)),
                        Convert.ToInt32(YtoScreen(viewPort.yMin)));
                }

                //draw horizontal grid lines
                for (double y = viewPort.yMin - (viewPort.yMin % 0.5); y <= viewPort.yMax; y = y + 0.5)
                {
                    g.DrawLine((y == 0 ? penGrid1 : penGrid2),
                        Convert.ToInt32(XtoScreen(viewPort.xMin)),
                        Convert.ToInt32(YtoScreen(y)),
                        Convert.ToInt32(XtoScreen(viewPort.xMax)),
                        Convert.ToInt32(YtoScreen(y)));
                }
                #endregion



                Robot robot = World.Robot;
                if (robot != null)
                {
                    PositionInfo robotPosition = robot.Drive.Position;
                    
                    #region Parkplatz zeichnen
                    if (robot.Finished && !robot.Running)
                    {
                        //double _parkingX = robotPosition.X - Math.Abs(robotPosition.X % 0.5);
                        //double _parkingY = robotPosition.Y + Math.Abs(robotPosition.Y % 0.5);

                        double _parkingX = Convert.ToInt32(robotPosition.X / 0.5) * 0.5;
                        double _parkingY = Convert.ToInt32(robotPosition.Y / 0.5) * 0.5;

                        g.FillRectangle(new SolidBrush(Color.LightBlue), XtoScreen(_parkingX), YtoScreen(_parkingY), WidthToScreen(0.5f), HeightToScreen(0.5f));
                    }
                    #endregion
                    
                    #region Roboterstrecke zeichnen
                    PositionInfo[] _posInfo = new PositionInfo[robot.positions.Capacity];
                    robot.positions.CopyTo(_posInfo);
                    foreach(PositionInfo _info in _posInfo) {
                        g.FillEllipse(new SolidBrush(robot.Color), XtoScreen(_info.X) - 2, YtoScreen(_info.Y) - 2, 5, 5);
                    }
                    #endregion

                    #region Roboter zeichnen
                    g.FillEllipse(new SolidBrush(robot.Color), XtoScreen(robotPosition.X  - robot.Width), YtoScreen(robotPosition.Y + robot.Height), WidthToScreen(robot.Width*2), HeightToScreen(robot.Height*2));
                    #endregion

                    #region Radar zeichnen
                    // Roboter.Radar
                    float phi = robot.Drive.Position.Angle;
                    PositionInfo radarOffset = robot.Radar.AntennaPosition;
                    PositionInfo radarPos = new PositionInfo(
                    robotPosition.X + radarOffset.X * (float)Math.Cos(phi) - radarOffset.Y * (float)Math.Sin(phi),
                    robotPosition.Y + radarOffset.X * (float)Math.Sin(phi) + radarOffset.Y * (float)Math.Cos(phi),
                    (robotPosition.Angle + radarOffset.Angle) % 360);
                    double radarPhi = radarPos.Angle / 180.0 * Math.PI;
                    double distance = robot.Radar.Distance;
                    // Radarstrahl zeichnen...
                    g.DrawLine(penRadar, XtoScreen(radarPos.X), YtoScreen(radarPos.Y),
                    XtoScreen(radarPos.X + distance * Math.Cos(radarPhi)),
                    YtoScreen(radarPos.Y + distance * Math.Sin(radarPhi)));
                    #endregion
                }

            }

            pictureBox.Image = plot;
        }

        public void SaveImage(string aFilename)
        {
            plot.Save(aFilename, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        #endregion
    }
}
