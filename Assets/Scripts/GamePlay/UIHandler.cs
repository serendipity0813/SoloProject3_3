using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI remainText;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI missionText;
    public GameObject[] targets;
    public GameObject[] stars;
    public Slider timeSlider;

    private int MaxCount;
    private int remainCount;
    private int stageNum;
    private int targetNum;
    private int missionNum;
    private int maxTime;
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
        MaxCount = 30; // 난이도, 스테이지 조절에 따라 유동적으로 바뀌도록 하기
        remainCount = MaxCount;

        stageNum = 1; // 게임정보 관리에서 받아오도록 설정 필요
        StageText.text = stageNum.ToString();

        targetNum = Random.Range(0, 5);
        targets[targetNum].SetActive(true);

        missionNum = Random.Range(10, 31);  //추후에 stage 번호와 연관되어 적용되도록 하기


        for(int  i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(true);
        }

        maxTime = 30;
        remainTime = maxTime;
        timeSlider.value = remainTime;

    }


    private void UIUpdate()
    {
        remainText.text = remainCount.ToString();
        missionText.text = " X " + missionNum.ToString();

        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;
            timeSlider.value = remainTime;
        }
        else if (remainTime == 0)
        {
            Time.timeScale = 0f;
        }
  


        if (remainCount < 6 * (MaxCount / 10))
        {
            stars[0].SetActive(false);
        }
     
        if (remainCount < 4 * (MaxCount / 10))
        {
            stars[1].SetActive(false);
        }  
          
        if (remainCount < 2 * (MaxCount / 10))
        {
            stars[2].SetActive(false);
        }



    }


}
