using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageAdapter : MonoBehaviour, IDamageable
{

    public UnityEvent<GameObject , int > OnDamaged;

    public void TakeDamage(GameObject dealer, int damage) // 인터페이스에서 TakeDamage를 진행할때
    {
       OnDamaged?.Invoke(dealer, damage); // 이벤트 발생 (어뎁터 생성)
    }
}
