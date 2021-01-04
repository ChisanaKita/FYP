//https://www.youtube.com/watch?v=nodALlM_IKY

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    private float PICKUP_DISTANCE = 0.2f;

    public SteamVR_Input_Sources CurrentHandInput = SteamVR_Input_Sources.LeftHand;

    private bool IsHandFree;
    private Rigidbody _HoldingObject;

    // Start is called before the first frame update
    void Start()
    {
        IsHandFree = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Pick_Up_Object
        IsHandFree = SteamVR_Actions.vRF_Grab.GetState(CurrentHandInput);

        if (!IsHandFree)
        {
            Collider colliders = Physics.OverlapSphere(transform.position, PICKUP_DISTANCE, LayerMask.NameToLayer("Grabbable")).First();
            if (colliders != null)
            {
                _HoldingObject = colliders.transform.GetComponent<Rigidbody>();
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
    }
}
