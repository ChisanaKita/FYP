using System.Collections;
using System;
using VRF.BaseClass;
using UnityEngine;

namespace VRF.Driver
{
    public class EntityDriver : Singleten<EntityDriver>
    {
        private EntityDriver(){}

        //Events
        internal event Action FishBiting;
        internal event Action FishBiteEnd;

        #region PlayerEvent
        public void OnFishBiting()
        {
            Debug.Log("publishing event");
            FishBiting?.Invoke();
        }
        public void OnFishReleasedBite()
        {
            FishBiteEnd?.Invoke();
        }
        #endregion

        #region FishEvent

        #endregion
    }
}
