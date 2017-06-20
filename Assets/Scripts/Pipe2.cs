using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pipe(Top/Bottom) Vertical Position
/// </summary>
public class Pipe2 : Pipe
{
    Vector3 top;
    Vector3 bottom;

    protected override void Start()
    {
        this.top = GetChildGameObject(gameObject, "Top").transform.position;
        this.bottom = GetChildGameObject(gameObject, "Bottom").transform.position;
        base.Start();
    }

    protected override void _Reset()
    {
        //position reset
        GetChildGameObject(gameObject, "Top").transform.position = this.top;
        GetChildGameObject(gameObject, "Bottom").transform.position = this.bottom;

        //get empty
        Transform score = GetChildGameObject(gameObject, "Score").transform;
        Vector3 scale = score.localScale;
        scale.y = GameManager.PIPE_GAP;
        score.localScale = scale;

        //position calcurate
        float h = scale.y / 2.0f;
        Vector3 top = this.top;
        top.y += h;
        Vector3 bottom = this.bottom;
        bottom.y -= h;

        //position move
        GetChildGameObject(gameObject, "Top").transform.position = top;
        GetChildGameObject(gameObject, "Bottom").transform.position = bottom;

        base._Reset();
    }
}
