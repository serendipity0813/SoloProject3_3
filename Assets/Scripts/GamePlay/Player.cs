using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    public PlayerData playerData;

    public int boomNum;
    public int hammerNum;
    public int clockNum;
    public int level = 1;
    public int stage;
    public int maxCount = 30;
    public int remainCount;
    public float maxTime = 30f;
    public float remainTime;



    void Awake()
    {
        if (player == null)
        {
            player = this;
        }
        else
        {
            Destroy(gameObject);
        }

        boomNum = 1;
        hammerNum = 1;
        clockNum = 1;

        //level = playerData.level;
        //boomNum = playerData.Boom;
        //hammerNum = playerData.Hammer;
        //clockNum = playerData.Clock;

        stage = level;
        remainTime = maxTime;
        remainCount = maxCount;
    }

    private void Update()
    {
        remainTime -=Time.deltaTime;
    }

    public void ClickCount()
    {
        remainCount--;

        if (remainCount == 0)
        {
            GameManager.Instance.ClearCheck();
            GameManager.Instance.GameOver();
        }
            
    }

    public void LevelUp()
    {
        playerData.level++;
    }
}
