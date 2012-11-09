//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: DriveCtrlHW.cs 735 2011-10-13 09:16:14Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{

    public class DriveCtrlHW : DriveCtrl
    {

        #region members
        private int ioAddress;
        #endregion


        #region constructor & destructor
        public DriveCtrlHW(int aIoAddress)
        {
            ioAddress = aIoAddress;
            Reset();
        }
        #endregion


        #region properties
        
        #endregion


        #region methods
        public override void Dispose()
        {
            base.Dispose();
            Reset();
        }
        #endregion


        public override int DriveState
        {
            get
            {
                return IOPort.Read(ioAddress);
            }
            protected set
            {
                IOPort.Write(ioAddress, value);
            }
        }

        public override void Reset()
        {
            DriveState = 0x00;
            Thread.Sleep(5);
            DriveState = 0x80;
            Thread.Sleep(5);
            DriveState = 0x00;
            Thread.Sleep(5);
        }
    }
}
