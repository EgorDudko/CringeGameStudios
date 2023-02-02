using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [Header("---Items Spawning---")]
    [SerializeField] private GameObject _itemsSpawn;
    [SerializeField] private GameObject[] _items;
    [Header("---Hint for click---")]
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private float _timeForHint;
    [SerializeField] private float _hintTransparancy;
    [SerializeField] private float _hintTextTransparancy;
    [SerializeField] private TMP_Text _hintText;
    [Header("---Cooldown indicator---")]
    [SerializeField] private GameObject _cooldownColoredIndicator;
    [SerializeField] private Material _redIndicator;
    [SerializeField] private Material _greenIndicator;
    [Header("---Cheat detector---")]
    [SerializeField] private float _autoclickCheatDetector;

    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private float _lastClickPastTime;
    private MeshRenderer _hintMeshRender;
    private TextMeshProUGUI _hintTextMesh;
    private Color _hintColor;
    private Color _hintTextColor;


    void Start()
    {
        _lastClickPastTime = 100;
        _mainCamera = Camera.main;
        _hintMeshRender = GetComponent<MeshRenderer>();
        _hintTextMesh = _hintText.GetComponent<TextMeshProUGUI>();
        _hintColor = _hintMeshRender.material.color;
        _hintTextColor = _hintTextMesh.color;
    }

    private void FixedUpdate()
    {
        if (_lastClickPastTime > _timeForHint && _hintMeshRender.material.color.a != _hintTransparancy)
        {
            _hintColor.a = Mathf.Lerp(_hintColor.a, _hintTransparancy, _lerpSpeed);
            _hintMeshRender.material.color = _hintColor;
            _hintTextColor.a = Mathf.Lerp(_hintTextColor.a, _hintTextTransparancy, _lerpSpeed); ;
            _hintTextMesh.color = _hintTextColor;
        }
        else if(_lastClickPastTime <= _timeForHint && _hintMeshRender.material.color.a != 0)
        {
            _hintColor.a = Mathf.Lerp(_hintColor.a, 0, _lerpSpeed*2);
            _hintMeshRender.material.color = _hintColor;
            _hintTextColor.a = Mathf.Lerp(_hintTextColor.a, 0, _lerpSpeed*2);
            _hintTextMesh.color = _hintTextColor;
        }
    }
    void Update()
    {
        _lastClickPastTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (_lastClickPastTime <= _autoclickCheatDetector)
            {
                Debug.Log("AUTO-CLICK DETECTED!!!!!");
            }

            if (!ItemDetectorCoolDown.isCoolDown)
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 100))
                {
                    if (_hit.transform.GetComponent<ClickDetector>())
                    {
                        //_hintColor.a = 0;
                        //_hintTextColor.a = 0;
                        //_hintMeshRender.material.color = _hintColor;
                        //_hintTextMesh.color = _hintTextColor;
                        Instantiate(_items[Random.Range(0, _items.Length)], _itemsSpawn.transform.position, _itemsSpawn.transform.rotation);
                    }
                }
            }

            _lastClickPastTime = 0f;
        }
    }
}
