﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : _MonoBehaviour
{
    private const double MSC2SEC = 1000;
    private const int COUNT_DOWN = 1;

    public static float SPEED_X = 0.005f;
    public static bool Play { get; set; }
    public static bool Dead { get; set; }
    public static float MAX_JUMP = 0.1f;

    private static DateTime st;

    public static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    private void Awake()
    {
        foreach (Sprite item in Resources.LoadAll<Sprite>("Sprites/sprites"))
        {
            try
            {
                sprites.Add(item.name, item);

            }
            catch (Exception)
            {
                //throw;
            }
        }
    }

    private void _Reset()
    {
        //Debug.Log(this.GetMethodName());
        Play = false;
        st = DateTime.Now;
    }


    // Use this for initialization
    void Start()
    {
        _Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.ResetKeyDown())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        if ((DateTime.Now - st).TotalMilliseconds < COUNT_DOWN * MSC2SEC)
        {
            //Debug.Log(this.GetMethodName() + "\t" + (DateTime.Now - GameManager.st).TotalMilliseconds);
            return;
        }

        if (GameManager.ActionKeyDown())
        {
            //Debug.LogWarning(this.GetMethodName() + "!!!START!!!\t" + (DateTime.Now - GameManager.st).TotalMilliseconds);
            GameManager.Play = true;
        }
    }

    public static bool ResetKeyDown()
    {
        //Debug.Log("ResetKeyDown()" + ":" + (Input.GetKeyDown(KeyCode.Space)));
        return (Input.GetKeyDown(KeyCode.Space));
    }


    public static bool ActionKeyDown()
    {
        //test
        //return !GameManager.Dead && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetMouseButton(0));
        return !GameManager.Dead && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0));
    }
}
