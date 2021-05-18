using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace VRF
{
    public class MarketInventoryManager : MonoBehaviour
    {
        public Transform Contents;
        public Text money;

        private Button[] InventoryButtons;
        List<FishSize> inventory;

        // Start is called before the first frame update
        void Start()
        {
            InventoryButtons = Contents.GetComponentsInChildren<Button>().OrderBy(Inventorys => Inventorys.name).ToArray();
            for (int i = 0; i < InventoryButtons.Length; i++)
            {
                int index = new int() ;
                index = i;
                InventoryButtons[i].onClick.AddListener(delegate { OnInventoryItemClicked(index); });
            }
            Refreash();
        }

        private void OnInventoryItemClicked(int Button_Index)
        {
            Player.Instance.RemoveFish(inventory[Button_Index]);
            Refreash();
        }

        private void Refreash()
        {
            if (Player.Instance.GetInventory().Count > 0)
            {
                inventory = Player.Instance.GetInventory();
                for (int i = 0; i < InventoryButtons.Length; i++)
                {
                    if (i < inventory.Count)
                    {
                        InventoryButtons[i].GetComponentInChildren<Text>().text = inventory[i].ToString();
                    }
                    else
                    {
                        InventoryButtons[i].GetComponentInChildren<Text>().text = "";
                        InventoryButtons[i].interactable = false;
                    }
                }
            } else
            {
                foreach (var btn in InventoryButtons)
                {
                    btn.interactable = false;
                    btn.GetComponentInChildren<Text>().text = "";
                }
            }
            money.text = Player.Instance.GetBalance().ToString();
        }
    }
}

