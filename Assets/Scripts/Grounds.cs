using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : _MonoBehaviour
{

    private Animator ani;

    private void StartAnim()
    {
        if (ani != null)
        {
            ani.SetBool("IsScroll", true);
        }
    }

    private void StopAnim()
    {
        if (ani != null)
        {
            ani.SetBool("IsScroll", false);
        }
    }


    private void Reset()
    {

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
        //test
        if (GameManager.Test && Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }

        if (!GameManager.Play)
        {
            return;
        }

        StartAnim();
    }
}
