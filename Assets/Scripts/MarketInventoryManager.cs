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

        private Button[] InventoryButtons;
        List<GameObject> inventory;

        // Start is called before the first frame update
        void Start()
        {
            InventoryButtons = Contents.GetComponentsInChildren<Button>().OrderBy(Inventorys => Inventorys.name).ToArray();
            for (int i = 0; i < InventoryButtons.Length; i++)
            {
                InventoryButtons[i].onClick.AddListener(delegate { OnInventoryItemClicked(i); });
            }
            Refreash();
        }

        // Update is called once per frame
        void Update()
        {
            //
        }

        private void OnInventoryItemClicked(int Button_Index)
        {
            Player.Instance.AddBalance((int)inventory[Button_Index].GetComponent<Fish>().Size * 100);
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
                        InventoryButtons[i].GetComponentInChildren<Text>().text = inventory[i].name;
                        InventoryButtons[i].interactable = inventory[i].tag.Equals("Fish") ? true : false;
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
        }
    }
}

