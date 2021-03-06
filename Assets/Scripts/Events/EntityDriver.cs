﻿using System;
using VRF.BaseClass;

namespace VRF.Driver
{
    public class EntityDriver : Singleten<EntityDriver>
    {
        private EntityDriver(){}

        #region Events
        //Player Events
        internal event Action OnFishBiting;
        internal event Action OnFishBiteEnd;
        internal event Action OnReelDown;
        internal event Action OnReelUp;
        internal event Action OnReelHold;
        internal event Action OnReelHoldRelease;

        //Both
        internal event Action OnCatched;
        
        //Fishs events
        internal event Action OnBaitEntered;
        internal event Action OnBaitExited;
        internal event Action OnPlayerGrabed;
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
        public void TriggerReelUp()
        {
            OnReelUp?.Invoke();
        }
        public void TriggerReelDown()
        {
            OnReelDown?.Invoke();
        }
        public void TriggerReelHold()
        {
            OnReelHold?.Invoke();
        }
        public void TriggerReelHoldRelease()
        {
            OnReelHoldRelease?.Invoke();
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
        public void TriggerBaitExited()
        {
            OnBaitExited?.Invoke();
        }
        public void TriggerPlayerGrabed()
        {
            OnPlayerGrabed?.Invoke();
        }
        #endregion
    }
}
