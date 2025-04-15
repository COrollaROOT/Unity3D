using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // ���� : ����
    public float jumpPower;
    public int movePower;
    public Rigidbody rigid;
    public Color color;

    // ��� : �Լ�

    private void Start()
    {
        // ���� �����Ҷ� �Լ�
    }

    private void Update()
    {
        // ���� �����߿� ��� ȣ��
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(Vector3.left * movePower, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector3.right * movePower, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid.AddForce(Vector3.forward * movePower, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddForce(Vector3.back * movePower, ForceMode.Force);
        }
    }
}
