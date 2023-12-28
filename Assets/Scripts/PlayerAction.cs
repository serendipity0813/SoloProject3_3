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
        CheckMyDuck();
        ChangeDuck();
    }


    private void GetMousePos()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.ScreenToWorldPoint(mousePos);

    }

    private void FindClickObject()
    {
        //마우스 클릭 pos를 debug를 통해 0,0 좌표와 한 칸 마다 차이나는 거리 체크
        // 그 이후 좌측 하단을 (0,0) 으로 해서 행과 열을 나타내도록 계산하는 식
        mousePos.x = mousePos.x * 100 + 245;
        mousePos.y = mousePos.y * 100 + 340;
        col = mousePos.x / 70;
        row = mousePos.y / 70;

        //gird를 사용하여 좌측 상단부터 배열의 0번이 시작되므로 클릭한 행, 열 좌표가 배열의 몇 번째인지 알아내도록 계산 
        clickPos = 49 - ((int)row*7 - (int)col) ;
        gridDuckNum = GridManager.Instance.gridArray[clickPos];

    }

    private void CheckMyDuck()  //현재 내가 가지고 있는 오리 체크
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
      //현재 내가 가지고 있는 오리와 클릭한 위치의 오리를 변경하도록 하는 메소드

    }




}
