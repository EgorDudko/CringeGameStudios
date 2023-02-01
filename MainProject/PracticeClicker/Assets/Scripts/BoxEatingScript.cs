using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxEatingScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneytext;
    [SerializeField] private string _changeMoneytext;

    private int _money = 0;

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
        _money++;
        _moneytext.text = _changeMoneytext + _money;
    }
}
