using UnityEngine;
using VRF.Driver;
using VRF.Util;

namespace VRF
{
    public class Player : Playable
    {
        // Start is called before the first frame update
        void Start()
        {
            EntityDriver.Instance.FishBiting += FishBiting;
            EntityDriver.Instance.FishBiteEnd += CatchFailed;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FishBiting()
        {
            Debug.Log("Fish is baiting!");
        }

        void CatchFailed()
        {
            Debug.Log("You missed the catch!");
        }

        private void AttemptCatch()
        {
            
        }
    }
}