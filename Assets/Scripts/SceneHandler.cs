using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadFirstGame()
    {

        SceneManager.LoadScene("GameScene");
    }

}
