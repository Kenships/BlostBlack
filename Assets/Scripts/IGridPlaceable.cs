using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public interface IGridPlaceable
{
    public List<Vector2Int> GetLocalGridCoordinates();

    public static List<Vector2Int> RotateCoordinatesClockWise(List<Vector2Int> positions, int angleDegrees)
    {
        positions.ForEach(position => Debug.Log(position));
        List<Vector2Int> rotatedPositions = new List<Vector2Int>();
        for (int i = 0; i < angleDegrees / 90; i++)
        {
            foreach (Vector2Int position in positions)
            {
                Vector2Int rotatedPosition = new Vector2Int
                {
                    x = position.y,
                    y = -position.x
                };
                rotatedPositions.Add(rotatedPosition);
            }
        }
        rotatedPositions.ForEach(position => Debug.Log(position));
        return rotatedPositions;
    }

    public static List<Vector2Int> MirrorCoordinates(List<Vector2Int> positions)
    {
        positions.ForEach(position => Debug.Log(position));
        List<Vector2Int> mirrorPositions = new List<Vector2Int>();
        int maxWidth = positions[0].x;
        foreach (Vector2Int position in positions)
        {
            if (position.x > maxWidth)
            {
                maxWidth = position.x;
            }
        }

        foreach (Vector2Int position in positions)
        {
            Vector2Int mirrorPosition = new Vector2Int
            {
                x = -position.x + maxWidth,
                y = position.y
            };
            mirrorPositions.Add(mirrorPosition);
        }
        mirrorPositions.ForEach(position => Debug.Log(position));
        return mirrorPositions;
    }
}
