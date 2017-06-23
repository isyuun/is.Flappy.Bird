using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ___FreeFall : MonoBehaviour
{
    private float v = 0.0f;
    private Vector3 pos;
    private float g = 9.8f / 2.0f;

    void Start()
    {
        this.pos = transform.position;
    }

    // deltaY = Vprev*t - 1/2*g*(t*t)
    // deltaV = -g*t

    void Update()
    {
        float up = 0.0f;  // Upward force

        if (Input.anyKeyDown)
        {
            up = 8.0f;  // Apply some upward force
            Debug.Log("Down");
        }

        float t = Time.deltaTime;
        float delta = v * t + (up - g) * t * t * 0.5f;
        v = v + (up - g) * t;
        this.pos.y += delta;
        if (this.pos.y < 0.0f)
        {
            this.pos.y = 0.0f;
            v = -v * .8f;
        }
        transform.position = this.pos;

    }
}
