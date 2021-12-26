using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats: MonoBehaviour
{
    public string Name { get; set; } = "Player";
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;
    public float Health { get; set; } = 100.0f;
    public float MaxHealth { get; set; } = 100.0f;
    public float Attack { get; set; } = 10.0f;
    public float BaseAttack { get; set; } = 10.0f;
    public float Defense { get; set; } = 10.0f;
    public float BaseDefence { get; set; } = 10.0f;
}
