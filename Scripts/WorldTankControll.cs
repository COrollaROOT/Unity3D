using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WorldTankController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] Fire fire; // 입력을 받으면 fire
    [SerializeField] Transform turret; // 터렛 움직이게 하기
    [SerializeField] float rotate; // 위치
    [SerializeField] float repeatTime; // 반복적으로 언제까지 할지

    private Coroutine chargeCoroutine; // 작업자 생성

    private void Update()
    {

        Move(); // 움직이고
        TurretRotation(); // 회전

        //if (Input.GetKeyDown(KeyCode.Space)) // 만약 게임중 스페이스키 입력 받으면 
        //{
        //    fire.Shoot(); // 발사
        //}

        if (Input.GetKeyDown(KeyCode.Space)) // 만약 게임중 스페이스키 입력 받으면 
            {
               if (chargeCoroutine == null)
            {
                chargeCoroutine = StartCoroutine(ChargeRoutine());
            }
        }
    }

    IEnumerator ChargeRoutine() // 차지 루틴
    {
        float timer = 0; // 누적 타임 (차지 누른 시간)

        while (true) // 반복하면서
        {
            timer += Time.deltaTime * 30;
            yield return null;

            if (Input.GetKeyUp(KeyCode.Space)) // 스페이스바를 떼면 반복 끝
                break;
        }


        float bulletSpeed = Mathf.Clamp(timer, 3f, 30f);
        fire.Shoot(bulletSpeed); // 발사

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
