using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public float timeGoal { get; set; }
    public float timeNow { get; set; }
    public int totalScore { get; set; }
}
