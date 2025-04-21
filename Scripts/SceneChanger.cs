using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R키를 누르면 씬 전환
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
