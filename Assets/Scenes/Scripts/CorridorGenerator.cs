using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : AbstractTileMapGenerator
{
    [SerializeField] protected Vector2Int _startPosition = Vector2Int.zero;
    [SerializeField] private RandomWalkGeneratorSO _data;

    public void GenerateMap()
    {
        // TODO: Update the Wall Generator!! Maybe rework the architechture.
        var map = RunCorridorGenerator().CorridorTilePositions;
        _tileMapVisualizer.DrawGroundTiles(map);
        WallGenerator.GenerateWall(map, _tileMapVisualizer);
    }

    protected override void RunProceduralGeneration()
    {
        GenerateMap();
    }

    private CorridorGenData RunCorridorGenerator()
    {
        return ProceduralGeneration.CorridorGenerator(_startPosition, _data.WalkLength, _data.NumIterations);
    }

}
