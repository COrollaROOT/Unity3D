using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{

    [Header("Component")]
    [SerializeField] Rigidbody rb; // Rigidbody ����


    [Header("Property")]
    [SerializeField] GameObject explosion; // ���� ����
    public int attackPoint; // ���ݷ�

    private void Update()
    {
        // sqrMagnitude : �� ������ �Ÿ��� ������ ��Ʈ�� �� ��. �� ������ �Ÿ��� ���̸� 2���� �Լ������� ������ش�.

        if (rb.velocity.sqrMagnitude > 2) // ���� Rigidbody�� ������(velocity).������ ����. �� 2���� ũ�� 
        {
            transform.forward = rb.velocity; // ��ġ�� ������ �̵��ض� = Rigidbody�� ������(velocity)��
        }

    }



    private void OnCollisionEnter(Collision collision)
    // Enter :  �浿 ���Խ� ȣ��. ����� �� 1ȸ ����˴ϴ�.
    {
        //Monster monster = collision.gameObject.GetComponent<Monster>();
        //if (monster != null)
        //{
        //    monster.TakeDamage(1f); // ���Ϳ��� 1�� ���ظ� ����
        //}
        // �浹�ϸ�
        Destroy(gameObject); // ���� ������Ʈ ����
        Instantiate(explosion, transform.position, transform.rotation); // ���� ���Ŀ�����Ʈ �ش���ġ��

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>(); // GetComponent�� ����Ͽ� gameObject ���� �������̽� IDamageable�� �����ϴ� ������Ʈ ��������
        if (damageable != null) // ���� ������ ������ �ִ� ������Ʈ�� ���� ������
        {
            Debug.Log($"{collision.gameObject.name} ���� ��ź�� ������ ���� �� �ִ� ������Ʈ�� �����´�");
            Attack(damageable); // �����Ѵ�
        }
        else
        {
            Debug.Log($"{collision.gameObject.name} ���� ������ ���� �� �ִ� ������Ʈ�� ����");
        }
    }

    // �������̽� ����Ͽ� ��Ĥ�� ���缭
    private void Attack(IDamageable damageable) // ���� ��� ����
    {
        damageable.TakeDamage(gameObject, attackPoint);
    }
}
