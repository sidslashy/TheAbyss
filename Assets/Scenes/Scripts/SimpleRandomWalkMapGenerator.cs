using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkMapGenerator : AbstractTileMapGenerator
{
    [SerializeField] protected Vector2Int _startPosition = Vector2Int.zero;
    [SerializeField] private RandomWalkGeneratorSO _data;

    public void GenerateMap()
    {
        // TODO: Update the Wall Generator!! Maybe rework the architechture.
        var map = RunSimpleRandomWalk();
        _tileMapVisualizer.DrawGroundTiles(map);
        WallGenerator.GenerateWall(map,_tileMapVisualizer);
    }

    protected override void RunProceduralGeneration()
    {
        GenerateMap();
    }

    private HashSet<Vector2Int> RunSimpleRandomWalk()
    {
        var path = new HashSet<Vector2Int>();
        var startPosition = _startPosition;

        for (var i = 0; i < _data.NumIterations; i++)
        {
            var generatedPath = ProceduralGeneration.SimpleRandomWalk(startPosition, _data.WalkLength);
            path.UnionWith(generatedPath);
            if(_data.IsNewStartPositionPerIteration)
            {
                startPosition = path.ElementAt(Random.Range(0, path.Count));
            }
        }

        return path;
    }

}
