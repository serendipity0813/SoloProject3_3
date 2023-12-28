using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    public Camera Camera;
    public GameObject MyDuck;

    private float row = 0;
    private float col = 0;
    private int clickPos;
    private int gridDuckNum;
    private int MyDuckNum;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerClick();
        }
    }

    private void PlayerClick()
    {
        GetMousePos();
        FindClickObject();
        ChangeDuck();
    }


    private void GetMousePos()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.ScreenToWorldPoint(mousePos);

    }

    private void FindClickObject()
    {
        mousePos.x = mousePos.x * 100 + 245;
        mousePos.y = mousePos.y * 100 + 340;
        col = mousePos.x / 70;
        row = mousePos.y / 70;

        clickPos = 49 - ((int)row*7 - (int)col) ;

        Debug.Log(row);
        Debug.Log(col);
        Debug.Log(clickPos);

        gridDuckNum = GridManager.Instance.gridArray[clickPos];
        Debug.Log(gridDuckNum);
        CheckMyDuck();
        Debug.Log(MyDuckNum);

    }

    private void CheckMyDuck()
    {
        for(int i=0; i<5; i++)
        {
            if (MyDuck.transform.GetChild(i).gameObject.activeSelf == true)
            {
                MyDuckNum = i;
                break;
            }
               
        }
      
    }

    private void ChangeDuck()
    {
      

    }




}
