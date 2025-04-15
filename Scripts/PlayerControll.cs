using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // 정보 : 변수
    public float jumpPower;
    public int movePower;
    public Rigidbody rigid;
    public Color color;

    // 기능 : 함수

    private void Start()
    {
        // 게임 시작할때 함수
    }

    private void Update()
    {
        // 게임 동작중에 계속 호출
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
