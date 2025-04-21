using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour // 입력을 받아 탱크를 조종할수 있는 기능
{
    [SerializeField] Fire fire; // 입력을 받으면 fire
    [SerializeField] float moveSpeed; // 컴포넌트에서 moveSpeed 조정 가능
    [SerializeField] float rotationSpeed; // 컴포넌트에서 rotationSpeed 조정 가능
    [SerializeField] float repeatTime; // 반복적으로 언제까지 할지

    private Coroutine fireCoroutine; // 작업자 생성

    private void Update() // 게임이 진행(업데이트) 되는동안
    {

        Move(); // 움직이고
        Rotation(); // 회전


        //if (Input.GetKeyDown(KeyCode.Space)) // 만약 게임중 스페이스키 입력 받으면 
        //{
        //    fire.Shoot(); // 발사
        //}

        if (Input.GetKeyDown(KeyCode.Space)) // 만약 게임중 스페이스키 입력 받으면
        {
            if (fireCoroutine == null) // fireCoroutine이 없을 때만
            {
                fireCoroutine = StartCoroutine(FireRoutine()); // StartCoroutine
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) // 스페이스바를 떼면
        {
            StopCoroutine(fireCoroutine); // StopCoroutine
            fireCoroutine = null;
        }
    }

    IEnumerator FireRoutine() // 루틴 생성
    {

        WaitForSeconds delay = new WaitForSeconds(repeatTime); // new 미리 만들어 놔서 메모리 보존

        while (true) // 취소하기 전까지 계속 반복
        {
            fire.Shoot(); // 발사
            yield return delay; // repeatTime만큼 기다리면서
        }

        fireCoroutine = null; // Routine이 끝날경우 작업자을 없애라
    }


    private void Move()
    {
        float input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * input * Time.deltaTime); // input받은 forward로 moveSpeed만큼 게임 프레임과 무관한 동일한 속도로 : Time.deltaTime


    }

    private void Rotation()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationSpeed * input * Time.deltaTime); // input받은 up을 rotationSpeed만큼 게임 프레임과 무관한 동일한 속도로 : Time.deltaTime
    }
}
