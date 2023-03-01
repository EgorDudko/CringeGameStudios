using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClickBoxSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnHeight;
    [SerializeField] private float _boxScale;
    [SerializeField] private GameObject _box;

    private Ray _ray;
    private RaycastHit _hit;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 100))
            {
                GameObject box = Instantiate(_box, new Vector3(_hit.point.x, _spawnHeight, _hit.point.z), transform.rotation);
                box.transform.localScale = box.transform.localScale * _boxScale;
            }
        }

    }
}
