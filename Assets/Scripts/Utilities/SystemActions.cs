using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRF.Util
{
    public class SystemActions : MonoBehaviour
    {
        public GameObject Inventory_view;
        public GameObject Resource_view;
        public GameObject Tool_view;

        public Text product_Num;
        public int currentNum = 0;
        public Button SellAllBTN;

        private void Start()
        {
            Inventory_view.SetActive(true);
            Resource_view.SetActive(false);
            Tool_view.SetActive(false);
            product_Num.text = "0";
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

        public void OnClickInventoryButton(GameObject Inventory_view)
        {

            Inventory_view.SetActive(true);
            Resource_view.SetActive(false);
            Tool_view.SetActive(false);
            SellAllBTN.enabled = true;
        }
        public void OnClickToolButton(GameObject Tool_view)
        {
            Tool_view.SetActive(true);
            Resource_view.SetActive(false);
            Inventory_view.SetActive(false);
            SellAllBTN.enabled = false;
        }
        public void OnClickResourceButton(GameObject Resource_view)
        {
            Resource_view.SetActive(true);
            Tool_view.SetActive(false);
            Inventory_view.SetActive(false);
            SellAllBTN.enabled = false;
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

