using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectController : MonoBehaviour
{
    public Transform Ball;
    public Transform FlyObject;

    void Start()
    {
        Ball = transform.parent;
    }

    void FixedUpdate()
    {
        //FlyObject.position = new Vector3(Mathf.Lerp(FlyObject.position.x, transform.position.x, 0.1f), 
        //                                 Mathf.Lerp(FlyObject.position.y, transform.position.y, 0.3f), 
        //                                 Mathf.Lerp(FlyObject.position.z, transform.position.z, 0.05f));
        FlyObject.position = new Vector3(Mathf.Lerp(FlyObject.position.x, transform.position.x, 0.1f),
                                 6f,
                                 Mathf.Lerp(FlyObject.position.z, transform.position.z, 0.05f));
    }

    public void TouchMove_(bool onLeft)
    {
        if(onLeft)
        {
            transform.position = new Vector3(Ball.position.x + 2, Ball.position.y+2, Ball.position.z);
        }
        else if(!onLeft)
        {
            transform.position = new Vector3(Ball.position.x - 2, Ball.position.y+2, Ball.position.z);
        }
           
    }
}
