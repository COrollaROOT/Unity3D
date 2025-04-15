using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour // 입력을 받아 탱크를 조종할수 있는 기능
{
    [SerializeField] Fire fire; // 입력을 받으면 fire


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스키 입력 받으면 
        {
            fire.Shoot(); // 발사
        }
    }
}
