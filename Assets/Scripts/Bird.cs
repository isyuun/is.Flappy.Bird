using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// when bird collide top and bottom
/// </summary>
public class Bird : __Bird
{
    private float MAX_LEVEL = 1.0f;
    private float MIN_LEVEL = 0.2f;
    private float GRAVITY_DRAG = 0.5f;

    private SphereCollider bird;
    public GameObject skys;
    public GameObject grounds;

    protected override void _Reset()
    {
        //Debug.Log(this.GetMethodName() + ":" + skys + ":" + grounds);
        MAX_LEVEL = GetTotalBounds(this.skys.transform).size.y - (bird.radius * this.skys.transform.localScale.y);
        MIN_LEVEL = GetTotalBounds(this.grounds.transform).size.y + (bird.radius * this.grounds.transform.localScale.y);
        //Debug.LogWarning(this.GetMethodName() + "\t" + "MIN_LEVEL:" + MIN_LEVEL + ", MAX_LEVEL:" + MAX_LEVEL/* + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y*/);
        base._Reset();
    }

    protected override void Start()
    {
        if (this.skys == null)
        {
            this.skys = GameObject.Find("Skys");
        }
        if (this.grounds == null)
        {
            this.grounds = GameObject.Find("Grounds");
        }
        //Debug.Log(this.GetMethodName() + ":" + skys + ":" + grounds);
        bird = (SphereCollider)GetComponent<SphereCollider>();
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        //when bird collide bottom
        if (this.pos.y <= MIN_LEVEL)
        {
            //Debug.LogWarning(this.GetMethodName() + ":" + this.pos.y + ":MIN_LEVEL:" + MIN_LEVEL);
            this.pos.y = MIN_LEVEL;
            this.v = -this.v * GRAVITY_DRAG;
        }
        //when bird collide top
        else if (this.pos.y >= MAX_LEVEL)
        {
            //Debug.LogWarning(this.GetMethodName() + ":" + this.pos.y + ":MAX_LEVEL:" + MAX_LEVEL);
            this.pos.y = MAX_LEVEL;
            this.v = -this.v * GRAVITY_DRAG;
        }

        transform.position = this.pos;
    }
}
