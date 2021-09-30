using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="DungeonGeneratorConfig/RandomWalk", fileName ="RndWalk_")]
public class RandomWalkGeneratorSO : ScriptableObject
{
    public int WalkLength => _walkLength;
    public int NumIterations => _numIterations;
    public bool IsNewStartPositionPerIteration => _isNewStartPositionPerIteration;


    [SerializeField] private int _walkLength = 10;
    [SerializeField] private int _numIterations = 10;
    [SerializeField] private bool _isNewStartPositionPerIteration = true;

}
