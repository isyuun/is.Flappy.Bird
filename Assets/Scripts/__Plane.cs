using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __Plane : _MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public float _riseForce; // 점프 힘

    protected virtual void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        _Reset();
    }

    protected virtual void _Reset()
    {
        _riseForce = 3000.0f;
    }

    protected virtual void Update()
    {
        if (GameManager.ActionKeyDown())
        {
            // 속도를 0으로 초기화
            rb.velocity = Vector2.zero;

            // 상승 힘을 부여
            rb.AddForce(Vector2.up * _riseForce);
        }
    }
}
