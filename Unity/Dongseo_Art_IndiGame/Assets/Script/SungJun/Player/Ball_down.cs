using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_down : MonoBehaviour
{
    public bool _isCollisionEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish" && !_isCollisionEnter)
        {
            _isCollisionEnter = true;
        }
    }
}
