using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; //�̵� �ӷ�
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            //���� ����Ű �Է��� ������ ���, Z����(�յ�)���� speed ��ŭ ���ֱ�
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            //���� ����Ű �Է��� ������ ���, Z����(�յ�) ���ֱ�
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            //���� ����Ű �Է��� ������ ���, Z����(�յ�) ���ֱ�
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            //���� ����Ű �Է��� ������ ���, Z����(�յ�) ���ֱ�
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }
}
