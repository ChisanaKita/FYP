using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRF
{
    public class Container : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Fish"))
            {
                Debug.Log("Container");
                Player.Instance.AddItem(other.transform.root.GetComponentInChildren<Fish>().Size);
                Destroy(other.transform.root.gameObject);
            }
        }
    }
}

