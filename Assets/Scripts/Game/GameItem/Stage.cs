using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int xSize { get; private set; }
    [SerializeField] private GameObject cube;
    public void RotateStage(int n, int max)
    {        
        if (max == 2 && n == 1)
        {
            xSize = Random.Range(8, 10);
        }
        else if(max == 2 && n == 0)
        {
            xSize = Random.Range(12, 16);
        }
        else
        {
            xSize = 10;
        }

        float rotateZ = 0;
        if(max == 2)
        {
            rotateZ = Random.Range(5, 10);
        }
        else
        {
            rotateZ = Random.Range(5, 20);
        }
        cube.transform.localPosition = new Vector3(-Mathf.Sign(this.gameObject.transform.position.x) * xSize / 2, 0, 0);
        cube.transform.localScale = new Vector3(xSize, 1, 1);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(this.gameObject.transform.position.x) * rotateZ);
    }
}
