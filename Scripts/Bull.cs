using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{

    [SerializeField] float TakeDamage;
    [SerializeField] Rigidbody rb; // Rigidbody 설정

    [SerializeField] GameObject explosion; // 폭파 설정
    private void Update()
    {
        // sqrMagnitude : 두 점간의 거리의 제곱에 루트를 한 값. 두 점간의 거리의 차이를 2차원 함수값으로 계산해준다.

        if (rb.velocity.sqrMagnitude > 2) // 만약 Rigidbody의 물리력(velocity).벡터의 길이. 가 2보다 크면 
        {
            transform.forward = rb.velocity; // 위치를 앞으로 이동해라 = Rigidbody의 물리력(velocity)을
        }

    }



    private void OnCollisionEnter(Collision collision)
    // Enter :  충동 진입시 호출. 실행될 때 1회 실행됩니다.
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if (monster != null)
        {
            monster.TakeDamage(1f); // 몬스터에게 1의 피해를 입힘
        }
        // 충돌하면
        Destroy(gameObject); // 게임 오브젝트 제거
        Instantiate(explosion, transform.position, transform.rotation); // 생성 폭파오브젝트 해당위치에

        
    }
}
