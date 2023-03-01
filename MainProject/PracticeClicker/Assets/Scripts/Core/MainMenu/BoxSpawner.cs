using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private float _cooldown;

    private float _spawnTime;

    private void Start()
    {
        _spawnTime = 0;
    }

    void Update()
    {
        _spawnTime += Time.deltaTime;
        if (_spawnTime > _cooldown)
        {
            GameObject box = Instantiate(_box,transform.position,transform.rotation);
            box.transform.localScale = transform.localScale;
            _spawnTime = 0;
        }
    }

}
