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
                //initDrive();
                if (_switchEvent.SwitchEnabled)
                {
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
        private bool running = true;
        private bool finished = false;
        public bool Finished
        {
            get
            {
                return finished && !running;
            }
        }

        private void Run()
        {
            int _step = 0;

            float _speed = 0.5f;
            float _acc = 0.3f;

            while (running)
            {
                PositionInfo _pos = World.Robot.Drive.Position;
                if (positions.Capacity == 0 || !_pos.Equals(positions.Last()))
                {
                    positions.Add(_pos);
                }
                if (Drive.Done)
                {
                    if (!finished)
                    {
                        switch (++_step)
                        {
                            case 1:
                                Drive.RunTurn(-90f, _speed, _acc);
                                break;
                            case 2:
                                //Drive.RunLine(0.75f, _speed, _acc);
                                Drive.RunArcLeft(0.75f, 90f, _speed, _acc);
                                _step = 3;
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
                                    finished = true;
                                }
                                break;
                            case 6:
                                Drive.RunLine(0.5f, _speed, _acc);
                                break;
                            case 7:
                                Drive.RunTurn(-90f, _speed, _acc);
                                _step = 4;
                                break;
                        }
                    }
                    else
                    {
                        running = false;
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
            Drive.Halt();
            running = false;
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
