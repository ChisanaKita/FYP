using System.Collections;
using System;
using System.Timers;
using UnityEngine;
using VRF.Driver;

namespace VRF
{
    public class Fish : Catchable
    {

        public bool IsCatched { get; set; }

        public int CatchThreshold { get; set; }

        public string Name { get; }

        public override FishType Type => (FishType)GetRandomFishType();

        // Start is called before the first frame update
        void Start()
        {
            CatchThreshold = 1;
            IsCatched = false;
            CatchTimer = new Timer();
            CatchTimer.Elapsed += OnTimesUp;
            Debug.LogFormat("Fish tpye : {0}", Type);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                StartCounting(2);
            }
        }

        int GetRandomFishType()
        {
            System.Random rand = new System.Random();
            return rand.Next(1, 3);
        }



        //Fishing Rod
        private void OnTriggerEnter(Collider other)
        {
            
        }

        //Water Area
        private void OnTriggerExit(Collider other)
        {
            
        }
    }
}