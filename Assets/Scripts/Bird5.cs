using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animating Bird
/// </summary>
public class Bird5 : Bird4
{
    private Animator[] ani;

    private void AniStart()
    {
        //Debug.Log(this.GetMethodName() + ":" + ani);
        foreach (Animator item in ani)
        {
            item.Play("flap");
            item.SetBool("IsFlappy", true);
        }
    }

    private void AniStop()
    {
        //Debug.Log(this.GetMethodName() + ":" + ani);
        foreach (Animator item in ani)
        {
            item.Play("idle");
            item.SetBool("IsFlappy", false);
        }
    }

    private void AniSpeedUP()
    {
        foreach (Animator item in ani)
        {
            item.speed = 1.2f;
        }
    }

    private void AniSpeedDOWN()
    {
        foreach (Animator item in ani)
        {
            item.speed = 1.0f;
        }
    }

    protected override void Die(Collision collision)
    {
        base.Die(collision);
        AniStop();
    }

    protected override void PitchBird(float delta)
    {
        //Debug.Log(this.GetMethodName() + ":" + delta.ToString("f4"));
        if (!GameManager.Dead)
        {
            if (delta > 0.0f)
            {
                AniStart();
            }
            else
            {
                AniStop();
            }
        }
        base.PitchBird(delta);
    }

    protected override void Start()
    {
        ani = GetComponentsInChildren<Animator>();
        base.Start();
    }

    protected override void _Reset()
    {
        base._Reset();
        AniStart();
    }

    protected override void Update()
    {
        base.Update();

        if (!GameManager.Play && !GameManager.Dead)
        {
            return;
        }

        if (!GameManager.Dead)
        {
            if (GameManager.ActionKeyDown())
            {
                AniSpeedUP();
            }
            else
            {
                AniSpeedDOWN();
            }
        }
    }
}
