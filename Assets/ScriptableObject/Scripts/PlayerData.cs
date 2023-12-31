using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    [Header("Player Info")]
    public int level;

    [Header("Item Info")]
    public int Boom;
    public int Hammer;
    public int Clock;


}
