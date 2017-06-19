﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TBD:Bitching Bird(???)
/// </summary>
public class Bird2 : Bird
{
    private SpriteRenderer rd;

    protected override void Start()
    {
        this.rd = GameObject.Find("bird2d").GetComponent<SpriteRenderer>();
        base.Start();
    }


    protected override void _Reset()
    {
        base._Reset();

        //pitch reset
        transform.rotation = Quaternion.identity;

        //to stay in sky
        this.rb.isKinematic = true;

        //dont strange turn
        this.rb.constraints = RigidbodyConstraints.None;
        this.rb.constraints |= RigidbodyConstraints.FreezePositionX;
        this.rb.constraints |= RigidbodyConstraints.FreezePositionZ;
        this.rb.constraints |= RigidbodyConstraints.FreezeRotationX;
        this.rb.constraints |= RigidbodyConstraints.FreezeRotationY;
        //this.rb.constraints |= RigidbodyConstraints.FreezeRotationZ;


        //set default sprite
        SetBirdSprite(GameManager.sprites["sprites_73"]);


        GameManager.Dead = false;
    }

    protected override void Update()
    {
        if (GameManager.ActionKeyDown())
        {
            GameManager.Play = true;
        }

        if (!GameManager.Play && !GameManager.Dead)
        {
            return;
        }

        if (GameManager.Dead)
        {
            EnableRagdoll();
            //this.pos.z = -10.0f;
        }
        else
        {
            DisableRagdoll();
            //this.pos.z = 0.0f;
        }

        PitchBird(this.delta);

        base.Update();
    }

    // vertical flip
    private void Flip()
    {
        //Debug.Log(this.GetMethodName());
        transform.rotation = Quaternion.identity;
        Vector3 scale = transform.localScale;
        scale.y = scale.y * (-1);
        transform.localScale = scale;
    }

    /// <summary>
    /// use when live
    /// </summary>
    void DisableRagdoll()
    {
        //Debug.Log(this.GetMethodName() + ":" + GameManager.Dead);
        rb.useGravity = false;
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    /// <summary>
    /// use when dead
    /// </summary>
    void EnableRagdoll()
    {
        //Debug.Log(this.GetMethodName() + ":" + GameManager.Dead);
        rb.useGravity = false;
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    private void SetBirdSprite(Sprite sprite)
    {
        //Debug.Log(this.GetMethodName() + ":" + rd + ":" + sprite);
        rd.sprite = sprite;
    }

    protected virtual void Die(Collision collision)
    {
        if (GameManager.Dead)
        {
            return;
        }

        //Debug.LogWarning(this.GetMethodName() + ":" + collision + ":" + collision.collider + ":" + collision.collider.tag);

        //test
        EnableRagdoll(); return;

        GameManager.Play = false;
        GameManager.Dead = true;

        Flip();

        SetBirdSprite(Resources.Load<Sprite>("Splites/bird"));
    }

    protected virtual void PitchBird(float delta)
    {
        if (GameManager.Dead)
        {
            return;
        }

        //if ((this.delta * delta) < 0.0f)
        //{
        //    transform.rotation = Quaternion.identity;
        //}

        //set Rotate Speed
        //delta *= 100.0f;
        float rotationSpeed = 200.0f;
        if (delta < 0.0f)
        {
            Debug.LogWarning(this.GetMethodName() + ":" + delta.ToString("f4"));
            transform.rotation = Quaternion.identity;
        }

        //calculate pitch
        Vector3 pitch = Vector3.forward * delta * rotationSpeed * Time.deltaTime * 100.0f;

        //check rotation degrees
        Quaternion rotation = transform.rotation;
        Vector3 eulerAngles = transform.eulerAngles;
        float angle = 0.0f;
        Vector3 axis = Vector3.zero;
        transform.rotation.ToAngleAxis(out angle, out axis);

        Debug.Log(this.GetMethodName() + ":" + delta.ToString("f4") + ":" + (angle * axis.z).ToString("f4") + ":pitch:" + pitch/* + ":" + rotation.z.ToString("f4") + ":angle:" + angle + ":rotation:" + rotation + ":axis:" + axis + ":eulerAngles:" + eulerAngles*/);

        if (!GameManager.Dead)
        {
            if (((angle * axis.z) > 35.0f/* || (angle * axis.z) < -90.0f*/))
            {
                return;
            }
        }

        transform.Rotate(pitch);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(this.GetMethodName() + ":" + collision.collider.tag);
        Die(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.GetMethodName() + ":" + other.tag);
    }
}
