using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{

    [SerializeField] float TakeDamage;
    [SerializeField] Rigidbody rb; // Rigidbody ����

    [SerializeField] GameObject explosion; // ���� ����
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
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if (monster != null)
        {
            monster.TakeDamage(1f); // ���Ϳ��� 1�� ���ظ� ����
        }
        // �浹�ϸ�
        Destroy(gameObject); // ���� ������Ʈ ����
        Instantiate(explosion, transform.position, transform.rotation); // ���� ���Ŀ�����Ʈ �ش���ġ��

        
    }
}
