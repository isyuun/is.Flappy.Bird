using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Move : _MonoBehaviour {
    public GameObject skys;

    protected Vector3 org;
    protected Vector3 pos;

    protected float GAP_X;
    protected float MIN_X;
    protected float MAX_X;

    protected virtual void _Reset()
    {
        //Debug.Log(this.GetMethodName());
        this.pos = transform.position = this.org;

        this.MIN_X = -(GetTotalMeshFilterBounds(transform).size.x / 2.0f);
        this.MAX_X = GetTotalMeshFilterBoundsAll(this.skys.transform).size.x + this.GAP_X;

        //Debug.Log(this.GetMethodName() + "\t" + "MIN_X:" + MIN_X + ", MAX_X:" + MAX_X + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y);
        //Debug.Log(this.GetMethodName() + ":" + this.pos);
    }

    // Use this for initialization
    protected virtual void Start()
    {
        this.org = transform.position;
        this.GAP_X = GetTotalMeshFilterBounds(transform).size.x / 2.0f;
        _Reset();
    }

    protected virtual void Update()
    {
        if (!GameManager.Play)
        {
            return;
        }

        this.pos.x -= GameManager.SPEED_X;

        if (this.pos.x <= MIN_X)
        {
            this.pos.x = MAX_X;
        }

        transform.position = this.pos;
    }
}
