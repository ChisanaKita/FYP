﻿using System.Timers;
using UnityEngine;
using VRF.Driver;

namespace VRF
{
    public class Bait : MonoBehaviour
    {
        public BaitType MyBaitType;

        private bool IsEnteredWater;
        private Rigidbody _Rigidbody;
        private float DEBUG_PeekVelocity = 0;

        #region Event_Handling
        private void Awake()
        {

        }

        private void OnDestroy()
        {
            Debug.Log(DEBUG_PeekVelocity);
        }
        #endregion

        private void Start()
        {
            IsEnteredWater = false;
            _Rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_Rigidbody.velocity.magnitude > DEBUG_PeekVelocity)
            {
                DEBUG_PeekVelocity = _Rigidbody.velocity.magnitude;
            }
        }

        private void FixedUpdate()
        {
            if (IsEnteredWater)
            {
                _Rigidbody.AddForce(Vector3.up * ((Mathf.Abs(Physics.gravity.y) + Random.Range(-1f, 1f)) * _Rigidbody.mass), ForceMode.Force);

                if (transform.position.y < 1.5f)
                {
                    _Rigidbody.AddForce(Vector3.up * Random.Range(2f, 4f));
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
                EntityDriver.Instance.TriggerBaitExited();
                IsEnteredWater = false;
                Debug.Log("Exited Water");
            }
        }

    }
}