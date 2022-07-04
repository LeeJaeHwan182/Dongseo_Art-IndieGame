using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ : MonoBehaviour
{
    
    [Header("�������� �ӵ� ���� ��")]
    public float _minY;
    [Header("���ӵ� ��")]
    public float _plusY;
    [Header("������ ����(0���� ����)")]
    public float _downCount;
    public float _upCount;
    public float _horizontalMove;

    public Vector3 _ball_jump;

    public bool _isDown;
    public bool _collisionLeft;
    public bool _collisionRight;

    public float _upPositionY;
    public float _xPosition;

    GameObject Ball_up;
    GameObject Ball_down;
    GameObject Ball_left;
    GameObject Ball_right;

    GameObject FollowObject;

    void Start()
    {
        //�ӽ� �ʱ�ȭ ��
        Reset_();
        _isDown = true;
        _collisionLeft = false;
        _collisionRight = false;

        Ball_up = GameObject.Find("Ball_up");
        Ball_down = GameObject.Find("Ball_down");
        Ball_left = GameObject.Find("Ball_left");
        Ball_right = GameObject.Find("Ball_right");
        FollowObject = GameObject.Find("FollowObject");

        _upCount = 0;
        _downCount = 0;
        _horizontalMove = 0f;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + _horizontalMove * Time.deltaTime, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_horizontalMove > -5)//�ִ�ӵ�
                _horizontalMove -= 0.2f;//���ӵ�

            if (_collisionLeft)
            {
                _xPosition -= 0.5f;
            }
            FollowObject.GetComponent<FollowObjectController>().TouchMove_(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_horizontalMove < 5)//�ִ�ӵ�
                _horizontalMove += 0.2f;//���ӵ�

            if (_collisionRight)
                _xPosition += 0.5f;
            FollowObject.GetComponent<FollowObjectController>().TouchMove_(false);
        }

        else//�������� �� �پ��� �ӵ�
        {
            if (_horizontalMove < 0.1f && _horizontalMove > -0.1f)
                _horizontalMove = 0f;

            else if (_horizontalMove < 0.1f)
                _horizontalMove += 0.2f;
            else
                _horizontalMove -= 0.2f;
        }



        if (Ball_down.GetComponent<Ball_down>()._isCollisionEnter)
        {
            _isDown = false;
        }
        else if (Ball_up.GetComponent<Ball_up>()._isCollisionEnter)
        {
            _isDown = true;
            Reset_2();
        }
        else if (Ball_left.GetComponent<Ball_left>()._isCollisionEnter && !_collisionLeft)
        {
            _horizontalMove = -1f;
            _collisionLeft = true;
            _xPosition = transform.position.x + 2;
            Debug.Log("���� �浹");
        }
        else if (Ball_right.GetComponent<Ball_right>()._isCollisionEnter && !_collisionRight)
        {
            _horizontalMove = 1f;
            _collisionRight = true;
            _xPosition = transform.position.x - 2;
            Debug.Log("������ �浹");
        }





        //���� �� �Ʒ��� ������ ��
        if (_isDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - _minY, transform.position.z);
            _minY += _plusY;

            if (_downCount <= 50)
                _downCount += 1;

            _plusY = _downCount * 0.002f;
            _upPositionY = transform.position.y + 5f;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, _upPositionY, 0.1f), transform.position.z);

            if (_upCount <= 50)
                _upCount += 1;

            if (transform.position.y >= _upPositionY - 0.28f)
            {
                _isDown = true;
                Reset_();
            }
        }
        //�� ���� �ε��� ��

        if (_collisionLeft)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _xPosition, 0.1f), transform.position.y, transform.position.z);

            if (transform.position.x > _xPosition - 0.2f)
                _collisionLeft = false;
        }

        else if (_collisionRight)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _xPosition, 0.1f), transform.position.y, transform.position.z);

            if (transform.position.x < _xPosition + 0.2f)
                _collisionRight = false;
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

        _minY = _upPositionY - transform.position.y;

        if (_minY < 0)
            _minY = _minY * -1;

        _minY = _minY / 5;
            
    }
}
