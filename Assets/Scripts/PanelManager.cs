using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRF
{
    public class PanelManager : MonoBehaviour
    {
        public GameObject Main_Panel;
        public GameObject Resource_Panel;
        public GameObject Tool_Panel;

        private void Start()
        {
            Tool_Panel.SetActive(false);
            Resource_Panel.SetActive(false);
            Main_Panel.SetActive(true);
        }

        public void OnClickBackpackButton(GameObject Main_Panel)
        {
            Tool_Panel.SetActive(false);
            Resource_Panel.SetActive(false);
            Main_Panel.SetActive(true);
        }
        public void OnClickToolButton(GameObject Tool_Panel)
        {
            Main_Panel.SetActive(false);
            Resource_Panel.SetActive(false);
            Tool_Panel.SetActive(true);
        }
        public void OnClickResourceButton(GameObject Resource_Panel)
        {
            Main_Panel.SetActive(false);
            Tool_Panel.SetActive(false);
            Resource_Panel.SetActive(true);
        }
    }
}
