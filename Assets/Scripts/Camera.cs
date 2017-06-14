using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : _MonoBehaviour
{
    Vector3 org = Vector3.zero;

    private void _Reset()
    {
        //Debug.Log(this.GetMethodName() + transform.position);
        //transform.position = this.org;
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log(this.GetMethodName() + transform.position);
        this.org = Vector3.zero;
        org.z = -100;
        _Reset();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
