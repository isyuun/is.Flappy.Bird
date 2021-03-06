﻿using UnityEngine;

public class __Bird : _MonoBehaviour
{
    protected Rigidbody rb;

    //actural gravity values
    private float g = GameManager.GRAVITY_ACCEL * GameManager.GRAVITY_SCALE;
    private float j = GameManager.JUMP_FORCE * GameManager.GRAVITY_SCALE * 1.25f;

    protected float v = 0.0f;
    protected Vector3 pos;

    private Vector3 org;

    private float delta;
    private Vector3 v3;

    // Use this for initialization
    protected virtual void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.org = transform.position;
        _Reset();
    }

    protected virtual void _Reset()
    {
        Vector3 gravity = Physics.gravity;
        gravity.y = 0.0f;
        Physics.gravity = gravity;
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = this.org;
        this.pos = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float up = 0.0f;  // Upward force

        float t = Time.deltaTime;

        if (GameManager.ActionKeyDown())
        {
            //Debug.LogWarning(this.GetMethodName() + ">>" + (transform.position.y - v3.y).ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
            this.v3 = transform.position;
            v = 0.0f;
            //up = 8.0f;  // Apply some upward force
            up = j;
        }

        float d = v * t + (up - g) * t * t;
        v = v + (up - g) * t;
        this.pos.y += d;

        this.delta = pos.y - transform.position.y;
        transform.position = this.pos;

        PitchBird(this.delta);
    }

    protected virtual void PitchBird(float delta) { }
    protected virtual void Die(Collision collision) { }
}
