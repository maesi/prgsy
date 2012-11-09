using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public class TrackArcLeft : Track
    {
        public TrackArcLeft(float radius, float angle, float speed, float acceleration)
        {
            reverse = (Math.Sign(angle) ^ Math.Sign(speed)) != 0;
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
            this.angle = Math.Abs(angle);
            this.radius = Math.Abs(radius);
            this.length = (float)Math.Abs((radius + Constants.AxleLength / 2.0) * 2.0 * Math.PI * angle / 360.0);
        }

        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;
            if (reverse)
                newVelocity = -newVelocity;
            leftSpeed = (float)(-newVelocity * (radius - Constants.AxleLength / 2.0) / (radius + Constants.AxleLength / 2.0));
            rightSpeed = newVelocity;
            DoStep(timeInterval);
        }

        public float angle;
        public float radius;
    }
}
