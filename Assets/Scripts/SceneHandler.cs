using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void LoadFirstGame()
    {

        SceneManager.LoadScene("FirstGameScene");
    }

}
