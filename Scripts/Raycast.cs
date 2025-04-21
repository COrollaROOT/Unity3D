using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    
        private void Update()
        {
            // 래이캐스트 : 시작위치에서 방향으로 레이저를 발사하여 부딪히는 충돌체를 감지
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10f))
            {
                // 레이저에 닿은 충돌체가 있다.
                Debug.Log(hitInfo.collider.gameObject.name);
                Debug.DrawLine(transform.position, hitInfo.point, Color.green);
            }
            else
            {
                // 레이저에 닿은 충돌체가 없다.
                Debug.Log("None");
                Debug.DrawLine(transform.position, transform.position + transform.forward * 10f, Color.red);
            }
        }
    }
