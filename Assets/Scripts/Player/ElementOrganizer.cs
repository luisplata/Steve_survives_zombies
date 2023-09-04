using System.Collections.Generic;
using UnityEngine;

public class ElementOrganizer : MonoBehaviour
{
    [SerializeField] private float spacing;

    public List<Vector3> GetPointsInWord(GameObject point, int countOfElements)
    {
        List<Vector3> points = new List<Vector3>();
        switch (countOfElements)
        {
            case 1:
                points.Add(point.transform.position);
                break;
            case >1:
                float angleStep = 360f / countOfElements;
                float currentAngle = 0f;

                for (int i = 0; i < countOfElements; i++)
                {
                    float xPosition = spacing * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
                    float zPosition = spacing * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

                    points.Add(point.transform.position + new Vector3(xPosition, 0f, zPosition));

                    currentAngle += angleStep;
                }
                break;
        }
        return points;
    }
}
