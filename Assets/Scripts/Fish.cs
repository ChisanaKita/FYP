using UnityEngine;
using VRF.Driver;
using VRF.Util;
using System;
using System.Collections;
using Random = UnityEngine.Random;

namespace VRF
{
    public class Fish : Catchable, IFish
    {
        //Base Class
        public override FishSize Size => (FishSize)Random.Range(1, Enum.GetNames(typeof(FishSize)).Length - 1);
        public override float SpawnHeight => transform.position.y;

        //Constant
        private readonly float CONS_ROTATION_SPEED = 100;

        

        //IFish
        public bool IsCatched { get; set; }
        public int CatchThreshold { get; set; }
        public string Name { get; set; }

        public bool IsOver { get; set; }
        public Rigidbody _Mouth;
        public Rigidbody _Rigidbody;

        //Private Prop
        private bool IsBaitPresent { get; set;}
        private bool IsCoroutineRunning { get; set; }
        private bool IsTurning { get; set; }
        private bool Ismoving { get; set; }

        private Vector3 TargetAngleVector;
        private Animator _Animator;

        private GameObject _Bait;

        #region Event_Handling
        private void Awake()
        {
            EntityDriver.Instance.OnBaitEntered += BaitEntered;
        }

        private void OnDestroy()
        {
            EntityDriver.Instance.OnBaitEntered -= BaitEntered;
            base.DisposeTimer();
        }
        #endregion

        private void Start()
        {
            CatchThreshold = 1;

            IsCatched = false;
            IsBaiting = false;
            IsBaitPresent = false;
            IsTurning = false;
            Ismoving = false;
            IsCoroutineRunning = false;

            Name = Enum.GetName(typeof(FishType), Random.Range(0, Enum.GetNames(typeof(FishType)).Length - 1));

            TargetAngleVector = GetRandomVectorY();
            transform.localEulerAngles = TargetAngleVector;

            _Animator = GetComponent<Animator>();

            Debug.LogFormat("Fish tpye : {0}, Name : {1}", Size, Name);
        }

        // Update is called once per frame
        void Update()
        {
            if (!IsCatched && !IsBaiting)
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
                    _Mouth.velocity = transform.forward * 1;
                }
            }
            else
            {
                Debug.Log("3");
            }
        }

        void FixedUpdate()
        {
            if (IsBaiting || IsCatched)
            {
                _Mouth.MovePosition(_Bait.transform.position);
            }
        }

        Vector3 GetRandomVectorY()
        {
            return new Vector3(0, Random.Range(0, 360), 0);
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (IsBaitPresent)
            {
                if (other.tag == "Bait")
                {
                    //Debug Message
                    base.OnTriggerEnter(other);
                    Debug.Log("1");
                    ChangeMovingStatus(false);
                    StopCoroutine(AttemptToTurn());
                    EntityDriver.Instance.TriggerFishBiting();
                    StartCatchTimer(5000);
                    _Mouth.velocity = Vector3.zero;
                    _Bait = other.gameObject;
                }
            }

            if (other.tag == "FishArea")
            {
                //ChangeMovingStatus(true);
            }
            Debug.Log("Now entered triger : " + other.tag);
        }
        
        public override void OnTriggerExit(Collider other)
        {
            if (other.tag == "Water")
            {
                if (IsBaiting)
                {
                    base.OnTriggerExit(other);
                    Catched();
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
            base.StopCatchTimer();
            IsBaiting = false;
            ChangeMovingStatus(false);
            StopAllCoroutines();
            IsTurning = false;
            _Rigidbody.useGravity = true;
            _Animator.SetBool("IsMoving", true);
        }

        private void BaitEntered()
        {
            IsBaitPresent = true;
        }

        private void ChangeMovingStatus(bool isMoving)
        {
            Ismoving = isMoving;
            _Animator.SetBool("IsMoving", isMoving);
        }

        private IEnumerator AttemptToTurn()
        {
            IsCoroutineRunning = true;
            yield return new WaitForSeconds(5);
            if ((Random.Range(0, 20) % 2) == 0)
            {
                IsTurning = true;
                TargetAngleVector = GetRandomVectorY();
                Debug.Log("Truning Vector : " + TargetAngleVector.y);
            }
            IsCoroutineRunning = false;
        }

    }
}