using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTileMapGenerator : MonoBehaviour
{
    [SerializeField] protected TileMapVisualizer _tileMapVisualizer;
    

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
