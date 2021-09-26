using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{

    [SerializeField] private Tilemap _groundTileMap;
    [SerializeField] private Tile _groundTile;


    public void DrawGroundTiles(HashSet<Vector2Int> tilePositionList)
    {
        ClearTileMap();
        foreach (var position in tilePositionList)
        {
            DrawTile(_groundTile, _groundTileMap, position);
        }

    }
    

    private void DrawTile(Tile tile,Tilemap tilemap,Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }


    public void ClearTileMap()
    {
        _groundTileMap.ClearAllTiles();
    }





}
