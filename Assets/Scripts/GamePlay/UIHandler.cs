using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI remainText;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI boomNum;
    public TextMeshProUGUI hammerNum;
    public TextMeshProUGUI clockNum;
    public GameObject[] targets;
    public GameObject[] stars;
    public Slider timeSlider;
    public Image fill;

    private int stage;
    private int MaxCount;
    private int remainCount;
    private int missionNum;
    private float remainTime;


    // ui를 표현하는 부분을 제외한 시간이나 카운트 횟수 등등의 다른 요소는 다른 스크립트에 정리하고 가져오는 식으로 리팩토링하기

    private void Start()
    {
        UISetting();
        
    }

    private void Update()
    {
        UIUpdate();
    }

    private void UISetting()
    {

        MaxCount = Player.player.maxCount;
        stage = Player.player.stage;
        stageText.text = stage.ToString();
        boomNum.text = Player.player.boomNum.ToString();
        hammerNum.text = Player.player.hammerNum.ToString();
        clockNum.text = Player.player.clockNum.ToString();
        targets[GameManager.Instance.targetNum].SetActive(true);
        missionNum = GameManager.Instance.missionNum;


        for(int  i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(true);
        }

    }


    private void UIUpdate()
    {
        remainText.text = remainCount.ToString();
        missionText.text = " X " + missionNum.ToString();
        missionNum = GameManager.Instance.missionNum;
        remainCount = Player.player.remainCount;
        remainTime = Player.player.remainTime;
        timeSlider.value = remainTime;

        TimeUpdate();
        StarUpdate();


    }

    private void TimeUpdate()
    {

        if (remainTime > 0)
        {
            timeSlider.value = remainTime;
        }

        if(remainTime < 20)
        {
            fill.color = Color.yellow;
        }

        if (remainTime < 10)
        {
            fill.color = Color.red;
        }

        if (remainTime < 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void StarUpdate()
    {

        if (remainCount < 8 * (MaxCount / 10))
        {
            stars[0].SetActive(false);
        }

        if (remainCount < 5 * (MaxCount / 10))
        {
            stars[1].SetActive(false);
        }

        if (remainCount < 2 * (MaxCount / 10))
        {
            stars[2].SetActive(false);
        }
    }


}
