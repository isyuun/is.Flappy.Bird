using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : _Move
{
    public GameObject gounds;

    private const float GAP_LEVEL = 15.0f;
    private const float MIN_LEVEL = -50.0f;
    private const float MAX_LEVEL = 50.0f;

    private float MAX_Y;
    private float MIN_Y;

    protected override void Reset()
    {
        //Debug.Log(this.GetMethodName());
        base.Reset();

        this.pos.y = UnityEngine.Random.Range(MIN_Y, MAX_Y);
        transform.position = this.pos;

        //Debug.Log(this.GetMethodName() + ":" + this.pos);
    }

    protected override void Start()
    {
        MIN_Y = MIN_LEVEL + GAP_LEVEL * 1.0f + GetTotalMeshFilterBounds(gounds.transform).size.y;
        MAX_Y = MAX_LEVEL - GAP_LEVEL * 1.0f;
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
