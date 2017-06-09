﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : _MonoBehaviour
{

    private Animator ani;

    private void StartAnim()
    {
        if (ani != null)
        {
            ani.Play("GroundsScroll");
            ani.SetBool("IsScroll", true);
        }
    }

    private void StopAnim()
    {
        if (ani != null)
        {
            ani.Play("idle");
            ani.SetBool("IsScroll", false);
        }
    }


    private void Reset()
    {
        StopAnim();
    }

    // Use this for initialization
    void Start()
    {
        ani = GetComponent<Animator>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Play)
        {
            StartAnim();
        }
        else
        {
            StopAnim();
        }
    }
}
