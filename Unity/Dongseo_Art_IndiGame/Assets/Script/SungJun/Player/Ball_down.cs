using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_down : MonoBehaviour
{
    public bool _isCollisionEnter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Finish")
        {
            _isCollisionEnter = true;
            Debug.Log("�ǵ�");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Finish")
        {
            _isCollisionEnter = false;
            Debug.Log("����");
        }
    }
}
