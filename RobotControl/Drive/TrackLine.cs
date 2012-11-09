using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class TrackLine : Track
    {
        public TrackLine(float length, float speed, float acceleration)
        {
            reverse = (Math.Sign(length) ^ Math.Sign(speed)) != 0;
            this.length = Math.Abs(length);
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
        }

        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;
            if (reverse)
            {
                newVelocity = -newVelocity;
            }
            leftSpeed = -newVelocity;
            rightSpeed = +newVelocity;
            DoStep(timeInterval);
        }
    }
}
