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
    [SerializeField] private Storage _storage;
    [SerializeField] private AudioSource _buyAudioSource;

    void Start()
    {
        _speedUpdateButton.onClick.AddListener(SpeedUpgrade);
        _valueUpdateButton.onClick.AddListener(ValueUpgrade);
        _capacityUpdateButton.onClick.AddListener(CapacityUpgrade);

        _storage.TruckCapacity = _storage.TruckCapacityUpgrades[_storage.TruckCapacityLevel];
        _storage.ItemsValue = _storage.ValueUpgrades[_storage.ValueLevel];
        _storage.conveyorSpeed = _storage.SpeedUpgrades[_storage.SpeedLevel];

        _speedUpgradeCostText.text = _storage.SpeedUpgradesCosts[_storage.SpeedLevel].ToString() + " $";
        _valueUpgradeCostText.text = _storage.ValueUpgradesCosts[_storage.ValueLevel].ToString() + " $";
        _capacityUpgradeCostText.text = _storage.TruckCapacityCosts[_storage.TruckCapacityLevel].ToString() + " $";
    }

    private void SpeedUpgrade()
    {
        if (_storage.Money >= _storage.SpeedUpgradesCosts[_storage.SpeedLevel])
        {
            _storage.Money -= _storage.SpeedUpgradesCosts[_storage.SpeedLevel];
            _storage.SpeedLevel++;
            _storage.conveyorSpeed = _storage.SpeedUpgrades[_storage.SpeedLevel];
            _speedUpgradeCostText.text = _storage.SpeedUpgradesCosts[_storage.SpeedLevel].ToString() + " $";
            _buyAudioSource.Play();
        }
        if (_storage.SpeedLevel + 1 >= _storage.SpeedUpgrades.Length)
        {
            _speedUpdateButton.interactable = false;
            _speedFullUpdate.SetActive(true);
        }
    }

    private void ValueUpgrade()
    {
        if (_storage.Money >= _storage.ValueUpgradesCosts[_storage.ValueLevel])
        {
            _storage.Money -= _storage.ValueUpgradesCosts[_storage.ValueLevel];
            _storage.ValueLevel++;
            _storage.ItemsValue = _storage.ValueUpgrades[_storage.ValueLevel];
            _valueUpgradeCostText.text = _storage.ValueUpgradesCosts[_storage.ValueLevel].ToString() + " $";
            _buyAudioSource.Play();
        }
        if (_storage.ValueLevel + 1 >= _storage.ValueUpgrades.Length)
        {
            _valueUpdateButton.interactable = false;
            _valueFullUpdate.SetActive(true);
        }
    }

    private void CapacityUpgrade()
    {
        if (_storage.Money >= _storage.TruckCapacityCosts[_storage.TruckCapacityLevel])
        {
            _storage.Money -= _storage.TruckCapacityCosts[_storage.TruckCapacityLevel];
            _storage.TruckCapacityLevel++;
            _storage.TruckCapacity = _storage.TruckCapacityUpgrades[_storage.TruckCapacityLevel];
            _capacityUpgradeCostText.text = _storage.TruckCapacityCosts[_storage.TruckCapacityLevel].ToString() + " $";
            _buyAudioSource.Play();
        }
        if (_storage.TruckCapacityLevel + 1 >= _storage.TruckCapacityUpgrades.Length)
        {
            _capacityUpdateButton.interactable = false;
            _capacityFullUpdate.SetActive(true);
        }
    }
}
