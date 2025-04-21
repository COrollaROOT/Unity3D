using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable // IDamageable �������̽� ���
{
    [Header("Component")]
    [SerializeField] Transform eyeTransform; // �� ��ġ 

    [Header("Property")]
    [SerializeField] float sightRange; // �þ�
    [SerializeField] float moveSpeed; // �̵� �ӵ�
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
    //        Destroy(gameObject); // ���� ����
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        // ü�� ����
    //        monsterHp -= 1f;
    //        Destroy(collision.gameObject); // źȯ ����
    //
    //        if (monsterHp <= 0f)
    //        {
    //            Destroy(gameObject); // ���� ����
    //        }
    //    }
    //    else if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(collision.gameObject); // ��ũ ����
    //    }
    //}

    public void TakeDamage(GameObject dealer, int damage)
    {
        Debug.Log($"{gameObject.name} ��/�� {dealer.name} ���� ������ {damage} �޾ҽ��ϴ�. ");
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
