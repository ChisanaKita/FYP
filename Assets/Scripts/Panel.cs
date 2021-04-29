using UnityEngine;
using UnityEngine.UI;

namespace VRF
{
    public class Panel : MonoBehaviour
    {
        private Canvas canvas = null;
        private PanelManager panelManager = null;
        public Text product_Num;
        public int currentNum = 0;

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        // Update is called once per frame
        public void Setup()
        {
            this.panelManager = panelManager;
            Hide();
            product_Num.text = "0";
        }

        public void Show()
        {
            canvas.enabled = true;

        }

        public void Hide()
        {
            canvas.enabled = false;
            currentNum = 0;
            product_Num.text = currentNum.ToString();
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
