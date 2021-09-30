using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneration
{
    // TODO: Make this static class a service class once Zenject is integrated...
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        var path = new HashSet<Vector2Int>();

        var currentPosition = startPosition;
        path.Add(startPosition);

        for (var i = 0; i < walkLength; i++)
        {
            var nextPosition = currentPosition + Direction2D.GetRandomDirection();
            path.Add(nextPosition);
            currentPosition = nextPosition;
        }

        return path;
    }



    public static CorridorGenData CorridorGenerator(Vector2Int startPosition, int walkLength, int iterations)
    {
        var corridorData = new CorridorGenData();
     
        var path = new HashSet<Vector2Int>();
        var corridorStartPosition = new List<Vector2Int>();

        var currentPosition = startPosition;
        path.Add(startPosition);
        corridorStartPosition.Add(startPosition);

        for (var i = 0; i < iterations; i++)
        {
            var walkPath = new HashSet<Vector2Int>();
            var direction = Direction2D.GetRandomDirection();
            for (var j = 0; j < walkLength; j++)
            {
                var nextPosition = currentPosition + direction;
                walkPath.Add(nextPosition);
                currentPosition = nextPosition;
            }
            corridorStartPosition.Add(currentPosition);
            path.UnionWith(walkPath);
        }
        corridorData.CorridorTilePositions = path;
        corridorData.CorridorStartPositions = corridorStartPosition;

        return corridorData;

    }
}



public static class Direction2D
{
    public static List<Vector2Int> _directions = new List<Vector2Int>()
    {
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.up,
        Vector2Int.down
    };

    public static Vector2Int GetRandomDirection()
    {
        return _directions[(int)Random.Range(0, _directions.Count)];
    }
}
