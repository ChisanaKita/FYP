using System.Collections;
using System;
using VRF.BaseClass;
using UnityEngine;

namespace VRF.Driver
{
    public class EntityDriver : Singleten<EntityDriver>
    {
        private EntityDriver(){}

        #region Events
        //Player Events
        internal event Action FishBiting;
        internal event Action FishBiteEnd;

        //Both
        internal event Action Catched;
        
        //Fishs events
        internal event Action BaitEntered;
        #endregion


        #region PlayerEvent
        public void OnFishBiting()
        {
            FishBiting?.Invoke();
        }
        public void OnFishReleasedBite()
        {
            FishBiteEnd?.Invoke();
        }
        #endregion

        public void OnCatched()
        {
            Catched?.Invoke();
        }

        #region FishEvent
        public void OnBaitEntered()
        {
            BaitEntered?.Invoke();
        }
        #endregion
    }
}
