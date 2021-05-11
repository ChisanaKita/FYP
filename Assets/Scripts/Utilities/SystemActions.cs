using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRF.Util
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
    }
}

