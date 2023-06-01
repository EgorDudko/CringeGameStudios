using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FunnelFreedUp : MonoBehaviour
{
    [SerializeField] private int _maxCoolDownTime;
    [SerializeField] private Storage _storage;
    [SerializeField] private GameObject _timerCoolDown;
    [SerializeField] private GameObject _panelFreedUp;
    [SerializeField] private TMP_Text _timertext;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private ConveyorScript[] _speedConveyor;

    private int _cost;

    private void Awake()
    {
        _cost = (_storage.ValueLevel+1) * 100;
        _costText.text = _cost + "$";
    }

    public void FreedUp()
    {
        if (_storage.Money > _cost)
        {
            _storage.Money -= _cost;
            for (int i = 0; i < _speedConveyor.Length; i++)
            {
                _speedConveyor[i].SpeedUp(15);
            }
            _cost = (_storage.SpeedLevel + 1) * 100;
            _costText.text = _cost + "$";
            StartCoroutine(CoolDownCoroutine());
        }
    }

    private IEnumerator CoolDownCoroutine()
    {
        _timerCoolDown.SetActive(true);
        _panelFreedUp.SetActive(false);
        for (int i = _maxCoolDownTime; i > 0; i--)
        {
            _timertext.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        _timerCoolDown.SetActive(false);
        _panelFreedUp.SetActive(true);
    }
}
