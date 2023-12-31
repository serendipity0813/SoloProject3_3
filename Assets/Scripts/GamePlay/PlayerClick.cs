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

        //���콺 Ŭ�� pos�� debug�� ���� 0,0 ��ǥ�� �� ĭ ���� ���̳��� �Ÿ� üũ
        // �� ���� ���� �ϴ��� (0,0) ���� �ؼ� ��� ���� ��Ÿ������ ����ϴ� ��
        mousePos.x = mousePos.x * 100 + 245;
        mousePos.y = mousePos.y * 100 + 340;
        col = mousePos.x / 70;
        row = mousePos.y / 70;

        //gird�� ����Ͽ� ���� ��ܺ��� �迭�� 0���� ���۵ǹǷ� Ŭ���� ��, �� ��ǥ�� �迭�� �� ��°���� �˾Ƴ����� ��� 
        clickPos = 49 - ((int)row*7 - (int)col) ;
        gridDuckNum = GridManager.Instance.gridArray[clickPos];

    }

    private void CheckMyDuck()  //���� ���� ������ �ִ� ���� üũ
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

    private void ChangeDuck()  //���� ���� ������ �ִ� ������ Ŭ���� ��ġ�� ������ �����ϵ��� �ϴ� �޼ҵ�
    {
        EffectManager.Instance.ChangeSound();

        //���� �����ִ� ������ �ش� ��ġ �����ִ� ������ ���� ��ȣ�� �ٲ��� �� �ٽ� ���ֱ� 
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
