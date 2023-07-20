using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public float timeTarget { get; set; }
    public float timeGoal { get; set; }
    public float timeNow { get; set; }
    public int totalScore { get; set; }
    public int stage { get; set; }
    public bool isSuccess { get; set; }
    public bool isFall { get; set; }

    public bool canAccele { get; set; }
    public bool canBreak { get; set; }

    public const float DISPLAYTIME = 0.5f; //ボールの演出時間
}
