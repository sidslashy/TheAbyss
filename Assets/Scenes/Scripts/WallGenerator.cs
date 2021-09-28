using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{ 
    public static void GenerateWall(HashSet<Vector2Int> floorPositions , TileMapVisualizer tileMapVisualizer)
    {
        var wallPositions = GetWallPositions(floorPositions);
        tileMapVisualizer.DrawWallTiles(wallPositions);
    }

    public static HashSet<Vector2Int> GetWallPositions(HashSet<Vector2Int> floorPositions)
    {
        var wallPositions = new HashSet<Vector2Int>();
        var directions = Direction2D._directions;


        foreach (var position in floorPositions)
        {
            foreach (var direction in directions)
            {
                var neighbour = position + direction;
                if(!floorPositions.Contains(neighbour))
                {
                    wallPositions.Add(neighbour);
                }
            }
        }
        
        return wallPositions;
    }
}
