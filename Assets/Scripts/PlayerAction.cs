using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Vector2 mousePos = Vector2.zero;
    public Camera Camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetMousePos();
            Debug.Log(mousePos);
        }
    }

    private void GetMousePos()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.ScreenToWorldPoint(mousePos);

    }


}
