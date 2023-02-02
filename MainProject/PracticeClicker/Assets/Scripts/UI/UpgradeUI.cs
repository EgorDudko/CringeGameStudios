using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private Button _buttonUpgradeMenu;
    [SerializeField] private Button _buttonSpeedUpgrade;
    [SerializeField] private GameObject _UpgradeMenu;
    [SerializeField] private Storage _storage;
    [SerializeField] private ConveyorScript _conveyorScript1;
    [SerializeField] private ConveyorScript _conveyorScript2;
    
    private bool _upgradeMenuIsOpened;
    private int _speedLevel;

    void Start()
    {
        _upgradeMenuIsOpened = false;
        _buttonUpgradeMenu.onClick.AddListener(ButtonUpgradeMenu);
        _buttonSpeedUpgrade.onClick.AddListener(ButtonSpeedUpgrade);
    }

    private void ButtonUpgradeMenu()
    {
        if (!_upgradeMenuIsOpened)
        {
            _upgradeMenuIsOpened = true;
            _UpgradeMenu.SetActive(true);
        }
        else
        {
            _upgradeMenuIsOpened = false;
            _UpgradeMenu.SetActive(false);
        }
    }

    private void ButtonSpeedUpgrade()
    {
        if(_storage.money >= _storage.speedUpdatesCosts[_speedLevel])
        {
            _storage.money -= _storage.speedUpdatesCosts[_speedLevel];
            _conveyorScript1.SpeedUpgrade(_storage.speedUpdates[_speedLevel]);
            _conveyorScript2.SpeedUpgrade(_storage.speedUpdates[_speedLevel]);
            _speedLevel++;
        }
    }
}
