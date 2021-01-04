﻿//https://www.youtube.com/watch?v=FcnvwtyxLds

using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using VRF.Driver;

namespace VRF
{
    public class FishingString : MonoBehaviour
    {
        //private readonly Vector3 LINE_STARTING_POINT = new Vector3(0f, 0f, 20.65f);
        private readonly Vector3 G_Force = new Vector3(0f, -0.01f, 0);

        private LineRenderer _LineRanderer;
        private List<LineSegment> _LineSegments;

        private Vector3 _LineSegmentLengthOffset;
        private float _SegmentsLength;
        private float _LineWidth;

        private Transform _Reel;
        private Transform _SecondConstraint;
        private Transform _ThirdConstraint;

        private Transform _Bait;

        private bool IsReelHold;

        #region EVENT_HANDLER
        private void Awake()
        {
            EntityDriver.Instance.OnReelDown += ReelDown;
            EntityDriver.Instance.OnReelUp += ReelUp;
            EntityDriver.Instance.OnReelHold += ReelHold;
            EntityDriver.Instance.OnReelHoldRelease += ReelHoldRelease;
        }
        private void OnDestroy()
        {
            EntityDriver.Instance.OnReelDown -= ReelDown;
            EntityDriver.Instance.OnReelUp -= ReelUp;
            EntityDriver.Instance.OnReelHold -= ReelHold;
            EntityDriver.Instance.OnReelHoldRelease -= ReelHoldRelease;
        }

        private void ReelUp()
        {
            if (_LineSegments.Count > 2)
            {
                _LineSegments.RemoveAt(_LineSegments.Count - 1);
            }
        }

        private void ReelDown()
        {
            _LineSegments.Add(new LineSegment(_LineSegments.Last().posNow - _LineSegmentLengthOffset));
        }

        private void ReelHold()
        {
            IsReelHold = true;
        }

        private void ReelHoldRelease()
        {
            IsReelHold = false;
        }

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            _LineRanderer = GetComponent<LineRenderer>();
            _LineSegments = new List<LineSegment>();
            _LineSegments.Add(new LineSegment(Vector3.zero));
            _LineSegments.Add(new LineSegment(Vector3.zero));
            _LineSegments.Add(new LineSegment(Vector3.zero));

            _LineSegmentLengthOffset = new Vector3(0, 0.25f, 0);
            _SegmentsLength = 0.25f;
            _LineWidth = 0.015f;

            _Reel = GameObject.FindGameObjectWithTag("Reel").transform;
            _SecondConstraint = transform.parent.Find("SecondConstraint");
            _ThirdConstraint = transform.parent.Find("ThirdConstraint");
            _Bait = GameObject.FindGameObjectWithTag("Bait").transform;

            IsReelHold = false;
        }

        // Update is called once per frame
        void Update()
        {
            DrawLines();

            #region TESTING
            //Down Fish Line
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                ReelUp();
            }

            //Up Fish Line
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                ReelDown();
            }

            //Clamp The Bait
            if (Input.GetKey(KeyCode.Space))
            {
                _Bait.position = _LineSegments.Last().posNow;
            }
            #endregion

            if (IsReelHold)
            {

            }

            //If line segments is greater than 2 :
            if (_LineSegments.Count > 2)
            {
                //Plus, If the magnitude of the vector between the bait and the last segment is greater than 0.25 :
                if ((_LineSegments.Last().posNow - _Bait.position).magnitude > 0.25f)
                {
                    //Add a new segment to the list.
                    _LineSegments.Add(new LineSegment(_LineSegments.Last().posNow - _LineSegmentLengthOffset));
                }
                //Let the last segment follow the bait.
                LineSegment _LastSeg = _LineSegments.Last();
                _LastSeg.posNow = _Bait.position;
                _LineSegments[_LineSegments.Count - 1] = _LastSeg;
            }
            else //If the line segments is less than 2 :
            {
                //The bait follows the last line segment's position.
                _Bait.position = _LineSegments.Last().posNow;
            }
        }

        private void FixedUpdate()
        {
            SimulateLine();
        }

        private void DrawLines()
        {
            _LineRanderer.startWidth = _LineRanderer.endWidth = _LineWidth;

            Vector3[] _LinesPosition = _LineSegments.Select(lines => lines.posNow).ToArray();
            _LineRanderer.positionCount = _LinesPosition.Length;
            _LineRanderer.SetPositions(_LinesPosition);
        }

        private void SimulateLine()
        {
            for (int i = 3; i < _LineSegments.Count; i++)
            {
                LineSegment firstSegment = _LineSegments[i];
                Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
                firstSegment.posOld = firstSegment.posNow;
                firstSegment.posNow += velocity;
                firstSegment.posNow += G_Force * Time.fixedDeltaTime;
                _LineSegments[i] = firstSegment;
            }

            if (_LineSegments.Count > 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    Constraint();
                }
            }
        }

        private void Constraint()
        {
            //The first line point always is the Reel's position.
            LineSegment firstSegment = _LineSegments[0];
            firstSegment.posNow = _Reel.position;
            _LineSegments[0] = firstSegment;

            //The second line point always is the nearest hold of the fishing rod.
            LineSegment secondSegment = _LineSegments[1];
            secondSegment.posNow = _SecondConstraint.position;
            _LineSegments[1] = secondSegment;

            //The third line is always from the reel to the tip of the fishing rod.
            LineSegment thirdSegment = _LineSegments[1];
            thirdSegment.posNow = _ThirdConstraint.position;
            _LineSegments[1] = thirdSegment;

            //Applying Non-sence.
            for (int i = 2; i < _LineSegments.Count - 1; i++)
            {
                LineSegment firstSeg = _LineSegments[i];
                LineSegment secondSeg = _LineSegments[i + 1];

                float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
                float error = dist - _SegmentsLength;

                Vector3 changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
                Vector3 changeAmount = changeDir * error;

                if (i != 0)
                {
                    firstSeg.posNow -= changeAmount * 0.5f;
                    _LineSegments[i] = firstSeg;
                    secondSeg.posNow += changeAmount * 0.5f;
                    _LineSegments[i + 1] = secondSeg;
                }
                else
                {
                    secondSeg.posNow += changeAmount;
                    _LineSegments[i + 1] = secondSeg;
                }
            }
        }

        public struct LineSegment
        {
            public Vector3 posNow;
            public Vector3 posOld;
            public LineSegment(Vector3 pos)
            {
                posNow = pos;
                posOld = pos;
            }
        }
    }
}
