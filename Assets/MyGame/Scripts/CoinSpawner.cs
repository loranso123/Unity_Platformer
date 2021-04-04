using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _enemySpawnPoints;
    private GameObject coin;
    private Transform[] _spownPoints;

    private void Start()
    {
        _spownPoints = new Transform[_enemySpawnPoints.childCount];

        for (int i = 0; i < _enemySpawnPoints.childCount; i++)
        {
            _spownPoints[i] = _enemySpawnPoints.GetChild(i);
        }

        for (int i = 0; i < _spownPoints.Length; i++)
        {
            coin = Instantiate(_coin, _spownPoints[i].position, Quaternion.identity);
        }

    }
}
