using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [SerializeField] private float _autoclickCheatDetector;
    [SerializeField] private GameObject _autoclickPanel;
    [SerializeField] private CameraTransitions _cameraTransitions;
    [SerializeField] private Storage _storage;
    [SerializeField] private ItemDetectorCoolDown _itemDetectorCoolDown;
    [SerializeField] private AudioSource _clickAudioSource;


    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private float _lastClickPastTime;
    private int _fastClickCount;


    void Start()
    {
        _fastClickCount = 0;
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
            if (_lastClickPastTime <= _autoclickCheatDetector && Time.timeScale == 1)
            {
                _fastClickCount++;
                if (_fastClickCount>5) 
                {
                    Debug.Log("AUTO-CLICK DETECTED!!!!!");
                    _autoclickPanel.SetActive(true);
                    Time.timeScale = 0;
                    _storage.Money = 0;
                }
            }
            else
            {
                _fastClickCount = 0;
            }
            if (!_itemDetectorCoolDown._isClickCooldown)
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 100))
                {
                    TabletTransition t;
                    if (_hit.transform.GetComponent<ButtonExit>())
                    {
                        _clickAudioSource.Play();
                        Exit();
                    }
                    else if (_hit.transform.GetComponent<ButtonCabinet>())
                    {
                        _clickAudioSource.Play();
                        _cameraTransitions.StartTransition(CameraTransitions.Transition.Cabinet);
                    }
                    else if (_hit.transform.GetComponent<ButtonPackagingSection>())
                    {
                        _clickAudioSource.Play();
                        _cameraTransitions.StartTransition(CameraTransitions.Transition.PackagingSection);
                    }
                    else if (_hit.transform.GetComponent<OutlineObject>())
                    {
                        _clickAudioSource.Play();
                        _cameraTransitions.StartTransition(CameraTransitions.Transition.Computer);
                    }
                    else if (t = _hit.transform.GetComponent<TabletTransition>())
                    {
                        _clickAudioSource.Play();
                        t.MoveTablet();
                    }
                }
            }

            _lastClickPastTime = 0f;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
