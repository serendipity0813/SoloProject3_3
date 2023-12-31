using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    public Camera Camera;
    public GameObject MyDuck;

    private float row = 0;
    private float col = 0;
    private int clickPos;
    private int gridDuckNum;
    private int MyDuckNum;
    private bool mouseCheck;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerClickEvent();
        }
    }

    public void PlayerClickEvent()
    {
        GetMousePos();
        if (mouseCheck == true)
        {
            FindClickObject();
            CheckMyDuck();
            ChangeDuck();
            Player.player.ClickCount();
            LogicManager.Instance.FourWayCheck(clickPos, GridManager.Instance.gridArray[clickPos]);
            LogicManager.Instance.DuckDuck(GridManager.Instance.gridArray[clickPos]);
        }

    }


    private void GetMousePos()
    {
        mouseCheck = true;
        mousePos = Input.mousePosition;
        mousePos = Camera.ScreenToWorldPoint(mousePos);

        if (mousePos.x > 2.4 || mousePos.x < -2.4)
            mouseCheck = false;
        if (mousePos.y > 2.2 || mousePos.y < -3.3)
            mouseCheck = false;


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

    private void ChangeDuck()  //현재 내가 가지고 있는 오리와 클릭한 위치의 오리를 변경하도록 하는 메소드
    {
        EffectManager.Instance.ChangeSound();

        //나의 켜져있는 오리와 해당 위치 켜져있는 오리를 끄고 번호를 바꿔준 후 다시 켜주기 
        int temp = 0;
        MyDuck.transform.GetChild(MyDuckNum).gameObject.SetActive(false);
        GridManager.Instance.HideDuck(clickPos, gridDuckNum);
        
        temp = MyDuckNum;
        MyDuckNum = gridDuckNum;
        gridDuckNum = temp;

        MyDuck.transform.GetChild(MyDuckNum).gameObject.SetActive(true);
        GridManager.Instance.ShowDuck(clickPos, gridDuckNum);

        GridManager.Instance.gridArray[clickPos] = gridDuckNum;

        temp = 0;
        MyDuckNum = 0;
        gridDuckNum = 0;

    }




}
