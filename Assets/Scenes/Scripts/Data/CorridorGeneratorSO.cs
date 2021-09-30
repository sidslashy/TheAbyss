using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "DungeonGeneratorConfig/Corridor", fileName = "Corr_")]
public class CorridorGeneratorSO : ScriptableObject
{
    [SerializeField] private int _numIterations;
    [SerializeField] private int _walkLenght;
   
    public int NumIterations => _numIterations;
    public int WalkLength => _walkLenght;
}
