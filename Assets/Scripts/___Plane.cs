using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ___Plane : _MonoBehaviour
{
    protected Rigidbody rb;

    //gravity constants
    public const float GRAVITY_SCALE = 1.00f;
    public const float GRAVITY_ACCEL = 9.81f;
    public const float JUMP_FORCE = 140.0f;

    //actural gravity values
    private float g = GRAVITY_ACCEL * GRAVITY_SCALE;
    private float j = JUMP_FORCE * GRAVITY_SCALE;

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
        gravity.y = -g;
        Physics.gravity = gravity;
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.position = this.org;
        this.pos = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0))
        {
            this.v3 = transform.position;
            // 속도를 0으로 초기화
            rb.velocity = Vector2.zero;
            // 상승 힘을 부여
            rb.AddForce(Vector2.up * j);
            //Debug.LogWarning(this.GetMethodName() + ">>" + (transform.position.y - v3.y).ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        }

        this.delta = transform.position.y - pos.y;
        this.pos = transform.position;
    }
}
