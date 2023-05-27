using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [Header("---Items Spawning---")]
    [SerializeField] private GameObject _itemsSpawn;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private GameObject _BuffSpawn1;
    [SerializeField] private GameObject _BuffSpawn2;
    [SerializeField] private GameObject _BuffSpawn3;
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
    [Header("---For Upgrades---")]
    [SerializeField] private TMP_Text _moneytext;
    [SerializeField] private TMP_Text _speedUpgradeCostText;
    [SerializeField] private TMP_Text _valueUpgradeCostText;
    [SerializeField] private string _changeMoneytext;
    [Header("---CameraTransitions---")]
    [SerializeField] private Transform _cabinetCameraPosition;
    [SerializeField] private Transform _packagingSectionCameraPosition;
    [SerializeField] private float _TransitionSpeed;
    [Header("---Other Scripts---")]
    [SerializeField] private Storage _storage;
    [SerializeField] private ItemDetectorCoolDown _itemDetectorCoolDown;


    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private float _lastClickPastTime;
    private float _conveyorSpeed;
    private float _boxSpawnCoolDown;
    private MeshRenderer _hintMeshRender;
    private TextMeshProUGUI _hintTextMesh;
    private Color _hintColor;
    private Color _hintTextColor;
    private bool _hintIsCliked;
    private bool _hintIsAppearing;
    private bool _buffIsWorking;
    private Coroutine _cabinetTransitionCoroutine;
    private Coroutine _packagingSectionTransitionCoroutine;



    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.nearClipPlane = -2f;
        _boxSpawnCoolDown = _storage.boxSpawnCoolDown;
        _conveyorSpeed = _storage.conveyorSpeed;
        _hintIsCliked = false;
        _lastClickPastTime = 100;
        _mainCamera = Camera.main;
        _hintMeshRender = GetComponent<MeshRenderer>();
        _hintTextMesh = _hintText.GetComponent<TextMeshProUGUI>();
        _hintColor = _hintMeshRender.material.color;
        _hintTextColor = _hintTextMesh.color;
    }

    private void FixedUpdate()
    {
            if (_lastClickPastTime > _timeForHint && _hintMeshRender.material.color.a != _hintTransparancy || _hintIsAppearing && _lastClickPastTime > _timeForHint)
            {
                _hintIsAppearing = true;
                _hintColor.a = Mathf.Lerp(_hintColor.a, _hintTransparancy, _lerpSpeed);
                _hintMeshRender.material.color = _hintColor;
                _hintTextColor.a = Mathf.Lerp(_hintTextColor.a, _hintTextTransparancy, _lerpSpeed); ;
                _hintTextMesh.color = _hintTextColor;
            }
            else if (_lastClickPastTime <= _timeForHint && _hintMeshRender.material.color.a != 0 && _hintIsCliked || !_hintIsAppearing && _lastClickPastTime <= _timeForHint)
            {
                _hintIsAppearing = false;
                _hintColor.a = Mathf.Lerp(_hintColor.a, 0, _lerpSpeed * 2);
                _hintMeshRender.material.color = _hintColor;
                _hintTextColor.a = Mathf.Lerp(_hintTextColor.a, 0, _lerpSpeed * 2);
                _hintTextMesh.color = _hintTextColor;
            }
    }
    void Update()
    {
        _lastClickPastTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (_lastClickPastTime <= _autoclickCheatDetector & Time.deltaTime == 1)
            {
                Debug.Log("AUTO-CLICK DETECTED!!!!!");
            }

            if (!_itemDetectorCoolDown._isClickCooldown)
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 100))
                {
                    TabletTransition t;
                    if (_hit.transform.GetComponent<ClickDetector>())
                    {
                        _hintIsCliked = true;
                        Instantiate(_items[Random.Range(0, _items.Length)], _itemsSpawn.transform.position, _itemsSpawn.transform.rotation);
                    }
                    else if (_hit.transform.GetComponent<BuffButton>() & !_buffIsWorking)
                    {
                        StartCoroutine(BuffCoroutine());
                    }
                    else if (_hit.transform.GetComponent<ButtonCabinet>())
                    {
                        if(_packagingSectionTransitionCoroutine != null)
                        {
                            StopCoroutine(_packagingSectionTransitionCoroutine);
                        }
                        _cabinetTransitionCoroutine = StartCoroutine(CabinetTransition());
                    }
                    else if (_hit.transform.GetComponent<ButtonExit>())
                    {
                        Application.Quit();
                    }
                    else if (_hit.transform.GetComponent<ButtonPackagingSection>())
                    {
                        Time.timeScale = 1;
                        if (_cabinetTransitionCoroutine != null)
                        {
                            StopCoroutine(_cabinetTransitionCoroutine);
                        }
                        _packagingSectionTransitionCoroutine = StartCoroutine(PackagingSectionTransition());
                    }
                    else if (t = _hit.transform.GetComponent<TabletTransition>())
                    {
                        t.MoveTablet();
                    }
                    else
                        _hintIsCliked = false;
                }
                else
                    _hintIsCliked = false;
            }
            else
                _hintIsCliked = false;

            _lastClickPastTime = 0f;
        }
    }

    IEnumerator CabinetTransition()
    {
        while (_mainCamera.gameObject.transform.position != _cabinetCameraPosition.position & _mainCamera.gameObject.transform.rotation != _cabinetCameraPosition.rotation)
        {
            _mainCamera.gameObject.transform.rotation = Quaternion.Slerp(_mainCamera.gameObject.transform.rotation, _cabinetCameraPosition.rotation, _TransitionSpeed * Time.deltaTime);
            _mainCamera.gameObject.transform.position = Vector3.Lerp(_mainCamera.gameObject.transform.position, _cabinetCameraPosition.position, _TransitionSpeed * Time.deltaTime);
            yield return null;
        }
        Time.timeScale = 0;
    }
    IEnumerator PackagingSectionTransition()
    {
        while (_mainCamera.gameObject.transform.position != _packagingSectionCameraPosition.position & _mainCamera.gameObject.transform.rotation != _packagingSectionCameraPosition.rotation)
        {
            _mainCamera.gameObject.transform.rotation = Quaternion.Slerp(_mainCamera.gameObject.transform.rotation, _packagingSectionCameraPosition.rotation, _TransitionSpeed * Time.deltaTime);
            _mainCamera.gameObject.transform.position = Vector3.Lerp(_mainCamera.gameObject.transform.position, _packagingSectionCameraPosition.position, _TransitionSpeed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator BuffCoroutine()
    {
        _buffIsWorking = true;
        float conveyorSpeed = _storage.conveyorSpeed;
        _storage.conveyorSpeed *= 5;
        _storage.boxSpawnCoolDown /= 5;
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn1.transform.position, _BuffSpawn1.transform.rotation);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn2.transform.position, _BuffSpawn2.transform.rotation);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn3.transform.position, _BuffSpawn3.transform.rotation);
        }
        yield return new WaitForSeconds(12);
        _storage.conveyorSpeed = conveyorSpeed;
        _buffIsWorking = false;
    }
}
