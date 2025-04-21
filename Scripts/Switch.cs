using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject door; // �� ������Ʈ ��ȣ�ۿ�

    private bool IsDoorOpened => door.activeSelf == false;

    [ContextMenu("TestDoor")]
    public void SwitchAction()
    {
        if (IsDoorOpened) // ���� Ȱ��ȭ ��������
        {
            Close(); // �ݴ´�
        }
        else
        {
            Open(); // ����
        }
    }

    public void Open() // ����
    {
        door.SetActive(false);
    }

    public void Close() // �ݱ�
    {
        door.SetActive(true);
    }
}
