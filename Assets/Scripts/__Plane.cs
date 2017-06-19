using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __Plane : _MonoBehaviour
{
    protected Rigidbody rb;

    public float _riseForce; // 점프 힘

    protected float v = 0.0f;
    protected Vector3 pos;

    private float delta;
    private Vector3 v3;

    protected virtual void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        _Reset();
    }

    protected virtual void _Reset()
    {
        _riseForce = 70.0f;
    }

    protected virtual void Update()
    {
        if (GameManager.ActionKeyDown())
        {
            this.v3 = transform.position;
            // 속도를 0으로 초기화
            rb.velocity = Vector2.zero;
            // 상승 힘을 부여
            rb.AddForce(Vector2.up * _riseForce);
            //Debug.LogWarning(this.GetMethodName() + ">>" + (transform.position.y - v3.y).ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        }

        float diff = (transform.position.y - this.v3.y);
        //Debug.Log(this.GetMethodName() + ":" + diff.ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
        if (this.v3 != Vector3.zero && diff > 0.0f && diff >= GameManager.MAX_JUMP)
        {
            //Debug.LogWarning(this.GetMethodName() + "]]" + diff.ToString("f4") + ":position.y:" + transform.position.y.ToString("f4") + ":v3.y:" + v3.y.ToString("f4"));
            this.v3 = Vector3.zero;
            rb.AddForce(Vector2.up * 0.0f);
        }

        this.delta = transform.position.y - pos.y;
        this.pos = transform.position;

        PitchBird(this.delta);
    }

    protected virtual void PitchBird(float delta) { }
}
