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
                _transitionCoroutine = StartCoroutine(TransitionCoroutine(_packagingSectionCameraPosition, -2, 1,4));
                break;
            case Transition.Cabinet:
                _outline.SetActive(true);
                _transitionCoroutine = StartCoroutine(TransitionCoroutine(_cabinetCameraPosition, 2, 0,4));
                break;
            case Transition.Computer:
                _outline.SetActive(false);
                _transitionCoroutine = StartCoroutine(TransitionCoroutine(_computerCameraPosition, 0, 0,1));
                break;
        }
    }

    private IEnumerator TransitionCoroutine(Transform destination, float nearClipPlane, float finalTimeScale, float orthographicSize)
    {
        Time.timeScale = 1;
        Camera.main.nearClipPlane = nearClipPlane;
        while (transform.position != destination.position & transform.rotation != destination.rotation)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, orthographicSize, 0.1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, destination.rotation, _TransitionSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, destination.position, _TransitionSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        Time.timeScale = finalTimeScale;
    }
}
