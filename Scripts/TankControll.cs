using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour // �Է��� �޾� ��ũ�� �����Ҽ� �ִ� ���
{
    [SerializeField] Fire fire; // �Է��� ������ fire


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �����̽�Ű �Է� ������ 
        {
            fire.Shoot(); // �߻�
        }
    }
}
