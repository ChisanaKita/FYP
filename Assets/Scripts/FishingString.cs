//https://www.youtube.com/watch?v=FcnvwtyxLds

using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace VRF
{
    public class FishingString : MonoBehaviour
    {
        private readonly Vector3 LINE_STARTING_POINT = new Vector3(4.5f, 0f, 4.5f);

        private LineRenderer _LineRanderer;
        private List<LineSegment> _LineSegments;
        private float _LineSegmentLengthOffset;
        private float _SegmentsLength;
        private Transform _Reel;
        private Transform _SeondConstraint;

        private float _LineWidth;

        private bool IsReelTurned;


        // Start is called before the first frame update
        void Start()
        {
            _LineRanderer = GetComponent<LineRenderer>();
            _LineSegments = new List<LineSegment>();
            _LineSegmentLengthOffset = 1.1f;
            _SegmentsLength = 0.25f;
            _LineSegments.Add(new LineSegment(Vector3.zero));
            _LineSegments.Add(new LineSegment(LINE_STARTING_POINT));
            _LineWidth = 0.015f;
            _Reel = GameObject.FindGameObjectWithTag("Reel").transform;
            _SeondConstraint = transform.parent.Find("SeondConstraint");
            IsReelTurned = false;
        }

        // Update is called once per frame
        void Update()
        {
            DrawLines();

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _LineSegments.Add(new LineSegment(_LineSegments.Last().posNow * _LineSegmentLengthOffset));
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
            Vector3 G_Force = new Vector3(0f, -0.25f, 0);

            for (int i = 2; i < _LineSegments.Count; i++)
            {
                LineSegment firstSegment = _LineSegments[i];
                Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
                firstSegment.posOld = firstSegment.posNow;
                firstSegment.posNow += velocity;
                firstSegment.posNow += G_Force * Time.fixedDeltaTime;
                _LineSegments[i] = firstSegment;
            }

            for (int i = 0; i < 50; i++)
            {
                Constraint();
            }
        }

        private void Constraint()
        {
            LineSegment firstSegment = _LineSegments[0];
            firstSegment.posNow = _Reel.position;
            _LineSegments[0] = firstSegment;

            LineSegment secondSegment = _LineSegments[1];
            secondSegment.posNow = _SeondConstraint.position;
            _LineSegments[1] = secondSegment;

            for (int i = 1; i < _LineSegments.Count - 1; i++)
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
                this.posNow = pos;
                this.posOld = pos;
            }
        }
    }
}
