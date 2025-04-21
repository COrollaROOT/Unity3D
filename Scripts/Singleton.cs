using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    
        private static Singleton instance;

        public static Singleton GetInstance()
        {
            if (instance == null) // ������
            {
                instance = new Singleton(); // ������ְ� 
            }

            return instance; // ������ ������� �ִ°� ����
        }

        private Singleton() { } // private�����ڷ� ����� �ٸ� �Լ����� Singleton�� ����� ���� �����
}

