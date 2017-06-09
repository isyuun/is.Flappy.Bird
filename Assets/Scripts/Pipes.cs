using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : _MonoBehaviour
{
    private Vector3 org;

    private Vector3 pos;

    private float GAP_X;
    private float MIN_X;
    private float MAX_X;

    private const float GAP_LEVEL = 15.0f;
    private const float MIN_LEVEL = -50.0f;
    private const float MAX_LEVEL = 50.0f;

    private float MAX_Y;
    private float MIN_Y;

    public GameObject skys;
    public GameObject gounds;

    private Animator ani;

    void Reset()
    {
        GAP_X = GetTotalMeshFilterBounds(transform).size.x;
        MIN_X = 0.0f - GAP_X;
        MAX_X = GetTotalMeshFilterBounds(skys.transform).size.x + GAP_X;

        MIN_Y = MIN_LEVEL + GAP_LEVEL * 1.0f + GetTotalMeshFilterBounds(gounds.transform).size.y;
        MAX_Y = MAX_LEVEL - GAP_LEVEL * 1.0f;

        //Debug.LogWarning(this.GetMethodName() + "\t" + "MIN_X:" + MIN_X + ", MAX_X:" + MAX_X + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y);

        this.pos = this.org;
        //this.pos.x = MAX_X;
        this.pos.y = UnityEngine.Random.Range(MIN_Y, MAX_Y);
        transform.position = this.pos;

        //Debug.Log(this.GetMethodName() + ":" + this.pos);
    }

    // Use this for initialization
    void Start()
    {
        this.org = transform.position;
        this.ani = GetComponent<Animator>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Play)
        {
            return;
        }

        this.pos.x -= GameManager.SPEED_X;

        if (this.pos.x <= MIN_X)
        {
            this.pos.x = MAX_X;
            this.pos.y = UnityEngine.Random.Range(MIN_Y, MAX_Y);
            //v3Pos.y = MIN_Y;
        }

        transform.position = this.pos;
    }
}
