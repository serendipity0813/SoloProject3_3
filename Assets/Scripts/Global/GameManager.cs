using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool[] checkArray;
    private bool checkFlag = false;

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

    private void Start()
    {
        checkArray = new bool[56];
        ResetArray();
    }


    public void FourWayCheck(int clickPos, int DuckNum)
    {
        checkFlag = false;

        if (clickPos + 1 < 56)
        {
            if (GridManager.Instance.gridArray[clickPos + 1] == DuckNum)
            {
                if (checkArray[clickPos + 1] == false)
                {
                    checkArray[clickPos + 1] = true;
                    checkFlag = true;
                    FourWayCheck(clickPos + 1, DuckNum);
                }

            }
        }

        if (clickPos - 1 > 0)
        {
            if (GridManager.Instance.gridArray[clickPos - 1] == DuckNum)
            {
                if (checkArray[clickPos - 1] == false)
                {
                    checkArray[clickPos - 1] = true;
                    checkFlag = true;
                    FourWayCheck(clickPos - 1, DuckNum);
                }
          
            }
        }

        if (clickPos + 7 < 56)
        {
            if (GridManager.Instance.gridArray[clickPos + 7] == DuckNum)
            {
                if (checkArray[clickPos + 7] == false)
                {
                    checkArray[clickPos + 7] = true;
                    checkFlag = true;
                    FourWayCheck(clickPos + 7, DuckNum);
                }
            }
        }

        if (clickPos - 7 > 0)
        {
            if (GridManager.Instance.gridArray[clickPos - 7] == DuckNum)
            {
                if (checkArray[clickPos - 7] == false)
                {
                    checkArray[clickPos - 7] = true;
                    checkFlag = true;
                    FourWayCheck(clickPos - 7, DuckNum);
                }
            }
        }

        if (checkFlag == true) 
        checkArray[clickPos] = true;

    }

    public void DuckDuck(int DuckNum)
    {
        for (int i = 0; i<checkArray.Length; i++)
        {
            if (checkArray[i] == true)
            {
                GridManager.Instance.HideDuck(i, DuckNum);
                int newduck = Random.Range(0, 5);
                GridManager.Instance.gridArray[i] = newduck;
                GridManager.Instance.ShowDuck(i, newduck);
            }
        }

        ResetArray();
    }

    private void ResetArray()
    {
        for (int i = 0; i < checkArray.Length; i++)
        {
            checkArray[i] = false;
        }
    }

}
