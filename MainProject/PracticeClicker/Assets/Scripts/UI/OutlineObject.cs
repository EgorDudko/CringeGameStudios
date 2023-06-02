using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private int _materialIndex;

    private Color[] _deafultColors;

    private void Start()
    {
        _deafultColors = new Color[_meshRenderers.Length];
        for (int i = 0; i < _meshRenderers.Length; i++) 
        {
            _deafultColors[i] = _meshRenderers[i].materials[_materialIndex].color;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            if (_meshRenderers[i] == null) return;
            _meshRenderers[i].materials[_materialIndex].color = _deafultColors[i];
        }
    }

    private void OnMouseOver()
    {
        if (_meshRenderers[0].materials[_materialIndex].color.r - _deafultColors[0].r >= 0.3f) return;

        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            if (_meshRenderers[i].materials[_materialIndex].color.r - _deafultColors[i].r < 0.3f) 
                _meshRenderers[i].materials[_materialIndex].color = 
                    new Color(_meshRenderers[i].materials[_materialIndex].color.r 
                    + 0.01f, _meshRenderers[i].materials[_materialIndex].color.g 
                    + 0.01f, _meshRenderers[i].materials[_materialIndex].color.b + 0.01f);
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            _meshRenderers[i].materials[_materialIndex].color = _deafultColors[i];
        }
    }
}
