using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

}