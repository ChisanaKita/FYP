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

        private readonly float AnglePreTurn = 90.0f;


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

            if (rotatedAroundX >= AnglePreTurn)
            {
                EntityDriver.Instance.TriggerReelUp();

                 rotatedAroundX -= AnglePreTurn;
            }
            else if (rotatedAroundX <= -AnglePreTurn)
            {
                EntityDriver.Instance.TriggerReelDown();

                rotatedAroundX += AnglePreTurn;
            }

            // update last rotation
            lastUp = transform.up;
        }
    }
}