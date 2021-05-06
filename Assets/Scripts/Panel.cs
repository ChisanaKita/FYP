using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRF
{
    public class Panel : MonoBehaviour
    {
        public Text product_Num;
        public int currentNum = 0;

        public void Setup()
        {
            product_Num.text = "0";
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
