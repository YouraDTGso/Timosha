/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Presets;
using UnityEngine;
[System.Serializable]
public class Path : MonoBehaviour
{
    [SerializeField, HideInInspector]
    List<Vector2> points;

    public Path(Vector2 centre)
    {
        points = new List<Vector2>
        {
            centre+Vector2.left,
            centre + (Vector2.left + Vector2.up) * 0.5f,
            centre+(Vector2.right+Vector2.down)*0.5f,
            centre+Vector2.right
        };
    }

    public Vector2 this[int i]
    {
        get 
        {
            return points[i];
        }
    }

    public int NumPoints
    {
        get 
        {
            return points.Count;
        }
    }

    public int NumSegents
    {
        get
        {
            return (points.Count - 4) / 3 + 1;
        }
    }

    public void AddSegment(Vector2 anchorPos)
    {
        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
        points.Add((points[points.Count - 1] + anchorPos) * 0.5f);
        points.Add(anchorPos);
    }

    public Vector2[] GetPointsInSegment(int i)
    {
        return new Vector2[] { points[i * 3], points[i * 3 + 1], points[i * 3 + 2], points[i*3+3] };
    }

    public void MovePoint(int i, Vector2 pos)
    {
        Vector2 deltaMove = pos - points[i];
        points[i] = pos;

        if (i%3==0)
        {
            if(i+1<points.Count)
                points[i + 1] += deltaMove;
            if(i - 1 >=0)
                points[i - i] += deltaMove;
        }
        else
        {
            bool nextPointAnchor = (i + 1) % 3 == 0;
            int correspondingControlIndex = (nextPointAnchor) ? i + 2 : i - 2;
            int anchorIndex = (nextPointAnchor) ? i + 1 : i - 1;

            if (correspondingControlIndex >= 0 && correspondingControlIndex < points.Count)
            {
                float dst = (points[anchorIndex] - points[correspondingControlIndex]).magnitude;
                Vector2 dir = (points[anchorIndex] - pos).normalized;
                points[correspondingControlIndex] = points[anchorIndex] + dir * dst;
            }
        }
    }

    public Vector2[] CalculateEvenlySpacedPoints(float spacing, float resolution = 1f)
    {
        List<Vector2> evenlySpacedPoints = new List<Vector2>();
        evenlySpacedPoints.Add(points[0]);
        Vector2 previousPoint = points[0];
        float dstSinceLastEvenPoint = 0;

        for (int segentIndex = 0; segentIndex < NumSegents; segentIndex++)
        {
            Vector2[] p = GetPointsInSegment(segentIndex);
            float ControlNetLength = Vector2.Distance(p[0], p[1]) + Vector2.Distance(p[1], p[2]) + Vector2.Distance(p[2], p[3]);
            float estimatedCurveLength = Vector2.Distance(p[0], p[3]) + ControlNetLength / 2f;
            int divisions = Mathf.CeilToInt(estimatedCurveLength * resolution * 10);
            float t = 0;
            while (t<=1)
            {
                t += 0.1f;
                Vector2 pointCurve = Bezier.EvaluateCubic(p[0], p[1], p[2], p[3], t);
                dstSinceLastEvenPoint += Vector2.Distance(previousPoint, pointCurve);

                while (dstSinceLastEvenPoint>=spacing)
                {
                    float overshootDst = dstSinceLastEvenPoint - spacing;
                    Vector2 newEvenlySpacedPoint = pointCurve + (previousPoint - pointCurve).normalized * overshootDst;
                    evenlySpacedPoints.Add(newEvenlySpacedPoint);
                    dstSinceLastEvenPoint = overshootDst;
                    previousPoint = newEvenlySpacedPoint;
                }

                previousPoint = pointCurve;
            }
        }
        return evenlySpacedPoints.ToArray();
    }
}
*/