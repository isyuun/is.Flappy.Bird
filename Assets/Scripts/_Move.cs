using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Move : _MonoBehaviour
{
    public GameObject skys;

    private Vector3 org;
    protected Vector3 pos;

    private float GAP_X;
    protected float MIN_X;
    protected float MAX_X;

    protected virtual void _Reset()
    {
        //Debug.Log(this.GetMethodName());
        this.pos = transform.position = this.org;

        this.GAP_X = (GetTotalMeshFilterBounds(transform).size.x) / 2.0f;
        this.MIN_X = -(GetTotalMeshFilterBounds(transform).size.x) + this.GAP_X;
        this.MAX_X = (GetTotalMeshFilterBoundsAll(this.skys.transform).size.x) + this.GAP_X;

        //Debug.Log(this.GetMethodName() + "\t" + "this.pos.x:" + this.pos.x + ", MIN_X:" + MIN_X + ", MAX_X:" + MAX_X);
    }

    // Use this for initialization
    protected virtual void Start()
    {
        if (this.skys == null)
        {
            this.skys = GameObject.Find("Skys");
        }
        this.org = transform.position;
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
            //Debug.Log(this.GetMethodName() + "\t" + "this.pos.x:" + this.pos.x + ", MIN_X:" + MIN_X + ", MAX_X:" + MAX_X);
            this.pos.x = MAX_X;
        }

        transform.position = this.pos;
    }
}
