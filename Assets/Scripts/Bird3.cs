using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TBD:Bitching Bird(???)
/// </summary>
public class Bird3 : Bird2
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
            this.pos.z = -0.1f;
        }
        else
        {
            DisableRagdoll();
            this.pos.z = 0.0f;
        }

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
        if (this is __Bird)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    /// <summary>
    /// use when dead
    /// </summary>
    void EnableRagdoll()
    {
        //Debug.Log(this.GetMethodName() + ":" + GameManager.Dead);
        rb.useGravity = true;
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
