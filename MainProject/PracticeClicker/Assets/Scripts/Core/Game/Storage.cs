using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Storage : MonoBehaviour
{
    public float conveyorSpeed;
    public int SpeedLevel;
    public int ValueLevel;
    public int TruckCapacityLevel;
    public int ItemsValue;
    public int TruckCapacity;

    [Header("---Upgrade values---")]
    public float[] SpeedUpgrades;
    public int[] ValueUpgrades;
    public int[] TruckCapacityUpgrades;
    [Header("---Upgrade Costs---")]
    public int[] SpeedUpgradesCosts;
    public int[] ValueUpgradesCosts;
    public int[] TruckCapacityCosts;

    [Header("--- Other ---")]
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private string _moneyAdditionalText;

    public int Money 
    {
        get =>_money;
        set
        {
            _money = value;
            _moneyText.text = _moneyAdditionalText + value + "$";
        }
    }
    private int _money;
}