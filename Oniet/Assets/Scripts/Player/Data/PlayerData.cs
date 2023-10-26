using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movement_velocity = 5f;
    [Header("Dash State")]
    public float dash_cooldown = 0.5f;
    public float dash_velocity = 20f;
    public float dash_time = 0.5f;
    public float drag = 10f;
    public float dashEndMultiplier = 0.2f;
    
}
