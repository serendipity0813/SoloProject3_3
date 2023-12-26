using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_1 : MonoBehaviour
{
    float direction = 0.05f;
    float toward = 0.1f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toward *= -1;
            direction *= -1;
        }

        if (transform.position.x > 2.8f)
        {
            direction = -0.05f;
            toward = -0.1f;
        }

        else if(transform.position.x < -2.8f)
        {
            direction = 0.05f;
            toward = 0.1f;
        }


    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(direction, 0, 0);
        transform.localScale = new Vector3(toward, 0.1f, 0.1f);
    }
}
