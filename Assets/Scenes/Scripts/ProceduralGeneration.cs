using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneration
{
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



    public static HashSet<Vector2Int> CorridorGenerator(Vector2Int startPosition, int walkLength, int iterations)
    {
        var path = new HashSet<Vector2Int>();

        var currentPosition = startPosition;
        path.Add(startPosition);

        for(var i = 0; i < iterations; i++)
        {
            var walkPath = new HashSet<Vector2Int>();
            var direction = Direction2D.GetRandomDirection();
            for (var j = 0; j < walkLength; j++)
            {
                var nextPosition = currentPosition + direction;
                walkPath.Add(nextPosition);
                currentPosition = nextPosition;
            }
            path.UnionWith(walkPath);
        }
        

        return path;

    }
}



public static class Direction2D
{
    public static List<Vector2Int> _directions = new List<Vector2Int>()
    {
        new Vector2Int(1,0),
        new Vector2Int(0,1),
        new Vector2Int(-1,0),
        new Vector2Int(0,-1)
    };

    public static Vector2Int GetRandomDirection()
    {
        return _directions[(int)Random.Range(0, _directions.Count)];
    }
}
