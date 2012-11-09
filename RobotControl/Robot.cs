using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace RobotCtrl
{
    public class Robot : IDisposable
    {
        private RunMode RunMode { get; set; }
        public Color Color { get; set; }
        public Radar Radar { get; set; }
        public RobotConsole RobotConsole { get; set; }
        public Drive Drive { get; set; }

        public List<PositionInfo> positions;

        public float Width
        {
            get
            {
                return 0.14f;
            }
        }

        public float Height
        {
            get
            {
                return 0.14f;
            }
        }
        
        public Robot(RunMode aRunMode)
        {
            this.RunMode = aRunMode;

            RobotConsole = new RobotConsole(this.RunMode);
            RobotConsole.SwitchChanged += new EventHandler(RobotConsole_SwitchChanged);
            initDrive();
            Radar = new Radar(this.RunMode);
        }

        private void initDrive()
        {
            Drive = new Drive(this.RunMode);
            positions = new List<PositionInfo>(); 
        }

        void RobotConsole_SwitchChanged(object sender, EventArgs e)
        {
            SwitchEventArgs _switchEvent = (SwitchEventArgs)e;
            if (_switchEvent.Swi == Switches.Switch1)
            {
                if (_switchEvent.SwitchEnabled)
                {
                    if (Finished || Aborted)
                    {
                        Drive.Position = new PositionInfo(0, 0, 90f);
                        positions = new List<PositionInfo>(); 
                        Finished = false;
                        Aborted = false;
                        step = 1;
                    }

                    Running = true;
                    this.thread = new Thread(Run);
                    this.thread.IsBackground = true;
                    this.thread.Priority = ThreadPriority.Highest;
                    this.thread.Start();
                }
                else
                {
                    Stop();
                }
            }
        }


        #region Fahrbefehle

        private Thread thread;
        public bool Running {
            get
            {
                return running;
            }
            set {
                running = value;
                if (running)
                {
                    this.RobotConsole[Leds.Led1].LedEnabled = true;
                }
                else
                {
                    this.RobotConsole[Leds.Led1].LedEnabled = false;
                }
            }
        }
        private bool running;
        public bool Finished { get; set; }
        public bool Aborted { get; set; }

        int step = 1;
        private void Run()
        {

            float _speed = 0.5f;
            float _acc = 0.3f;
            while (Running)
            {
                PositionInfo _pos = World.Robot.Drive.Position;
                if (positions.Capacity == 0 || !_pos.Equals(positions.Last()))
                {
                    positions.Add(_pos);
                }
                if (Drive.Done || step == 99)
                {
                    if (!Finished && !Aborted)
                    {
                        switch (step++)
                        {
                            case 1:
                                Drive.RunTurn(-90f, _speed, _acc);
                                break;
                            case 2:
                                //Drive.RunLine(0.75f, _speed, _acc);
                                Drive.RunArcLeft(0.75f, 90f, _speed, _acc);
                                step = 4;
                                break;
                            case 3:
                                Drive.RunTurn(90f, _speed, _acc);
                                break;
                            case 4:
                                //Drive.RunLine(1.25f, _speed, _acc);
                                Drive.RunLine(0.5f, _speed, _acc);
                                break;
                            case 5:
                                if (Radar.Distance < 0.5f)
                                {
                                    Drive.RunTurn(90f, _speed, _acc);
                                }
                                else
                                {
                                    Drive.RunLine(0.5f, _speed, _acc);
                                    Finished = true;
                                }
                                break;
                            case 6:
                                Drive.RunLine(0.5f, _speed, _acc);
                                break;
                            case 7:
                                Drive.RunTurn(-90f, _speed, _acc);
                                step = 5;
                                break;
                            case 99:
                                Drive.Halt();
                                Aborted = true;
                                break;
                        }
                    }
                    else
                    {
                        Running = false;
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }

        private void Stop()
        {
            step = 99;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Drive.Dispose();
            RobotConsole.Dispose();
        }

        #endregion
    }
}
