using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : _MonoBehaviour
{
    private Vector3 pos;

    private const float GRAVITY_ACCELATION = 9.8f;
    private const float GRAVITY_UNIT = 10.0f;
    private const float GRAVITY_DRAG = 0.5f;
    private const float GRAVITY_JUMP = 30.0f;

    private float v = 0.0f;
    private Vector3 v3Pos;
    private float g = GRAVITY_ACCELATION * GRAVITY_UNIT;

    private float MIN_LEVEL = 0.2f;
    private float MAX_LEVEL = 1.0f;

    private SphereCollider bird;
    public GameObject skys;
    public GameObject gounds;


    private bool collide = false;
    private float delta;

    public Rigidbody rb;

    void Reset()
    {
        DisableRagdoll();

        bird = (SphereCollider)GetComponent<SphereCollider>();

        MIN_LEVEL = GetTotalMeshFilterBounds(gounds.transform).size.y + bird.radius;
        MAX_LEVEL = GetTotalMeshFilterBounds(skys.transform).size.y - bird.radius;

        //Debug.LogWarning(this.GetMethodName() + "\t" + "MIN_LEVEL:" + MIN_LEVEL + ", MAX_LEVEL:" + MAX_LEVEL/* + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y*/);

        transform.position = pos;
        v3Pos = transform.position;

        transform.rotation = Quaternion.identity;

        collide = false;
    }

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        Reset();
    }

    void EnableRagdoll()
    {
        if (rb != null && rb.isKinematic) rb.isKinematic = false;
        if (rb != null && !rb.detectCollisions) rb.detectCollisions = true;
    }

    void DisableRagdoll()
    {
        if (rb != null && !rb.isKinematic) rb.isKinematic = true;
        if (rb != null && rb.detectCollisions) rb.detectCollisions = false;
    }

    void PitchBird(float delta)
    {
        if ((this.delta * delta) < 0.0f)
        {
            transform.rotation = Quaternion.identity;
        }

        //set Rotate Speed
        float rotationSpeed = 200.0f;
        if (delta > 0.0f)
        {
            rotationSpeed *= 2;
        }

        //calculate pitch
        Vector3 pitch = Vector3.forward * delta * rotationSpeed * Time.deltaTime;

        //check rotation degrees
        Quaternion rotation = transform.rotation;
        Vector3 eulerAngles = transform.eulerAngles;
        float angle = 0.0f;
        Vector3 axis = Vector3.zero;
        transform.rotation.ToAngleAxis(out angle, out axis);
        Debug.Log(this.GetMethodName() + ":" + delta.ToString("f4") + ":" + rotation.z.ToString("f4") + ":angle:" + angle + ":" + (angle * axis.z) + ":rotation:" + rotation + ":axis:" + axis + ":eulerAngles:" + eulerAngles);
        //if ((delta > 0.0f && rotation.z > 0.3f) || (delta < 0.0f && rotation.z < -0.7f))
        if ((angle * axis.z) > 30.0f || (angle * axis.z) < -90.0f)
        {
            return;
        }
        transform.Rotate(pitch);
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (GameManager.Test && Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }

        if (!GameManager.Play /*|| collide*/)
        {
            return;
        }

        //EnableRagdoll();

        float up = 0.0f;  // Upward force

        float t = Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetMouseButton(0))    //test
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetMouseButtonDown(0))
        {
            up = 8.0f;  // Apply some upward force
            v = 0.0f;
            up = g * GRAVITY_JUMP;
            //Debug.Log("Down");
        }

        float delta = v * t + (up - g) * t * t * GRAVITY_DRAG;
        PitchBird(delta);
        this.delta = delta;

        //define bird position
        v = v + (up - g) * t;
        v3Pos.y += delta;

        //when bird collide
        if (v3Pos.y <= MIN_LEVEL)
        {
            v3Pos.y = MIN_LEVEL;
            v = -v * GRAVITY_DRAG;
            //v = 0.0f;
        }
        else if (v3Pos.y >= MAX_LEVEL)
        {
            v3Pos.y = MAX_LEVEL;
            v = -v * GRAVITY_DRAG;
            //v = 0.0f;
        }

        transform.position = v3Pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.GetMethodName() + ":" + collision.collider.tag);
        collide = true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(this.GetMethodName() + ":" + other.tag);
    //}
}
