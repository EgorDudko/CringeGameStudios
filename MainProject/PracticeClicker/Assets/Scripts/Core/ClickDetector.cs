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


    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.nearClipPlane = -2f;
        _lastClickPastTime = 100;
        _mainCamera = Camera.main;
    }
    void Update()
    {
        _lastClickPastTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (_lastClickPastTime <= _autoclickCheatDetector & Time.deltaTime == 1)
            {
                Debug.Log("AUTO-CLICK DETECTED!!!!!");
                _autoclickPanel.SetActive(true);
                _storage.money = 0;
            }
            if (!_itemDetectorCoolDown._isClickCooldown)
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 100))
                {
                    TabletTransition t;
                    if (_hit.transform.GetComponent<ButtonExit>())
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
                }
            }

            _lastClickPastTime = 0f;
        }
    }
}
