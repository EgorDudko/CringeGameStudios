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
    [SerializeField] private float _clickCooldown;


    private int _money = 0;
    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _isClickCooldown;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (!_isClickCooldown && Input.GetMouseButtonDown(0))
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray, out _hit, 100))
            {
                if (_hit.transform.tag == "ObjectForClick")
                {
                    Instantiate(_cargo, _cargoSpawn.transform.position, _cargoSpawn.transform.rotation);
                    StartCoroutine(ClickCooldown());
                }
            }
        }
    }

    IEnumerator ClickCooldown()
    {
        _isClickCooldown = true;
        yield return new WaitForSeconds(_clickCooldown);
        _isClickCooldown = false;
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
