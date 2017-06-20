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

        this.GAP_X = (GetTotalBounds(transform).size.x) / 2.0f;
        this.MIN_X = -(GetTotalBounds(transform).size.x) + this.GAP_X;
        this.MAX_X = (GetTotalBoundsAll(this.skys.transform).size.x) + this.GAP_X;

        //this.GAP_X = transform.lossyScale.x / 2.0f;
        //this.MIN_X = -transform.lossyScale.x + this.GAP_X;
        if (this.GAP_X == 0.0f)
        {
            Debug.LogWarning(this.GetMethodName() + "\t" + "this.pos.x:" + this.pos.x + ", GAP_X:" + GAP_X + ", MIN_X:" + MIN_X + ", MAX_X:" + MAX_X);
        }
        else
        {
            //Debug.Log(this.GetMethodName() + "\t" + "this.pos.x:" + this.pos.x + ", GAP_X:" + GAP_X + ", MIN_X:" + MIN_X + ", MAX_X:" + MAX_X);
        }
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

        //v.1
        //Vector3 pos = Vector3.left * 0.25f * Time.deltaTime;
        //transform.Translate(pos);
        //this.pos = transform.position;
        //v.2
        this.pos.x -= GameManager.SPEED_X;
        //max check
        if (this.pos.x <= MIN_X)
        {
            //Debug.Log(this.GetMethodName() + "\t" + "this.pos.x:" + this.pos.x + ", MIN_X:" + MIN_X + ", MAX_X:" + MAX_X);
            this.pos.x = MAX_X - 0.01f;
        }
        transform.position = this.pos;
    }
}
