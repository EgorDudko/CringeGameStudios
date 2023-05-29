using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [Header("---Hint for click---")]
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private float _timeForHint;
    [SerializeField] private float _hintTransparancy;
    [SerializeField] private float _hintTextTransparancy;
    [SerializeField] private TMP_Text _hintText;
    [Header("---Cheat detector---")]
    [SerializeField] private float _autoclickCheatDetector;
    [SerializeField] private GameObject _autoclickPanel;
    [Header("---CameraTransitions---")]
    [SerializeField] private CameraTransitions _cameraTransitions;
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
                    }
                    else if (_hit.transform.GetComponent<ButtonExit>())
                    {
                        Application.Quit();
                    }
                    else if (_hit.transform.GetComponent<ButtonCabinet>())
                    {
                        _cameraTransitions.StartTransition(CameraTransitions.Transition.Cabinet);
                    }
                    else if (_hit.transform.GetComponent<ButtonPackagingSection>())
                    {
                        _cameraTransitions.StartTransition(CameraTransitions.Transition.PackagingSection);
                    }
                    else if (_hit.transform.GetComponent<OutlineObject>())
                    {
                        _cameraTransitions.StartTransition(CameraTransitions.Transition.Computer);
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
}
