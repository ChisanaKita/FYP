using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VRF
{
    public class PanelManager : MonoBehaviour
    {
        public Panel Panel1 = null;
        public Panel Panel2 = null;
        public Panel Panel3 = null;

        private void Start()
        {
            Panel1.Show();
        }

        public void OnClickBackpackButton(Panel panel1)
        {
            Panel2.Hide();
            Panel3.Hide();
            Panel1.Show();
        }
        public void OnClickToolButton(Panel panel2)
        {
            Panel1.Hide();
            Panel3.Hide();
            Panel2.Show();
        }
        public void OnClickResourceButton(Panel panel3)
        {
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Show();
        }
    }
}
