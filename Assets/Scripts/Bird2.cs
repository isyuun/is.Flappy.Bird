using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2 : Bird
{

    private Animator[] ani;

    private void StartAnim()
    {
        //Debug.Log(this.GetMethodName() + ":" + ani);
        foreach (Animator item in ani)
        {
            item.SetBool("IsFlappy", true);
        }
    }

    private void StopAnim()
    {
        //Debug.Log(this.GetMethodName() + ":" + ani);
        foreach (Animator item in ani)
        {
            item.SetBool("IsFlappy", false);
        }
    }

    protected override void PitchBird(float delta)
    {
        //Debug.Log(this.GetMethodName() + ":" + delta.ToString("f4"));
        if (delta > 0.0f)
        {
            StartAnim();
        }
        else
        {
            StopAnim();
        }
        if ((this.delta * delta) < 0.0f)
        {
            StopAnim();
        }
        base.PitchBird(delta);
    }

    protected override void Start()
    {
        ani = GetComponentsInChildren<Animator>();
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (!GameManager.Play /*|| collide*/)
        {
            return;
        }

        if (!ActionKeyDown())
        {
            StopAnim();
        }
    }
}
