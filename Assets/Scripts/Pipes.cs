using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : _MonoBehaviour
{
    public GameObject skys;
    public GameObject grounds;

    Vector3 org;
    GameObject[] pipes;

    private void Start()
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
        _Reset();
    }

    private void _Reset()
    {
        float max = GetTotalBoundsAll(grounds.transform).size.x;
        float gap = GameManager.PIPE_GAP;
        for (int i = 0; i < pipes.Length; i++)
        {
            Vector3 pos = pipes[i].transform.position;
            pos.x = this.org.x + (gap * (float)i);
            Debug.Log(this.GetMethodName() + "[" + i + "]" + (gap * (float)i).ToString("f2") + ":" + pipes[i].transform.position.x.ToString("f2") + "->" + pos.x.ToString("f2"));
            //pipes[i].transform.position = pos;
            pipes[i].GetComponent<_Move>().SetXPos(pos.x);
            if (pipes[i].transform.position.x > max)
            {
                //Debug.LogWarning(this.GetMethodName() + "[" + i + "]" + (gap * (float)i).ToString("f2") + ":" + pipes[i].transform.position.x.ToString("f2") + "->" + pos.x.ToString("f2"));
                pipes[i].SetActive(false);
            }
        }
    }
}
