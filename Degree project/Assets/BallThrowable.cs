using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log(collision2D.gameObject.name);
        if (collision2D.gameObject.CompareTag("Brick"))
        {
            Destroy(collision2D.gameObject);
        }
    }
}
