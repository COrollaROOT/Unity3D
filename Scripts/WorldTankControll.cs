using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WorldTankController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] Fire fire; // �Է��� ������ fire
    [SerializeField] Transform turret; // �ͷ� �����̰� �ϱ�
    [SerializeField] float rotate; // ��ġ
    [SerializeField] float repeatTime; // �ݺ������� �������� ����

    private Coroutine chargeCoroutine; // �۾��� ����

    private void Update()
    {

        Move(); // �����̰�
        TurretRotation(); // ȸ��

        //if (Input.GetKeyDown(KeyCode.Space)) // ���� ������ �����̽�Ű �Է� ������ 
        //{
        //    fire.Shoot(); // �߻�
        //}

        if (Input.GetKeyDown(KeyCode.Space)) // ���� ������ �����̽�Ű �Է� ������ 
            {
               if (chargeCoroutine == null)
            {
                chargeCoroutine = StartCoroutine(ChargeRoutine());
            }
        }
    }

    IEnumerator ChargeRoutine() // ���� ��ƾ
    {
        float timer = 0; // ���� Ÿ�� (���� ���� �ð�)

        while (true) // �ݺ��ϸ鼭
        {
            timer += Time.deltaTime * 30;
            yield return null;

            if (Input.GetKeyUp(KeyCode.Space)) // �����̽��ٸ� ���� �ݺ� ��
                break;
        }


        float bulletSpeed = Mathf.Clamp(timer, 3f, 30f);
        fire.Shoot(bulletSpeed); // �߻�

        chargeCoroutine = null;
    }


    

    private void Move()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector3.forward;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector3.back;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (direction != Vector3.zero)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void TurretRotation()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            rotate -= 50 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotate += 50 * Time.deltaTime;
        }

        turret.rotation = Quaternion.Euler(0, rotate, 0);
    }


}
