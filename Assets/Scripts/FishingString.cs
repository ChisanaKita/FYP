using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FishingString : MonoBehaviour
{
    private readonly Vector3 LINE_STARTING_POINT = new Vector3(4.5f, 0f, 4.5f);

    private LineRenderer _LineRanderer;
    private List<LineSegment> _LineSegments;
    private float _LineSegmentLength;
    //private int _TotalSegments;

    private float _LineWidth;


    // Start is called before the first frame update
    void Start()
    {
        _LineRanderer = GetComponent<LineRenderer>();
        _LineSegments = new List<LineSegment>();
        _LineSegmentLength = 0.5f;
        _LineSegments.Add(new LineSegment(Vector3.zero));
        _LineSegments.Add(new LineSegment(LINE_STARTING_POINT));
        _LineWidth = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLines();
    }

    private void DrawLines()
    {
        _LineRanderer.startWidth = _LineRanderer.endWidth = _LineWidth;

        Vector3[] _LinesPosition = _LineSegments.Select(lines => lines.posNow).ToArray();
        _LineRanderer.positionCount = _LinesPosition.Length;
        _LineRanderer.SetPositions(_LinesPosition);
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
