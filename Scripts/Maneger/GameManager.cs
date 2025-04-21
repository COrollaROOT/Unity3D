using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    private static GameManager instance; // 데이터 영역이 전역적으로 존대 하나만 있기 때문에
    // public static GameManager Instance { get { return instance; } } // Instance 만들땐 전역적인 접근이 가능한 프로퍼티 생성
    public static GameManager Instance // 
    {
        get
        {
            if (instance == null) // 하나라도 없으면 
            {
                GameObject gameObject = new GameObject("GameManager"); // 만들어라
                instance = gameObject.AddComponent<GameManager>(); 
            }
            return instance;
        }
    }

    public int score;

    private void Awake() // 생성시 // 하나 이상 있으면 지워라
    {
        CreateInstance();       
    }

    private void CreateInstance() // 인스턴스 생성
    {
        if (instance == null) // 만약 instance 없었으면
        {
            instance = this; // instance는 나로
            DontDestroyOnLoad(gameObject); // 씬 전환시에도 gameObject 삭제 방지
        }

        else
        {
            Destroy(gameObject); // 있었으면 gameObject 삭제
        }
    }
}
