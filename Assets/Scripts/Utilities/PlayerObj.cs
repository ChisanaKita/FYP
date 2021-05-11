using System.Collections.Generic;
using UnityEngine;

namespace VRF
{
    [System.Serializable]
    public class PlayerObj
    {
        public List<GameObject> Inventory;
        public GameObject Current_S_Bait;
        public GameObject Current_M_Bait;
        public GameObject Current_L_Bait;
        public int Balance;

        public PlayerObj()
        {
            Inventory = new List<GameObject>();
            Current_S_Bait = Resources.Load<GameObject>("Prefab/Baits/FirstBait");
            Current_M_Bait = null;
            Current_L_Bait = null;
            Balance = 1000;
        }
    }
}

