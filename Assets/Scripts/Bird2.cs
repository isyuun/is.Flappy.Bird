using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pitch Bird
/// </summary>
public class Bird2 : Bird
{
    private float deltaTemp = 0.0f;

    protected override void _Reset()
    {
        //delta reset
        this.deltaTemp = 0.0f;
        //pitch reset
        transform.rotation = Quaternion.identity;
        base._Reset();
    }

    protected override void PitchBird(float delta)
    {
        if (GameManager.Dead)
        {
            return;
        }

        if ((this.deltaTemp * delta) < 0.0f)
        {
            //Debug.LogWarning(this.GetMethodName() + ":" + this.deltaTemp.ToString("f4") + ":" + delta.ToString("f4"));
            transform.rotation = Quaternion.identity;
        }
        deltaTemp = delta;

        //set Rotate Speed
        //delta *= 100.0f;
        float rotationSpeed = 200.0f * 100.0f;

        //calculate pitch
        Vector3 pitch = Vector3.forward * delta * rotationSpeed * Time.deltaTime;

        //check rotation degrees
        Quaternion rotation = transform.rotation;
        Vector3 eulerAngles = transform.eulerAngles;
        float angle = 0.0f;
        Vector3 axis = Vector3.zero;
        transform.rotation.ToAngleAxis(out angle, out axis);

        //Debug.Log(this.GetMethodName() + ":" + delta.ToString("f4") + ":" + (angle * axis.z).ToString("f4") + ":pitch:" + pitch/* + ":" + rotation.z.ToString("f4") + ":angle:" + angle + ":rotation:" + rotation + ":axis:" + axis + ":eulerAngles:" + eulerAngles*/);

        if (!GameManager.Dead)
        {
            if (((angle * axis.z) > 40.0f || (angle * axis.z) < -90.0f))
            {
                return;
            }
        }

        transform.Rotate(pitch);
    }

    Vector3 jumpStart;
    Vector3 jumpEnd;
    bool jump = false;

    protected override void Update()
    {
        base.Update();

        string TAG = "__Bird";
        if (this is __Plane)
        {
            TAG = "__Plane";
        }

        if (jump && jumpEnd.y > transform.position.y)
        {
            Debug.LogWarning(this.GetMethodName() + "[" + TAG + "]" + "[JUMP][ED][DIS]" + (jumpEnd.y - jumpStart.y).ToString("f2"));
            jump = false;
        }

        jumpEnd = transform.position;

        if (GameManager.ActionKeyDown())
        {
            jumpStart = transform.position;
            //Debug.LogWarning(this.GetMethodName() + "[" + TAG + "]" + "[JUMP][ST][POS]" + jumpStart.y.ToString("f2"));
            jump = true;
        }

    }
}
