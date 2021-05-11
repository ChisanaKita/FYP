using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRF
{
    public class SystemActions : MonoBehaviour
    {
        public void Quit()
        {
            Player.Instance.SavePlayerObjectAndQuit();
        }

        public void SellAllFish()
        {
            Player.Instance.RemoveAllFish();
        }

        public void SellItemAtIndex(int index)
        {
            Player.Instance.RemoveItem(index);
        }
    }
}

