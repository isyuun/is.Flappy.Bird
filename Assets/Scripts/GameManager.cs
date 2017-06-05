using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : _MonoBehaviour {
    private const double MSC2SEC = 1000;
    private const int COUNT_DOWN = 2;

    public static float SPEED_X = 0.55f;
    public static bool Play { get; private set; }

    private static DateTime st;

    public static bool Test { get; private set; }

    private void Awake()
    {
        Test = true;
    }

    private void Reset()
    {
        Play = false;
        st = DateTime.Now;
    }

    
    // Use this for initialization
    void Start () {
        Reset();
    }

    // Update is called once per frame
    void Update () {
        //test
        if (GameManager.Test && Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }

        if ((DateTime.Now - st).TotalMilliseconds < COUNT_DOWN * MSC2SEC)
        {
            //Debug.Log(this.GetMethodName() + "\t" + (DateTime.Now - st).TotalMilliseconds);
            return;
        }

        if (!Play)
        {
            //Debug.LogWarning(this.GetMethodName() + "!!!START!!!\t" + (DateTime.Now - st).TotalMilliseconds);
            Play = true;
        }
    }

}
