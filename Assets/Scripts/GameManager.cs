using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : _MonoBehaviour {
    private const double MSC2SEC = 1000;
    private const int COUNT_DOWN = 1;

    public static float SPEED_X = 0.55f;
    public static bool Play { get; set; }

    private static DateTime st;

    private void Awake()
    {
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
        if (GameManager.ResetKeyDown())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        if ((DateTime.Now - st).TotalMilliseconds < COUNT_DOWN * MSC2SEC)
        {
            //Debug.Log(this.GetMethodName() + "\t" + (DateTime.Now - st).TotalMilliseconds);
            return;
        }

        if (GameManager.ActionKeyDown())
        {
            //Debug.LogWarning(this.GetMethodName() + "!!!START!!!\t" + (DateTime.Now - st).TotalMilliseconds);
            GameManager.Play = true;
        }
    }

    public static bool ResetKeyDown()
    {
        return (!GameManager.Play && Input.GetKeyDown(KeyCode.Space));
    }


    public static bool ActionKeyDown()
    {
        //return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetMouseButton(0); //test
        return Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0);
    }
}
