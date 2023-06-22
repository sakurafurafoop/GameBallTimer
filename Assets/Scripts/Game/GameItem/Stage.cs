using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int xSize { get; private set; }
    public void RotateStage()
    {
        xSize = 10;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(5, 20));
    }
}
