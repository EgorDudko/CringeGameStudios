using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitions : MonoBehaviour
{
    public enum Transition
    {
        PackagingSection,
        Cabinet,
        Computer
    }

    [SerializeField] private float _TransitionSpeed;
    [SerializeField] private Transform _cabinetCameraPosition;
    [SerializeField] private Transform _packagingSectionCameraPosition;
    [SerializeField] private Transform _computerCameraPosition;
    [SerializeField] private GameObject _outline;

    private Coroutine _transitionCoroutine;

    public void StartTransition(Transition transition)
    {
        if (_transitionCoroutine != null)
        {
            StopCoroutine(_transitionCoroutine);
        }
        switch (transition)
        {
            case Transition.PackagingSection:
                _transitionCoroutine = StartCoroutine(PackagingSectionTransition());
                break;
            case Transition.Cabinet:
                _transitionCoroutine = StartCoroutine(CabinetTransition());
                break;
            case Transition.Computer:
                _transitionCoroutine = StartCoroutine(ComputerTransition());
                break;
        }
    }

    private IEnumerator ComputerTransition()
    {
        _outline.SetActive(false);
        Time.timeScale = 1;
        Camera.main.nearClipPlane = 0;
        while (transform.position != _computerCameraPosition.position & transform.rotation != _computerCameraPosition.rotation)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 1, 0.1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, _computerCameraPosition.rotation, _TransitionSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, _computerCameraPosition.position, _TransitionSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        Time.timeScale = 0;
    }
    private IEnumerator CabinetTransition()
    {
        _outline.SetActive(true);
        Camera.main.nearClipPlane = 1;
        while (gameObject.transform.position != _cabinetCameraPosition.position & gameObject.transform.rotation != _cabinetCameraPosition.rotation)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 4, 0.1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, _cabinetCameraPosition.rotation, _TransitionSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, _cabinetCameraPosition.position, _TransitionSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        Time.timeScale = 0;
    }
    private IEnumerator PackagingSectionTransition()
    {
        Time.timeScale = 1;
        Camera.main.nearClipPlane = -2;
        while (gameObject.transform.position != _packagingSectionCameraPosition.position & transform.rotation != _packagingSectionCameraPosition.rotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _packagingSectionCameraPosition.rotation, _TransitionSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, _packagingSectionCameraPosition.position, _TransitionSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
