using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageAdapter : MonoBehaviour, IDamageable
{

    public UnityEvent<GameObject , int > OnDamaged;

    public void TakeDamage(GameObject dealer, int damage) // �������̽����� TakeDamage�� �����Ҷ�
    {
       OnDamaged?.Invoke(dealer, damage); // �̺�Ʈ �߻� (��� ����)
    }
}
