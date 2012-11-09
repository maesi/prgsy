using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    public abstract class DigitalIn : IDisposable
    {
        public event EventHandler DigitalInChanged;
        public virtual void Dispose()
        {

        }
        public abstract int Data
        {
            get;
            set;
        }
        protected void OnDigitalInChanged(EventArgs e)
        {
            if (DigitalInChanged != null)
            {
                DigitalInChanged(this, e);
            }
        }
        public virtual bool this[int bit]
        {
            get
            {
                return (Data & Constants.GetBitmask(bit)) == Constants.GetBitmask(bit);
            }
            set
            {
                if (value)
                {
                    Data |= Constants.GetBitmask(bit);
                }
                else
                {
                    Data &= ~Constants.GetBitmask(bit);
                }
                OnDigitalInChanged(EventArgs.Empty);
            }
        }
    }
}
