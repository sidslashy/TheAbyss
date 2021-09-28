using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(AbstractTileMapGenerator),true)]
public class RandomDungeonGeneratorEditor : Editor
{
    private AbstractTileMapGenerator _generator;

    private void Awake()
    {
        Debug.Log("Awake!!");
        _generator = (AbstractTileMapGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Dungeon"))
        {
            _generator.GenerateDungeon();
        }

        if(GUILayout.Button("Clear Dungeon"))
        {
            _generator.ClearDungeon();
        }

    }
}
