using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable // Bull 과 Monster 클래스 사이에 interface라는 규칙을 설정
{
    // 데미지를 가해줄때 TakeDamage로 dealer가 damage만큼 때린다
    public void TakeDamage(GameObject dealer, int damage);
}
