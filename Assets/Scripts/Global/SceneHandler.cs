
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
