using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable // IDamageable 인터페이스 상속
{
    [Header("Component")]
    [SerializeField] Transform eyeTransform; // 눈 위치 

    [Header("Property")]
    [SerializeField] float sightRange; // 시야
    [SerializeField] float moveSpeed; // 이동 속도
    [SerializeField] int hp;
    public int HP { get { return hp; } private set { hp = value; } }

    [SerializeField] GameObject target;

    private void Update()
    {
        DetectTarget();

        if (target != null)
        {
            Trace();
        }


    }

    private void DetectTarget()
    {
        if (Physics.Raycast(eyeTransform.position, eyeTransform.forward, out RaycastHit hitInfo, sightRange))
        {
            Debug.DrawLine(eyeTransform.position, hitInfo.point, Color.green);
            TankController tank = hitInfo.collider.gameObject.GetComponent<TankController>();
            if (hitInfo.collider.gameObject.tag == "Player")
            {
                target = hitInfo.collider.gameObject;
            }

            //if (tank != null)
            //{
            //    target = hitInfo.collider.gameObject;
            //}
            else
            {
                target = null;
            }
        }
        else
        {
            Debug.DrawLine(eyeTransform.position, eyeTransform.position + eyeTransform.forward * sightRange, Color.red);
            target = null;
        }
    }

    private void Trace()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }

    //public void TakeDamage(float damage)
    //{
    //    monsterHp -= damage;
    //    if (monsterHp <= 0f)
    //    {
    //        Destroy(gameObject); // 몬스터 제거
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        // 체력 감소
    //        monsterHp -= 1f;
    //        Destroy(collision.gameObject); // 탄환 제거
    //
    //        if (monsterHp <= 0f)
    //        {
    //            Destroy(gameObject); // 몬스터 제거
    //        }
    //    }
    //    else if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(collision.gameObject); // 탱크 제거
    //    }
    //}

    public void TakeDamage(GameObject dealer, int damage)
    {
        Debug.Log($"{gameObject.name} 이/가 {dealer.name} 에게 공격을 {damage} 받았습니다. ");
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.score += 1;
        Destroy(gameObject);
    }
}
