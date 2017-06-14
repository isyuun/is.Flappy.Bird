using System;
using UnityEngine;

public class __Bird : _MonoBehaviour
{
    private Vector3 org;

    private const float GRAVITY_SCALE = 12.0f;
    private const float GRAVITY_ACCELATION = 9.8f;
    private const float GRAVITY_JUMP_FORCE = 200.0f;

    private float g = GRAVITY_ACCELATION * GRAVITY_SCALE;

    private float v = 0.0f;
    private Vector3 pos;

    protected float delta;

    // Use this for initialization
    protected virtual void Start()
    {
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
            v = 0.0f;
            //up = 8.0f;  // Apply some upward force
            up = GRAVITY_JUMP_FORCE * GRAVITY_SCALE * 1.5f;
        }

        this.delta = v * t + (up - g) * t * t;
        v = v + (up - g) * t;
        this.pos.y += this.delta;

        if (GameManager.Dead)
        {
            this.pos.z = -10.0f;
        }

        transform.position = this.pos;
    }
}
