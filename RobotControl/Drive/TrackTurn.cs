using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class TrackTurn : Track
    {
        public TrackTurn(float angle, float speed, float acceleration)
        {
            reverse = (Math.Sign(angle) ^ Math.Sign(speed)) != 0;
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
            this.angle = Math.Abs(angle);
            this.length = (float)Math.Abs(Constants.AxleLength / 2.0 * 2.0 * Math.PI * angle / 360.0);
        }

        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;
            if (reverse)
                newVelocity = -newVelocity;
            rightSpeed = newVelocity;
            leftSpeed = newVelocity;
            DoStep(timeInterval);
        }

        public float angle;
    }
}
