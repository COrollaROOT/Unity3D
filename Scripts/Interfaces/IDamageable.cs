using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable // Bull �� Monster Ŭ���� ���̿� interface��� ��Ģ�� ����
{
    // �������� �����ٶ� TakeDamage�� dealer�� damage��ŭ ������
    public void TakeDamage(GameObject dealer, int damage);
}
