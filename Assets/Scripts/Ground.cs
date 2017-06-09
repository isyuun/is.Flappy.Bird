using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : _MonoBehaviour
{
    private Vector3 org;

    private Vector3 pos;

    private float MIN_X = 0.0f;
    private float MAX_X = 0.0f;

    void Reset()
    {
        MIN_X = -transform.localScale.x / 2.0f;
        MAX_X = transform.localScale.x * 1.5f - 1.0f;

        //Debug.LogWarning(this.GetMethodName() + "\t" + "MIN_X:" + MIN_X + ", MAX_X:" + MAX_X/* + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y*/);

        transform.position = this.org;
        this.pos = transform.position;
    }

    // Use this for initialization
    void Start()
    {
        this.org = transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Play)
        {
            return;
        }

        //Debug.LogWarning(this.GetMethodName() + "\t" + "v3Pos.x:" + v3Pos.x + ", transform.position.x" + transform.position.x);

        this.pos.x -= GameManager.SPEED_X;

        if (this.pos.x <= MIN_X)
        {
            this.pos.x = MAX_X;
        }

        transform.position = this.pos;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(this.GetMethodName() + collision.collider.tag);
    //}
}
