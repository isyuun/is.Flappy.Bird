using System;
using UnityEngine;

public class __Bird : _MonoBehaviour
{
    protected Rigidbody rb;

    private Vector3 org;

    private const float GRAVITY_SCALE = 0.5f;
    private const float GRAVITY_ACCELATION = 9.8f;
    private const float GRAVITY_JUMP_FORCE = 150.0f;

    private float g = GRAVITY_ACCELATION * GRAVITY_SCALE;

    protected float v = 0.0f;
    protected Vector3 pos;

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
            up = GRAVITY_JUMP_FORCE * GRAVITY_SCALE;
        }

        float diff = (transform.position.y - this.v3.y);
        //Debug.Log(this.GetMethodName() + ":" + diff.ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        if (this.v3 != Vector3.zero && diff > 0.0f && diff >= GameManager.MAX_JUMP)
        {
            //Debug.LogWarning(this.GetMethodName() + "]]" + diff.ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
            this.v3 = Vector3.zero;
            up = 0.0f;
        }

        float d = v * t + (up - g) * t * t;
        v = v + (up - g) * t;
        this.pos.y += d;

        this.delta = pos.y - transform.position.y;
        transform.position = this.pos;

        PitchBird(this.delta);
    }

    protected virtual void PitchBird(float delta)
    {
    }
}
