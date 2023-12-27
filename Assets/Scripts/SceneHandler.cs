
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    
private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void LoadGameScene()
    {

        SceneManager.LoadScene("GameScene");
    }

}
