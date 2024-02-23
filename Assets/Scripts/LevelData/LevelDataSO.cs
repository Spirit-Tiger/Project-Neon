using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "LevelData")]
public class LevelDataSO : ScriptableObject
{
    public int Id;
    public string Name;
    public bool Opened;
    public bool Finished;
    public float Score;
    public float CompletionTime;
    public Vector3 StartingPosition;
}
