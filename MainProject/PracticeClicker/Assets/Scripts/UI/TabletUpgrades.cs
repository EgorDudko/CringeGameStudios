using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabletUpgrades : MonoBehaviour
{
    [SerializeField] private Button _speedUpdateButton;
    [SerializeField] private Button _valueUpdateButton;
    [SerializeField] private Button _capacityUpdateButton;
    [SerializeField] private TMP_Text _speedUpgradeCostText;
    [SerializeField] private TMP_Text _valueUpgradeCostText;
    [SerializeField] private TMP_Text _capacityUpgradeCostText;
    [SerializeField] private GameObject _speedFullUpdate;
    [SerializeField] private GameObject _valueFullUpdate;
    [SerializeField] private GameObject _capacityFullUpdate;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Storage _storage;
    [SerializeField] private AudioSource _buyAudioSource;

    void Start()
    {
        _speedUpdateButton.onClick.AddListener(SpeedUpgrade);
        _valueUpdateButton.onClick.AddListener(ValueUpgrade);
        _capacityUpdateButton.onClick.AddListener(CapacityUpgrade);

        _storage.truckCapacity = _storage.truckCapacityUpgrades[_storage.truckCapacityLevel];
        _storage.itemsValue = _storage.valueUpgrades[_storage.valueLevel];
        _storage.conveyorSpeed = _storage.speedUpgrades[_storage.speedLevel];

        _speedUpgradeCostText.text = _storage.speedUpgradesCosts[_storage.speedLevel].ToString() + " $";
        _valueUpgradeCostText.text = _storage.valueUpgradesCosts[_storage.valueLevel].ToString() + " $";
        _capacityUpgradeCostText.text = _storage.truckCapacityCosts[_storage.truckCapacityLevel].ToString() + " $";
    }

    private void SpeedUpgrade()
    {
        if (_storage.money >= _storage.speedUpgradesCosts[_storage.speedLevel])
        {
            _storage.money -= _storage.speedUpgradesCosts[_storage.speedLevel];
            _storage.speedLevel++;
            _storage.conveyorSpeed = _storage.speedUpgrades[_storage.speedLevel];
            _speedUpgradeCostText.text = _storage.speedUpgradesCosts[_storage.speedLevel].ToString() + " $";
            _moneyText.text = "Money: " + _storage.money + " $";
            _buyAudioSource.Play();
        }
        if (_storage.speedLevel + 1 >= _storage.speedUpgrades.Length)
        {
            _speedUpdateButton.interactable = false;
            _speedFullUpdate.SetActive(true);
        }
    }

    private void ValueUpgrade()
    {
        if (_storage.money >= _storage.valueUpgradesCosts[_storage.valueLevel])
        {
            _storage.money -= _storage.valueUpgradesCosts[_storage.valueLevel];
            _storage.valueLevel++;
            _storage.itemsValue = _storage.valueUpgrades[_storage.valueLevel];
            _valueUpgradeCostText.text = _storage.valueUpgradesCosts[_storage.valueLevel].ToString() + " $";
            _moneyText.text = "Money: " + _storage.money + " $";
            _buyAudioSource.Play();
        }
        if (_storage.valueLevel + 1 >= _storage.valueUpgrades.Length)
        {
            _valueUpdateButton.interactable = false;
            _valueFullUpdate.SetActive(true);
        }
    }

    private void CapacityUpgrade()
    {
        if (_storage.money >= _storage.truckCapacityCosts[_storage.truckCapacityLevel])
        {
            _storage.money -= _storage.truckCapacityCosts[_storage.truckCapacityLevel];
            _storage.truckCapacityLevel++;
            _storage.truckCapacity = _storage.truckCapacityUpgrades[_storage.truckCapacityLevel];
            _capacityUpgradeCostText.text = _storage.truckCapacityCosts[_storage.truckCapacityLevel].ToString() + " $";
            _moneyText.text = "Money: " + _storage.money + " $";
            _buyAudioSource.Play();
        }
        if (_storage.truckCapacityLevel + 1 >= _storage.truckCapacityUpgrades.Length)
        {
            _capacityUpdateButton.interactable = false;
            _capacityFullUpdate.SetActive(true);
        }
    }
}
