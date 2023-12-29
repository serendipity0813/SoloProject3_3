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


    // ui�� ǥ���ϴ� �κ��� ������ �ð��̳� ī��Ʈ Ƚ�� ����� �ٸ� ��Ҵ� �ٸ� ��ũ��Ʈ�� �����ϰ� �������� ������ �����丵�ϱ�

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
        MaxCount = 30; // ���̵�, �������� ������ ���� ���������� �ٲ�� �ϱ�
        remainCount = MaxCount;

        stageNum = 1; // �������� �������� �޾ƿ����� ���� �ʿ�
        StageText.text = stageNum.ToString();

        targetNum = Random.Range(0, 5);
        targets[targetNum].SetActive(true);

        missionNum = Random.Range(10, 31);  //���Ŀ� stage ��ȣ�� �����Ǿ� ����ǵ��� �ϱ�


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
