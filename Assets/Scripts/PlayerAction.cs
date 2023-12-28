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

    private void ChangeDuck()
    {
      //���� ���� ������ �ִ� ������ Ŭ���� ��ġ�� ������ �����ϵ��� �ϴ� �޼ҵ�

    }




}
