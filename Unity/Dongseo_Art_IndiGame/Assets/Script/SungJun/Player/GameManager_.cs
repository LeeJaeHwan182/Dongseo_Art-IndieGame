using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ : MonoBehaviour
{
    
    [Header("떨어지는 속도 시작 값")]
    public float _minY;
    [Header("가속도 값")]
    public float _plusY;
    [Header("프레임 세기(0에서 시작)")]
    public float _downCount;
    public float _upCount;

    public Vector3 _ball_jump;

    public bool _isDown;

    public Vector3 _upPosition;

    GameObject Ball_up;
    GameObject Ball_down;
    GameObject Ball_left;
    GameObject Ball_right;

    void Start()
    {
        //임시 초기화 값
        Reset_();
        _isDown = true;

        Ball_up = GameObject.Find("Ball_up");
        Ball_down = GameObject.Find("Ball_down");
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = new Vector3(transform.position.x - 3f * Time.deltaTime, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = new Vector3(transform.position.x + 3f * Time.deltaTime, transform.position.y, transform.position.z);





        if (Ball_down.GetComponent<Ball_down>()._isCollisionEnter)
        {
            _isDown = false;
        }
        else if (Ball_up.GetComponent<Ball_up>()._isCollisionEnter)
        {
            _isDown = true;
            Reset_2();
        }







        if (_isDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - _minY, transform.position.z);
            _minY += _plusY;

            if (_downCount <= 50)
                _downCount += 1;

            _plusY = _downCount * 0.002f;
            _upPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, _upPosition.y, 0.1f), transform.position.z);

            if (_upCount <= 50)
                _upCount += 1;

            if (transform.position.y >= _upPosition.y - 0.28f)
            {
                _isDown = true;
                Reset_();
            }
        }
    }



    void Reset_()
    {
        _minY = 0.005f;
        _plusY = 0f;

        _downCount = 0;
    }

    void Reset_2()
    {
        _minY = 0.005f;
        _plusY = 0f;

        _downCount = _upCount - _downCount;

        _minY = _upPosition.y - transform.position.y;

        if (_minY < 0)
            _minY = _minY * -1;

        _minY = _minY / 5;
            
    }
}
