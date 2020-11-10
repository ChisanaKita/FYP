using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using VRF.Driver;

namespace VRF
{
    public abstract class Catchable : MonoBehaviour
    {
        protected Timer CatchTimer;

        public abstract FishType Type { get; }

        protected virtual void StartCounting(int Interval)
        {
            if (CatchTimer.Enabled)
            {
                return;
            }
            else
            {
                Debug.Log("Fish Catch-Timer Started Counting.");
                CatchTimer.Interval = (int)Type * Interval;
                CatchTimer.Start();
            }

        }

        protected virtual void StopCounting()
        {
            CatchTimer.Stop();
        }

        protected void OnTimesUp(object obj, ElapsedEventArgs eventArgs)
        {
            CatchTimer.Stop();
            Debug.Log("Catch-Timer Time-Up!");
            EntityDriver.Instance.OnFishBiting();
        }
    }
}
