using System.Collections;
using UnityEngine;
using VRF.Driver;
using VRF.Util;

namespace VRF
{
    public class Bait : MonoBehaviour
    {

        public bool IsCoroutineRunning { get; set; }
        public BaitType MyBaitType { get; set; }

        private bool IsEnteredWater { get; set; }
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
            MyBaitType = BaitType.TestBait;
        }

        private void FixedUpdate()
        {
            if (IsEnteredWater)
            {
                MyRigidbody.AddForce(Vector3.up * ((Mathf.Abs(Physics.gravity.y) + Random.Range(-1f, 1f)) * MyRigidbody.mass), ForceMode.Force);

                if (transform.position.y < 1.5f)
                {
                    MyRigidbody.AddForce(Vector3.up * Random.Range(2f, 4f));
                }
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