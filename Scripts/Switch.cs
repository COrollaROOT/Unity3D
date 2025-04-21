using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject door; // 문 오브젝트 상호작용

    private bool IsDoorOpened => door.activeSelf == false;

    [ContextMenu("TestDoor")]
    public void SwitchAction()
    {
        if (IsDoorOpened) // 만약 활성화 되있으면
        {
            Close(); // 닫는다
        }
        else
        {
            Open(); // 연다
        }
    }

    public void Open() // 열기
    {
        door.SetActive(false);
    }

    public void Close() // 닫기
    {
        door.SetActive(true);
    }
}
