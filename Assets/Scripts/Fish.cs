using UnityEngine;
using VRF.Driver;
using VRF.Util;
using System;
using System.Collections;

namespace VRF
{
    public class Fish : Catchable, IFish
    {
        //Base Class
        public override FishSize Size => (FishSize)SRandom.Instance.GetRandom(1, Enum.GetNames(typeof(FishSize)).Length - 1);

        //Constant
        private readonly float CONS_ROTATION_SPEED = 100;

        //IFish
        public bool IsCatched { get; set; }
        public int CatchThreshold { get; set; }
        public string Name { get; set; }

        //Private Prop
        private bool IsBaitPresent { get; set;}
        private bool IsTurning { get; set; }
        private bool Ismoving { get; set; }
        private bool IsCoroutineRunning { get; set; }
        private Vector3 TargetAngleVector;
        private Rigidbody MyRigidbody;
        private Animator MyAnimator;

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
            Ismoving = false;
            IsCoroutineRunning = false;

            Name = Enum.GetName(typeof(FishType), SRandom.Instance.GetRandom(0, Enum.GetNames(typeof(FishType)).Length - 1));

            TargetAngleVector = GetRandomVectorY();
            transform.localEulerAngles = TargetAngleVector;

            MyRigidbody = GetComponent<Rigidbody>();
            MyAnimator = GetComponent<Animator>();

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
                    MyRigidbody.velocity = transform.forward * 1;
                }
            }
        }

        Vector3 GetRandomVectorY()
        {
            return new Vector3(0, SRandom.Instance.GetRandom(0, 360), 0);
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (IsBaitPresent)
            {
                if (other.tag == "Bait")
                {
                    //Debug Message
                    base.OnTriggerEnter(other);

                    ChangeMovingStatus(false);
                    EntityDriver.Instance.OnFishBiting();
                    StartCatchTimer((int)Size);
                    MyRigidbody.velocity = Vector3.zero;
                    transform.SetParent(other.transform);
                }
            }

            if (other.tag == "FishArea")
            {
                ChangeMovingStatus(true);
            }
            Debug.Log("Now entered teiger : " + other.tag);
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
            if (other.tag == "FishArea")
            {
                ChangeMovingStatus(false);
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

        private void ChangeMovingStatus(bool isMoving)
        {
            Ismoving = isMoving;
            MyAnimator.SetBool("IsMoving", isMoving);
        }

        private IEnumerator AttemptToTurn()
        {
            IsCoroutineRunning = true;
            yield return new WaitForSeconds(5);
            if ((SRandom.Instance.GetRandom(0, 20) % 2) == 0)
            {
                IsTurning = true;
                TargetAngleVector = GetRandomVectorY();
                Debug.Log("Truning Vector : " + TargetAngleVector.y);
            }
            IsCoroutineRunning = false;
        }

    }
}