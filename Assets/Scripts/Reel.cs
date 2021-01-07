//https://stackoverflow.com/questions/55451878/counting-a-full-rotation-with-a-circular-drive
using UnityEngine;
using VRF.Driver;

namespace VRF
{
    public class Reel : MonoBehaviour
    {
        public int RotationCount;

        public float rotatedAroundX;

        public Vector3 lastUp;


        private void Awake()
        {
            rotatedAroundX = 0;

            // initialize
            lastUp = transform.up;
        }

        private void Update()
        {
            var rotationDifference = Vector3.SignedAngle(transform.up, lastUp, transform.forward);

            rotatedAroundX += rotationDifference;

            if (rotatedAroundX >= 360.0f)
            {
                Debug.Log("One positive rotation done", this);

                EntityDriver.Instance.TriggerReelUp();

                 rotatedAroundX -= 360.0f;
            }
            else if (rotatedAroundX <= -360.0f)
            {
                Debug.Log("One negative rotation done", this);

                EntityDriver.Instance.TriggerReelDown();

                rotatedAroundX += 360.0f;
            }

            // update last rotation
            lastUp = transform.up;
        }
    }
}