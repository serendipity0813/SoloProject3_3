using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOver;
    public GameObject gameClear;
    public int missionNum;
    public int targetNum;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        missionNum = Player.player.stage * Random.Range(5, 11);
        targetNum = Random.Range(0, 5);
    }

    private void Update()
    {
        ClearCheck();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }

    public void MissionCount(int DuckNum)
    {
        if (DuckNum == targetNum)
            missionNum--;
    }


    public void ClearCheck()
    {
        if(missionNum < 1)
        {
            Player.player.LevelUp();
            gameClear.SetActive(true);
        }


    }


}
