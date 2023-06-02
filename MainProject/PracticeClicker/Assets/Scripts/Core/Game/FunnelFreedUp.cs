using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FunnelFreedUp : MonoBehaviour
{
    public int Cost 
    {
        get => _cost;
        set
        {
            _cost = (_storage.ValueLevel + 1) * 100;
            _costText.text = _cost + "$";
        }
    }

    [SerializeField] private int _freedUpTime = 20;
    [SerializeField] private Storage _storage;
    [SerializeField] private GameObject _timerCoolDown;
    [SerializeField] private GameObject _panelFreedUp;
    [SerializeField] private TMP_Text _timertext;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private ConveyorScript[] _speedConveyor;

    private int _cost;

    private void Awake()
    {
        Cost = 1;
    }

    public void FreedUp()
    {
        if (_storage.Money > _cost)
        {
            _storage.Money -= _cost;
            for (int i = 0; i < _speedConveyor.Length; i++)
            {
                _speedConveyor[i].SpeedUp(_freedUpTime);
            }
            Cost = 1;
            StartCoroutine(CoolDownCoroutine());
        }
    }

    private IEnumerator CoolDownCoroutine()
    {
        _timerCoolDown.SetActive(true);
        _panelFreedUp.SetActive(false);
        for (int i = _freedUpTime; i > 0; i--)
        {
            _timertext.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        _timerCoolDown.SetActive(false);
        _panelFreedUp.SetActive(true);
    }
}
