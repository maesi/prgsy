//------------------------------------------------------------------------------
// S Y S T E M N A H E S   P R O G R A M M I E R E N   (P R G S Y)
//------------------------------------------------------------------------------
// Repository:
//    $Id: Constants.cs 521 2011-02-18 14:36:57Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public enum RunMode { Virtual, Real };

    public static class Constants
    {

        public static bool IsWinCE { get { return Environment.OSVersion.Platform == PlatformID.WinCE; } }

        public static int GetBitmask(int bit)
        {
            return 1 << bit;
            /*Int32[] bitmask = new Int32[] {
                0x00000001,
                0x00000002,
                0x00000004,
                0x00000008
            };
            return bitmask[bit];*/
        }

        // Roboter-Kennzahlen
        public const float WheelDiameter = 0.076f;
        public const float AxleLength = 0.263f;
        public const float TicksPerRevolution = 28672f;
        public const float WheelCircumference = (float)(Math.PI * WheelDiameter);
        public const float MeterPerTick = WheelCircumference / TicksPerRevolution;

        // IO-Adressen
        public const int IOConsoleLED = 0xF303;
        public const int IOConsoleSWITCH = 0xF303;
        public const int IORadarSensor = 0xF310;
        public const int IODriveCtrl = 0xF330;
        public const int IOMotorCtrlRight = 0xF320;
        public const int IOMotorCtrlLeft = 0xF328;

        

    }
}
