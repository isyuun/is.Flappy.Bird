using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : _Move
{
    public GameObject grounds;

    private const float GAP_LEVEL = 20.0f;
    private const float MIN_LEVEL = -50.0f;
    private const float MAX_LEVEL = 50.0f;

    private float MAX_Y;
    private float MIN_Y;

    protected override void _Reset()
    {
        //Debug.Log(this.GetMethodName());
        base._Reset();

        MIN_Y = MIN_LEVEL + GAP_LEVEL + GetTotalMeshFilterBounds(grounds.transform).size.y;
        MAX_Y = MAX_LEVEL - GAP_LEVEL;

        this.pos.y = UnityEngine.Random.Range(MIN_Y, MAX_Y);

        transform.position = this.pos;

        //Debug.Log(this.GetMethodName() + "\t" + "this.pos.y:" + this.pos.y + ", MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y);
    }

    protected override void Start()
    {
        if (this.grounds == null)
        {
            this.grounds = GameObject.Find("Grounds");
        }
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (!GameManager.Play)
        {
            return;
        }

        if (this.pos.x == MAX_X)
        {
            this.pos.y = UnityEngine.Random.Range(MIN_Y, MAX_Y);
        }

        transform.position = this.pos;
    }
}
