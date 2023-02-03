using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int money;
    public float conveyorSpeed;
    public float boxSpawnCoolDown;
    public int speedLevel;
    public int valueLevel;
    public int itemsValue;

    [Header("---Upgrade values---")]
    public float[] speedUpgrades;
    public int[] valueUpgrades;
    [Header("---Upgrade Costs---")]
    public int[] speedUpgradesCosts;
    public int[] valueUpgradesCosts;
}