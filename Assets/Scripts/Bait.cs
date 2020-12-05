using System.Collections;
using UnityEngine;
using VRF.Driver;
using VRF.Util;

namespace VRF
{
    public class Bait : MonoBehaviour
    {

        private bool IsEnteredWater { get; set; }
        public bool IsCoroutineRunning { get; set; }

        private Rigidbody MyRigidbody;

        #region Event_Handling
        private void Awake()
        {

        }

        private void OnDestroy()
        {

        }
        #endregion

        private void Start()
        {
            IsEnteredWater = IsCoroutineRunning = false;
            MyRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (IsEnteredWater)
            {
                MyRigidbody.AddForce(-transform.up * (MyRigidbody.velocity.y - Random.Range(-1f, 2.25f)), ForceMode.Force);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Water")
            {
                EntityDriver.Instance.TriggerBaitEntered();
                IsEnteredWater = true;
                Debug.Log("Entered Water");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Water")
            {
                IsEnteredWater = false;
                Debug.Log("Exited Water");
            }
        }

        #region Events
        private void TODO()
        {

        }
        #endregion
    }
}