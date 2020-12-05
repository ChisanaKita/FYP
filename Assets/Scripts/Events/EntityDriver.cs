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
        internal event Action OnFishBiting;
        internal event Action OnFishBiteEnd;

        //Both
        internal event Action OnCatched;
        
        //Fishs events
        internal event Action OnBaitEntered;
        #endregion


        #region PlayerEvent
        public void TriggerFishBiting()
        {
            OnFishBiting?.Invoke();
        }
        public void TriggerFishReleasedBite()
        {
            OnFishBiteEnd?.Invoke();
        }
        #endregion

        public void TriggerCatched()
        {
            OnCatched?.Invoke();
        }

        #region FishEvent
        public void TriggerBaitEntered()
        {
            OnBaitEntered?.Invoke();
        }
        #endregion
    }
}
