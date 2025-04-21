using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour // �Է��� �޾� ��ũ�� �����Ҽ� �ִ� ���
{
    [SerializeField] Fire fire; // �Է��� ������ fire
    [SerializeField] float moveSpeed; // ������Ʈ���� moveSpeed ���� ����
    [SerializeField] float rotationSpeed; // ������Ʈ���� rotationSpeed ���� ����
    [SerializeField] float repeatTime; // �ݺ������� �������� ����

    private Coroutine fireCoroutine; // �۾��� ����

    private void Update() // ������ ����(������Ʈ) �Ǵµ���
    {

        Move(); // �����̰�
        Rotation(); // ȸ��


        //if (Input.GetKeyDown(KeyCode.Space)) // ���� ������ �����̽�Ű �Է� ������ 
        //{
        //    fire.Shoot(); // �߻�
        //}

        if (Input.GetKeyDown(KeyCode.Space)) // ���� ������ �����̽�Ű �Է� ������
        {
            if (fireCoroutine == null) // fireCoroutine�� ���� ����
            {
                fireCoroutine = StartCoroutine(FireRoutine()); // StartCoroutine
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) // �����̽��ٸ� ����
        {
            StopCoroutine(fireCoroutine); // StopCoroutine
            fireCoroutine = null;
        }
    }

    IEnumerator FireRoutine() // ��ƾ ����
    {

        WaitForSeconds delay = new WaitForSeconds(repeatTime); // new �̸� ����� ���� �޸� ����

        while (true) // ����ϱ� ������ ��� �ݺ�
        {
            fire.Shoot(); // �߻�
            yield return delay; // repeatTime��ŭ ��ٸ��鼭
        }

        fireCoroutine = null; // Routine�� ������� �۾����� ���ֶ�
    }


    private void Move()
    {
        float input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * input * Time.deltaTime); // input���� forward�� moveSpeed��ŭ ���� �����Ӱ� ������ ������ �ӵ��� : Time.deltaTime


    }

    private void Rotation()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * input * Time.deltaTime); // input���� up�� rotationSpeed��ŭ ���� �����Ӱ� ������ ������ �ӵ��� : Time.deltaTime
    }
}
