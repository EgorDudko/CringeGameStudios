using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTransition : MonoBehaviour
{
    [SerializeField] private GameObject _tablet;
    [SerializeField] private GameObject _screen;
    [SerializeField] private Transform _closedTabletPosition;
    [SerializeField] private Transform _openedTabletPosition;
    [SerializeField] private float _TransitionSpeed;

    private Transform _tabletDestination;
    private Coroutine _tabletTransitionCoroutine;

    private void Start()
    {
        _tabletDestination = _closedTabletPosition;
    }

    public void MoveTablet()
    {
        if (_tabletTransitionCoroutine != null)
        {
            StopCoroutine(_tabletTransitionCoroutine);
        }
        _tabletTransitionCoroutine = StartCoroutine(TabletTransitionCoroutine());
    }

    IEnumerator TabletTransitionCoroutine()
    {
        Transform _tabletT = _tablet.transform;

        if (_tabletDestination == _openedTabletPosition)
        {
            _screen.SetActive(false);
            _tabletDestination = _closedTabletPosition;
        }
        else
        {
            _screen.SetActive(true);
            _tabletDestination = _openedTabletPosition;
        }
        while (_tabletT.position != _tabletDestination.position & _tabletT.rotation != _tabletDestination.rotation)
        {
            _tabletT.rotation = Quaternion.Slerp(_tabletT.rotation, _tabletDestination.rotation, _TransitionSpeed * Time.deltaTime);
            _tabletT.position = Vector3.Lerp(_tabletT.position, _tabletDestination.position, _TransitionSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
