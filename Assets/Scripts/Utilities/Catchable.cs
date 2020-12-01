using UnityEngine;
using System.Timers;

namespace VRF.Util
{
    public abstract class Catchable : MonoBehaviour
    {
        private Timer CatchTimer;

        public abstract FishSize Size { get; }

        protected bool IsBaiting { get; set; }

        private void OnDestroy()
        {
            CatchTimer.Elapsed -= OnTimesUp;
            CatchTimer.Dispose();
        }
        private void Awake()
        {
            CatchTimer = new Timer();
            CatchTimer.Elapsed += OnTimesUp;
        }

        protected void StartCatchTimer(int Interval)
        {
            if (CatchTimer.Enabled)
            {
                return;
            }
            else
            {
                IsBaiting = true;
                CatchTimer.Enabled = true;
                Debug.Log("Fish Catch-Timer Started Counting.");
                CatchTimer.Interval = (int)Size * Interval;
                CatchTimer.Start();
            }
        }

        protected void StopCatchTimer()
        {
            CatchTimer.Enabled = false;
            CatchTimer.Stop();
        }

        private void OnTimesUp(object obj, ElapsedEventArgs eventArgs)
        {
            IsBaiting = false;
            StopCatchTimer();
            transform.parent = null;
            Debug.Log("Catch-Timer Time-Up!");
        }

        //Fishing Rod
        public virtual void OnTriggerEnter(Collider other)
        {
            Debug.Log("Fishing Bait Entered!");
        }

        //Water Area
        public virtual void OnTriggerExit(Collider other)
        {
            Debug.Log("Fish Left Water!");
        }
    }
}
