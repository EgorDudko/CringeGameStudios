using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderers;

    private Color[] _deafultColors;

    private void Start()
    {
        _deafultColors = new Color[_meshRenderers.Length];
        for (int i = 0; i < _meshRenderers.Length; i++) 
        {
            _deafultColors[i] = _meshRenderers[i].material.color;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            if (_meshRenderers[i] == null) return;
            _meshRenderers[i].material.color = _deafultColors[i];
        }
    }

    private void OnMouseOver()
    {
        if (_meshRenderers[0].material.color.r - _deafultColors[0].r >= 0.3f) return;

        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            if (_meshRenderers[i].material.color.r - _deafultColors[i].r < 0.3f) 
                _meshRenderers[i].material.color = new Color(_meshRenderers[i].material.color.r + 0.01f, _meshRenderers[i].material.color.g + 0.01f, _meshRenderers[i].material.color.b + 0.01f);
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            _meshRenderers[i].material.color = _deafultColors[i];
        }
    }
}
