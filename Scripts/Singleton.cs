using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    
        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance == null) // 없으면
            {
                instance = new Singleton(); // 만들어주고 
            }

            return instance; // 있으면 만들어져 있는거 전달
        }

        private Singleton() { } // private생성자로 만들어 다른 함수에서 Singleton을 만들수 없게 만든다
}

