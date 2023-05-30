using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int money;
    public float conveyorSpeed;
    public int speedLevel;
    public int valueLevel;
    public int truckCapacityLevel;
    public int itemsValue;
    public int truckCapacity;

    [Header("---Upgrade values---")]
    public float[] speedUpgrades;
    public int[] valueUpgrades;
    public int[] truckCapacityUpgrades;
    [Header("---Upgrade Costs---")]
    public int[] speedUpgradesCosts;
    public int[] valueUpgradesCosts;
    public int[] truckCapacityCosts;
}