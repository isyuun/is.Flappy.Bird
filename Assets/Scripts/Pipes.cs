using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : _MonoBehaviour
{
    public GameObject skys;
    public GameObject grounds;

    Vector3 org;
    GameObject[] pipes;

    private void Awake()
    {
        if (this.skys == null)
        {
            this.skys = GameObject.Find("Skys");
        }
        if (this.grounds == null)
        {
            this.grounds = GameObject.Find("Grounds");
        }
        this.org = transform.position;
        pipes = GetChildsGameObject(gameObject, "Pipe");
        Move();
    }

    private void Move()
    {
        Vector3 org, pos;
        float max = GetTotalBoundsAll(grounds.transform).size.x;
        for (int i = 0; i < pipes.Length; i++)
        {
            float dis = GameManager.PIPE_DIS * (float)i;
            org = pos = pipes[i].transform.position;
            //move pipe
            pos.x = this.org.x + dis;
            Debug.Log(this.GetMethodName() + "[" + i + "]" + dis.ToString("f2") + ":" + org.x.ToString("f2") + "->" + pos.x.ToString("f2"));
            pipes[i].transform.position = pos;
            //disable pipe
            if (pipes[i].transform.position.x > max)
            {
                Debug.LogWarning(this.GetMethodName() + "[" + i + "]" + dis.ToString("f2") + ":" + org.x.ToString("f2") + "->" + pos.x.ToString("f2"));
                pipes[i].SetActive(false);
            }
        }
    }
}
