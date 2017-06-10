using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : _MonoBehaviour
{
    private Vector3 org;

    private const float GRAVITY_ACCELATION = 9.8f;
    private const float GRAVITY_UNIT = 10.0f;
    private const float GRAVITY_DRAG = 0.5f;
    private const float GRAVITY_JUMP = 30.0f;

    private float v = 0.0f;
    private Vector3 pos;
    private float g = GRAVITY_ACCELATION * GRAVITY_UNIT;

    private float MIN_LEVEL = 0.2f;
    private float MAX_LEVEL = 1.0f;

    private SphereCollider bird;
    public GameObject skys;
    public GameObject gounds;


    protected float delta;

    private Rigidbody rb;

    protected virtual void Reset()
    {
        Debug.Log(this.GetMethodName());

        DisableRagdoll();

        bird = (SphereCollider)GetComponent<SphereCollider>();

        MIN_LEVEL = GetTotalMeshFilterBounds(gounds.transform).size.y + bird.radius;
        MAX_LEVEL = GetTotalMeshFilterBounds(skys.transform).size.y - bird.radius;

        //Debug.LogWarning(this.GetMethodName() + "\t" + "MIN_LEVEL:" + MIN_LEVEL + ", MAX_LEVEL:" + MAX_LEVEL/* + " - " + "MIN_Y:" + MIN_Y + ", MAX_Y:" + MAX_Y*/);

        transform.position = this.org;
        this.pos = transform.position;

        transform.rotation = Quaternion.identity;

        GameManager.Dead = false;

        GameObject.Find("bird2d").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites_73");
    }

    protected virtual void Die()
    {
        Debug.Log(this.GetMethodName());

        GameManager.Play = false;
        GameManager.Dead = true;
        DisableRagdoll();

        GameObject.Find("bird2d").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bird");
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

    protected virtual void PitchBird(float delta)
    {
        if ((this.delta * delta) < 0.0f)
        {
            transform.rotation = Quaternion.identity;
        }

        //set Rotate Speed
        float rotationSpeed = 200.0f;
        if (delta > 0.0f)
        {
            rotationSpeed *= 4;
        }

        //calculate pitch
        Vector3 pitch = Vector3.forward * delta * rotationSpeed * Time.deltaTime;

        //check rotation degrees
        Quaternion rotation = transform.rotation;
        Vector3 eulerAngles = transform.eulerAngles;
        float angle = 0.0f;
        Vector3 axis = Vector3.zero;
        transform.rotation.ToAngleAxis(out angle, out axis);

        //Debug.Log(this.GetMethodName() + ":" + delta.ToString("f4") + ":" + (angle * axis.z).ToString("f4")/* + ":" + rotation.z.ToString("f4")*/ + ":angle:" + angle + ":rotation:" + rotation + ":axis:" + axis + ":eulerAngles:" + eulerAngles);

        //make angle(+-)
        angle *= axis.z;

        if (!GameManager.Dead)
        {
            if ((angle > 35.0f || angle < -90.0f))
            {
                return;
            }
        }

        transform.Rotate(pitch);
    }

    // Use this for initialization
    protected virtual void Start()
    {
        this.org = transform.position;
        this.rb = GetComponent<Rigidbody>();
        Reset();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (GameManager.ActionKeyDown())
        {
            //Debug.LogWarning(this.GetMethodName() + "!!!START!!!\t" + (DateTime.Now - st).TotalMilliseconds);
            GameManager.Play = true;
        }

        if (!GameManager.Play && !GameManager.Dead)
        {
            return;
        }


        EnableRagdoll();

        float up = 0.0f;  // Upward force

        float t = Time.deltaTime;

        if (GameManager.ActionKeyDown())
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
        this.pos.y += delta;

        //when bird collide
        if (this.pos.y <= MIN_LEVEL)
        {
            this.pos.y = MIN_LEVEL;
            v = -v * GRAVITY_DRAG;
        }
        else if (this.pos.y >= MAX_LEVEL)
        {
            this.pos.y = MAX_LEVEL;
            v = -v * GRAVITY_DRAG;
        }

        if (GameManager.Dead)
        {
            this.pos.z = -10.0f;
        }

        transform.position = this.pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(this.GetMethodName() + ":" + collision.collider.tag);
        Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.GetMethodName() + ":" + other.tag);
    }
}
