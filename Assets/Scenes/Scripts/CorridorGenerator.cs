using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorGenerator : AbstractTileMapGenerator
{
    [SerializeField] private RandomWalkGeneratorSO _data;

    public void GenerateMap()
    {
        // TODO: Update the Wall Generator!! Maybe rework the architechture.
        var map = RunCorridorGenerator();
        _tileMapVisualizer.DrawGroundTiles(map);
        WallGenerator.GenerateWall(map, _tileMapVisualizer);
    }

    protected override void RunProceduralGeneration()
    {
        GenerateMap();
    }

    private HashSet<Vector2Int> RunCorridorGenerator()
    {
        return ProceduralGeneration.CorridorGenerator(_startPosition, _data.WalkLength, _data.NumIterations);
    }

}
