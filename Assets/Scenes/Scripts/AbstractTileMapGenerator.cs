using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTileMapGenerator : MonoBehaviour
{
    [SerializeField] protected TileMapVisualizer _tileMapVisualizer;
    [SerializeField] protected Vector2Int _startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        _tileMapVisualizer.ClearTileMap();
        RunProceduralGeneration();
    }

    public void ClearDungeon()
    {
        _tileMapVisualizer.ClearTileMap();
    }


    protected abstract void RunProceduralGeneration();

}
