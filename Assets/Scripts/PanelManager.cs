using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRF
{
    public class PanelManager : MonoBehaviour
    {
        public CanvasGroup Inventory_Panel;
        public CanvasGroup Resource_Panel;
        public CanvasGroup Tool_Panel;

        public Button BTN_Inventory, BTN_Resource, BTN_Tool;

        private void Start()
        {
            BTN_Inventory.onClick.AddListener(OnInventoryClicked);
            BTN_Resource.onClick.AddListener(OnResourceClicked);
            BTN_Tool.onClick.AddListener(OnToolClicked);
        }

        public void OnInventoryClicked()
        {
            SetView(Inventory_Panel, Resource_Panel, Tool_Panel);
        }

        public void OnResourceClicked()
        {
            SetView(Resource_Panel, Inventory_Panel, Tool_Panel);
        }

        public void OnToolClicked()
        {
            SetView(Tool_Panel, Resource_Panel, Inventory_Panel);
        }

        private void SetView(CanvasGroup target, CanvasGroup other1, CanvasGroup other2)
        {
            target.alpha = 1.0f;
            other1.alpha = 0;
            other2.alpha = 0;

            target.blocksRaycasts = true;
            other1.blocksRaycasts = false;
            other2.blocksRaycasts = false;

            target.interactable = true;
            other1.interactable = false;
            other2.interactable = false;
        }
    }
}
