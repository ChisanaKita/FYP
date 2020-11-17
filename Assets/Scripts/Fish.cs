using UnityEngine;
using VRF.Driver;
using VRF.Util;
using System;
using System.Collections;

namespace VRF
{
    public class Fish : Catchable, IFish
    {
        public override FishSize Size => (FishSize)SRandom.Instance.GetRandom(1, Enum.GetNames(typeof(FishSize)).Length - 1);

        private readonly float CONS_ROTATION_SPEED = 30;

        public bool IsBaiting { get; set; }
        public bool IsCatched { get; set; }
        public int CatchThreshold { get; set; }
        public string Name { get; set; }

        private bool IsBaitPresent { get; set;}
        private bool IsTurning { get; set; }
        private bool Ismoving { get; set; }
        public bool IsCoroutineRunning { get; set; }
        private Vector3 TargetAngleVector;
        private Rigidbody m_rigidbody;

        #region Event_Handling
        private void Awake()
        {
            EntityDriver.Instance.Catched += Catched;
            EntityDriver.Instance.BaitEntered += BaitEntered;
        }

        private void OnDestroy()
        {
            EntityDriver.Instance.Catched -= Catched;
            EntityDriver.Instance.BaitEntered -= BaitEntered;
        }
        #endregion

        private void Start()
        {
            CatchThreshold = 1;

            IsCatched = false;
            IsBaiting = false;
            IsBaitPresent = true;
            IsTurning = false;
            Ismoving = true;
            IsCoroutineRunning = false;

            Name = Enum.GetName(typeof(FishType), SRandom.Instance.GetRandom(0, Enum.GetNames(typeof(FishType)).Length - 1));

            TargetAngleVector = GetRandomVector3();
            transform.localEulerAngles = TargetAngleVector;

            m_rigidbody = GetComponent<Rigidbody>();

            Debug.LogFormat("Fish tpye : {0}, Name : {1}", Size, Name);
        }

        // Update is called once per frame
        void Update()
        {
            if (IsBaitPresent)
            {
                //Turn
                if (IsTurning)
                {
                    if (Vector3.Distance(transform.localEulerAngles, TargetAngleVector) < 0.001f)
                    {
                        IsTurning = false;
                        transform.localEulerAngles = TargetAngleVector;
                    }
                    else
                    {
                        transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, TargetAngleVector, Time.deltaTime * CONS_ROTATION_SPEED);
                    }
                }
                else
                {
                    if (IsCoroutineRunning == false)
                    {
                        StartCoroutine(AttemptToTurn());
                        Debug.Log("Attempting to turn.");
                    }
                }

                //Move
                if (Ismoving)
                {
                    m_rigidbody.velocity = transform.forward * 1;
                }
            }
        }

        Vector3 GetRandomVector3()
        {
            return new Vector3(0, SRandom.Instance.GetRandom(0, 360), 0);
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (IsBaitPresent)
            {
                if (other.tag == "Bait")
                {
                    base.OnTriggerEnter(other);
                    EntityDriver.Instance.OnFishBiting();
                    IsBaiting = true;
                    StartCatchTimer((int)Size);
                    transform.SetParent(other.transform);
                }
            }
        }
        
        public override void OnTriggerExit(Collider other)
        {
            if (other.tag == "Water")
            {
                if (IsBaiting)
                {
                    base.OnTriggerExit(other);
                    EntityDriver.Instance.OnCatched();
                }
                else
                {
                    return;
                }
            }
        }

        private void Catched()
        {
            IsCatched = true;
            IsBaiting = false;
        }

        private void BaitEntered()
        {
            IsBaitPresent = true;
        }

        private IEnumerator AttemptToTurn()
        {
            IsCoroutineRunning = true;
            yield return new WaitForSeconds(5);
            if ((SRandom.Instance.GetRandom(0, 20) % 2) == 0)
            {
                IsTurning = true;
                TargetAngleVector = GetRandomVector3();
                Debug.Log("Truning Vector : " + TargetAngleVector.y);
            }
            IsCoroutineRunning = false;
        }

    }
}