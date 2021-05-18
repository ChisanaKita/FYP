using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRF.Util
{
    public class SystemActions : MonoBehaviour
    {
        public Text product_Num;
        public int currentNum = 0;
        public Button SellAllBTN;

        private void Start()
        {
            Player.Instance.InitPlayerObj();
        }

        public void Quit()
        {
            Player.Instance.SavePlayerObjectAndQuit();
        }

        public void SellAllFish()
        {
            Player.Instance.RemoveAllFish();
        }

        public void Plus()
        {
            currentNum++;
            product_Num.text = currentNum.ToString();
        }
        public void Minus()
        {
            if (currentNum > 0)
                currentNum--;
            product_Num.text = currentNum.ToString();
        }
    }
}

