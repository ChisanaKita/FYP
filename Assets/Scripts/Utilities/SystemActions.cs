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

        public void SellFishAtIndex(int index)
        {
            Player.Instance.RemoveFish(index);
        }

        public void Buy(GameObject gameObject, int price, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (Player.Instance.GetBalance() - price > 0)
                {
                    Player.Instance.AddItem(gameObject);
                    Player.Instance.SubtractBalance(price);
                }
                else
                {
                    break;
                }
            }
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

