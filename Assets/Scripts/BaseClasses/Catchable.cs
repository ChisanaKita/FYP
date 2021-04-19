using UnityEngine;
using System.Timers;

namespace VRF.Util
{
    public abstract class Catchable : MonoBehaviour
    {
        private Timer CatchTimer;

        public abstract FishSize Size { get; }

        public abstract float SpawnHeight { get; }

        protected bool IsBaiting { get; set; }

        protected void StartCatchTimer(int Interval)
        {
            if (CatchTimer == null)
            {
                CatchTimer = new Timer();
                CatchTimer.Elapsed += OnTimesUp;
                CatchTimer.Enabled = false;
            }
            if (CatchTimer.Enabled)
            {
                return;
            }
            else
            {
                Debug.Log("2");
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
            transform.position.Set(transform.position.x, SpawnHeight, transform.position.z);
            Debug.Log("Catch-Timer Time-Up!");
        }

        protected void DisposeTimer()
        {
            if (CatchTimer != null)
            {
                CatchTimer.Elapsed -= OnTimesUp;
                CatchTimer.Dispose();
            }
        }

        //Fishing Rod
        public virtual void OnTriggerEnter(Collider other)
        {
            Debug.Log(string.Format("Fish {0} have collided with object: {1}", ToString(), other.name));
        }

        //Water Area
        public virtual void OnTriggerExit(Collider other)
        {
            Debug.Log("Fish Left Water!");
        }
    }
}
