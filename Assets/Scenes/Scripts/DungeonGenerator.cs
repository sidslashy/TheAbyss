using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : AbstractTileMapGenerator
{
    [SerializeField] protected Vector2Int _startPosition = Vector2Int.zero;
    [SerializeField][Range(0,1f)] protected float _roomGenFactor = 0.8f;

    [SerializeField] private RandomWalkGeneratorSO _randomWalkSO;
    [SerializeField] private CorridorGeneratorSO _corridorGeneratorSO;

    protected override void RunProceduralGeneration()
    {
        var map = new HashSet<Vector2Int>();
        // throw new System.NotImplementedException();
        var corridorData = RunCorridorGenerator();

        map.UnionWith(corridorData.CorridorTilePositions);
        var roomPositions = corridorData.CorridorStartPositions;
        var roomsCount = (int)(roomPositions.Count * _roomGenFactor);

        var roomPositionList = roomPositions.OrderBy(x => Guid.NewGuid()).Take(roomsCount).ToList();


        foreach (var position in roomPositionList)
        {
            var roomMap = RunSimpleRandomWalk(position);
            map.UnionWith(roomMap);
        }

        _tileMapVisualizer.DrawGroundTiles(map);
        WallGenerator.GenerateWall(map, _tileMapVisualizer);



    }


    private HashSet<Vector2Int> RunSimpleRandomWalk(Vector2Int startPosition)
    {
        var path = new HashSet<Vector2Int>();

        for (var i = 0; i < _randomWalkSO.NumIterations; i++)
        {
            var generatedPath = ProceduralGeneration.SimpleRandomWalk(startPosition, _randomWalkSO.WalkLength);
            path.UnionWith(generatedPath);
            if (_randomWalkSO.IsNewStartPositionPerIteration)
            {
                startPosition = path.ElementAt(Random.Range(0, path.Count));
            }
        }
        return path;
    }

    private CorridorGenData RunCorridorGenerator()
    {
        return ProceduralGeneration.CorridorGenerator(_startPosition, _corridorGeneratorSO.WalkLength, _corridorGeneratorSO.NumIterations);
    }



}
