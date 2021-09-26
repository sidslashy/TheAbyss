using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkMapGenerator : AbstractTileMapGenerator
{
    [SerializeField] private int _numIterations = 10;
    [SerializeField] private int _walkLength = 10;

    //[SerializeField] private Vector2Int _startPosition = Vector2Int.zero;

   // [SerializeField] private TileMapVisualizer _tileMapVisualizer;

    //private HashSet<Vector2Int> _map = new HashSet<Vector2Int>();

    public void GenerateMap()
    {
        var map = RunSimpleRandomWalk();
        //foreach (var item in map)
        //{
        //    print(item);
        //}
        _tileMapVisualizer.DrawGroundTiles(map);
    }

    protected override void RunProceduralGeneration()
    {
        GenerateMap();
    }

    private HashSet<Vector2Int> RunSimpleRandomWalk()
    {
        var path = new HashSet<Vector2Int>();
        var startPosition = _startPosition;

        for (var i = 0; i < _numIterations; i++)
        {
            var generatedPath = ProceduralGeneration.SimpleRandomWalk(startPosition, _walkLength);
            path.UnionWith(generatedPath);
            startPosition = path.ElementAt(Random.Range(0, path.Count));

        }

        return path;
    }

}
