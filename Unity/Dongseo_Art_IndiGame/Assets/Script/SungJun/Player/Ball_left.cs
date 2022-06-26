using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_left : MonoBehaviour
{
    public bool _isCollisionEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish")
        {
            _isCollisionEnter = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Finish")
        {
            _isCollisionEnter = false;
        }
    }
}
