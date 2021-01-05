//https://www.youtube.com/watch?v=nodALlM_IKY

using VRF.Driver;
using UnityEngine;
using Valve.VR;

namespace VRF
{
    public class Hand : MonoBehaviour
    {
        private float PICKUP_DISTANCE = 0.3f;

        public SteamVR_Input_Sources CurrentHandInput = SteamVR_Input_Sources.LeftHand;

        private bool IsHandFree;
        private Rigidbody _HoldingObject;
        public LayerMask _GrabLayer;
        private LayerMask _InteractLayer;

        // Start is called before the first frame update
        void Start()
        {
            IsHandFree = true;
            _GrabLayer = LayerMask.GetMask("Grabbable");
            _InteractLayer = LayerMask.GetMask("Interactable");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            #region Pick_Up_Object
            IsHandFree = SteamVR_Actions.VRF.Grab.GetState(CurrentHandInput);

            if (!IsHandFree)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, PICKUP_DISTANCE, _GrabLayer);
                if (colliders.Length > 0)
                {
                    _HoldingObject = colliders[0].transform.root.GetComponent<Rigidbody>();
                }
                else
                {
                    _HoldingObject = null;
                }
            }
            else
            {
                if (_HoldingObject != null)
                {
                    _HoldingObject.velocity = (transform.position - _HoldingObject.transform.position) / Time.fixedDeltaTime;

                    if (!_HoldingObject.gameObject.tag.Equals("Handle"))
                    {
                        _HoldingObject.maxAngularVelocity = 20;
                        Quaternion RotationDelta = transform.rotation * Quaternion.Inverse(_HoldingObject.transform.rotation);
                        Vector3 RotationEuler = new Vector3(Mathf.DeltaAngle(0, RotationDelta.eulerAngles.x), Mathf.DeltaAngle(0, RotationDelta.eulerAngles.y), Mathf.DeltaAngle(0, RotationDelta.eulerAngles.z));
                        RotationEuler *= 0.95f;
                        RotationEuler *= Mathf.Deg2Rad;
                        _HoldingObject.angularVelocity = RotationEuler / Time.fixedDeltaTime;
                    }
                }
            }
            #endregion
            if (SteamVR_Actions.VRF.D_Down.GetStateDown(CurrentHandInput))
            {
                EntityDriver.Instance.TriggerReelHold();
            }

            if (SteamVR_Actions.VRF.D_Down.GetStateUp(CurrentHandInput))
            {
                //EntityDriver.Instance.TriggerReelHoldRelease();
            }
        }
    }

}
