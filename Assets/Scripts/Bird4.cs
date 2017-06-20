using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Die!!! Bird
/// </summary>
public class Bird4 : Bird3
{
    protected virtual void Die(Collision collision)
    {
        if (GameManager.Dead)
        {
            return;
        }

        Debug.LogWarning(this.GetMethodName() + ":" + collision + ":" + collision.collider + ":" + collision.collider.tag);

        //test
        EnableRagdoll(); return;

        GameManager.Play = false;
        GameManager.Dead = true;

        base.Die(collision);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.LogWarning(this.GetMethodName() + ":" + collision.collider.tag);
        Die(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.GetMethodName() + ":" + other.tag);
    }
}
