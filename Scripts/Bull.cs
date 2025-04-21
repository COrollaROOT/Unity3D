using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{

    [Header("Component")]
    [SerializeField] Rigidbody rb; // Rigidbody 설정


    [Header("Property")]
    [SerializeField] GameObject explosion; // 폭파 설정
    public int attackPoint; // 공격력

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
        //Monster monster = collision.gameObject.GetComponent<Monster>();
        //if (monster != null)
        //{
        //    monster.TakeDamage(1f); // 몬스터에게 1의 피해를 입힘
        //}
        // 충돌하면
        Destroy(gameObject); // 게임 오브젝트 제거
        Instantiate(explosion, transform.position, transform.rotation); // 생성 폭파오브젝트 해당위치에

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>(); // GetComponent를 사용하여 gameObject 에서 인터페이스 IDamageable을 포함하는 컴포넌트 가져오기
        if (damageable != null) // 만약 데미지 받을수 있는 컴포넌트가 없지 않으면
        {
            Debug.Log($"{collision.gameObject.name} 에서 포탄이 데미지 받을 수 있는 컴포넌트를 가져온다");
            Attack(damageable); // 공격한다
        }
        else
        {
            Debug.Log($"{collision.gameObject.name} 에는 데미지 받을 수 있는 컴포넌트가 없다");
        }
    }

    // 인터페이스 사용하여 규칟에 맟춰서
    private void Attack(IDamageable damageable) // 공격 기능 구현
    {
        damageable.TakeDamage(gameObject, attackPoint);
    }
}
