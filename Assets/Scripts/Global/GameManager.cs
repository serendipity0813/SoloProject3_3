using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private PlayerClick playerClick;
    private int arrayLength = GridManager.Instance.gridArray.Length;

    private bool[] checkArray;
    private int clickPos;

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
        checkArray = new bool[arrayLength];
        ResetArray();
    }

    public void FourWayCheck(int clickPos, int DuckNum)
    {
        for(int  i = 0; i < arrayLength; i++)
        {
            if(i == clickPos)
            checkArray[i] = true;
        }

        if(GridManager.Instance.gridArray[clickPos + 1] == DuckNum)
        {
            checkArray[clickPos + 1] = true;
            FourWayCheck(clickPos+1, DuckNum);
        }

        if (GridManager.Instance.gridArray[clickPos - 1] == DuckNum)
        {
            checkArray[clickPos - 1] = true;
            FourWayCheck(clickPos - 1, DuckNum);
        }

        if (GridManager.Instance.gridArray[clickPos + 7] == DuckNum)
        {
            checkArray[clickPos + 7] = true;
            FourWayCheck(clickPos + 7, DuckNum);
        }

        if (GridManager.Instance.gridArray[clickPos - 7] == DuckNum)
        {
            checkArray[clickPos - 7] = true;
            FourWayCheck(clickPos - 7, DuckNum);
        }



    }

    private void ResetArray()
    {
        for (int i = 0; i < arrayLength; i++)
        {
            checkArray[i] = false;
        }
    }

}
