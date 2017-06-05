using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : _MonoBehaviour
{
    private Vector3 pos;

    private Vector3 v3Pos;

    private float MIN_X = 0.0f;
    private float MAX_X = 0.0f;

    void Reset()
    {
        MIN_X = -transform.localScale.x / 2.0f;
        MAX_X = transform.localScale.x * 1.5f - 1.0f;

        //Debug.LogWarning(this.GetMethodName() + "\t" + "MIN_X:" + MIN_X + ", MAX_X:" + MAX_X/* + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y*/);

        transform.position = pos;
        v3Pos = transform.position;
    }

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (GameManager.Test && Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }

        if (!GameManager.Play)
        {
            return;
        }

        //Debug.LogWarning(this.GetMethodName() + "\t" + "v3Pos.x:" + v3Pos.x + ", transform.position.x" + transform.position.x);

        v3Pos.x -= GameManager.SPEED_X;

        if (v3Pos.x <= MIN_X)
        {
            v3Pos.x = MAX_X;
        }

        transform.position = v3Pos;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(this.GetMethodName() + collision.collider.tag);
    //}
}
