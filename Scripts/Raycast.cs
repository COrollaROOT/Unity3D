using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    
        private void Update()
        {
            // ����ĳ��Ʈ : ������ġ���� �������� �������� �߻��Ͽ� �ε����� �浹ü�� ����
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10f))
            {
                // �������� ���� �浹ü�� �ִ�.
                Debug.Log(hitInfo.collider.gameObject.name);
                Debug.DrawLine(transform.position, hitInfo.point, Color.green);
            }
            else
            {
                // �������� ���� �浹ü�� ����.
                Debug.Log("None");
                Debug.DrawLine(transform.position, transform.position + transform.forward * 10f, Color.red);
            }
        }
    }
