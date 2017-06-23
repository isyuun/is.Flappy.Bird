using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ___Bird : _MonoBehaviour
{
    protected Rigidbody rb;

    //gravity constants
    public const float GRAVITY_SCALE = 1.00f;
    public const float GRAVITY_ACCEL = 9.81f;
    public const float JUMP_FORCE = 140.0f;

    //actural gravity values
    private float g = GRAVITY_ACCEL * GRAVITY_SCALE;
    private float j = JUMP_FORCE * GRAVITY_SCALE * 1.25f;

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

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0))
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
    }
}
