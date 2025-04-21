using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    private static GameManager instance; // ������ ������ ���������� ���� �ϳ��� �ֱ� ������
    // public static GameManager Instance { get { return instance; } } // Instance ���鶩 �������� ������ ������ ������Ƽ ����
    public static GameManager Instance // 
    {
        get
        {
            if (instance == null) // �ϳ��� ������ 
            {
                GameObject gameObject = new GameObject("GameManager"); // ������
                instance = gameObject.AddComponent<GameManager>(); 
            }
            return instance;
        }
    }

    public int score;

    private void Awake() // ������ // �ϳ� �̻� ������ ������
    {
        CreateInstance();       
    }

    private void CreateInstance() // �ν��Ͻ� ����
    {
        if (instance == null) // ���� instance ��������
        {
            instance = this; // instance�� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ�ÿ��� gameObject ���� ����
        }

        else
        {
            Destroy(gameObject); // �־����� gameObject ����
        }
    }
}
