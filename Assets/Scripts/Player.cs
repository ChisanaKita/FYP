using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using VRF.Driver;

namespace VRF
{
    public class Player : MonoBehaviour
    {
        Timer CatchableTime;

        #region DEBUG
        public bool isCatchable { get; set; }
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            EntityDriver.Instance.FishBiting += FishBiting;
            CatchableTime = new Timer();
            CatchableTime.Interval = 2000;
            CatchableTime.Elapsed += OnCatchTimerEnd;
        }

        // Update is called once per frame
        void Update()
        {
            if (isCatchable)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Catch!");
                    CatchableTime.Stop();
                }
            }
        }

        void FishBiting()
        {
            Debug.Log("Event Triggered");
            isCatchable = true;
            CatchableTime.Start();
        }

        void OnCatchTimerEnd(object obj, ElapsedEventArgs eventArgs)
        {
            CatchableTime.Stop();
            Debug.Log("Missed Catching");
            isCatchable = false;
        }

    }
}