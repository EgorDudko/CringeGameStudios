using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxEatingScript : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private TMP_Text _moneytext;
    [SerializeField] private string _changeMoneytext;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoxCollider>())
        {
            Destroy(other.gameObject);
            GiveMoney();
        }
    }

    private void GiveMoney()
    {
        _storage.money += _storage.itemsValue;
        _moneytext.text = _changeMoneytext + _storage.money;
    }
}
