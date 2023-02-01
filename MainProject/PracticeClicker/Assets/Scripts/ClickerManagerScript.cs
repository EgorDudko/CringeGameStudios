using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerManagerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneytext;
    [SerializeField] private string _changeMoneytext;
    [SerializeField] private GameObject _cargoSpawn;
    [SerializeField] private GameObject _cargo;


    private int _money = 0;
    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray, out _hit, 100))
            {
                if (_hit.transform.tag == "ObjectForClick")
                {
                    Instantiate(_cargo, _cargoSpawn.transform.position, _cargoSpawn.transform.rotation);
                }
            }
        }
    }

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
