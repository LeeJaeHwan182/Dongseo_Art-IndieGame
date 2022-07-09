using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceTest : MonoBehaviour
{
    public bool isGround;
    public float high;
    public Rigidbody rd;
    public float force;

    public float _horizontalMove;
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        rd = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _horizontalMove -= 0.2f;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            _horizontalMove += 0.2f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        rd.AddForce(transform.up * force, ForceMode.Impulse);
        isGround = false;
    }
}
