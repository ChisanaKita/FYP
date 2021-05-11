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

        public void SellAll()
        {
            Player.Instance.RemoveAll();
        }
    }
}

