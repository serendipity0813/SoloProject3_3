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
        //56칸을 가진 배열을 생성하고 각 칸마다 0~4 사이의 숫자 배정 후 해당 번호에 해당하는 오리 배치
        gridArray = new int[gridNum];

        for (int i = 0; i < gridNum; i++)
        {
            HideDuck(i, 0);
            gridArray[i] = Random.Range(0, 5);
            ShowDuck(i, gridArray[i]);
        }
    }

    //번호를 매개변수로 받았을 때 해당 번호에 해당하는 오리를 켜주거나 꺼주는 함수

    private void ShowDuck(int gridNum, int duckNum)
    {
        Ducks[gridNum].transform.GetChild(duckNum).gameObject.SetActive(true);   
    }


    private void HideDuck(int gridNum, int duckNum)
    {
        Ducks[gridNum].transform.GetChild(duckNum).gameObject.SetActive(false);
    }

}
