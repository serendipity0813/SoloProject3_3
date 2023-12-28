using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public int[] gridArray;
    public GameObject [] Ducks = new GameObject[56];

    private void Awake()
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

    private void Start()
    {
        MakeGrid(56);
    }

    private void MakeGrid(int gridNum)
    {
        //56ĭ�� ���� �迭�� �����ϰ� �� ĭ���� 0~4 ������ ���� ���� �� �ش� ��ȣ�� �ش��ϴ� ���� ��ġ
        gridArray = new int[gridNum];

        for (int i = 0; i < gridNum; i++)
        {
            HideDuck(i, 0);
            gridArray[i] = Random.Range(0, 5);
            ShowDuck(i, gridArray[i]);
        }
    }

    //��ȣ�� �Ű������� �޾��� �� �ش� ��ȣ�� �ش��ϴ� ������ ���ְų� ���ִ� �Լ�

    private void ShowDuck(int gridNum, int duckNum)
    {
        Ducks[gridNum].transform.GetChild(duckNum).gameObject.SetActive(true);   
    }


    private void HideDuck(int gridNum, int duckNum)
    {
        Ducks[gridNum].transform.GetChild(duckNum).gameObject.SetActive(false);
    }

}
