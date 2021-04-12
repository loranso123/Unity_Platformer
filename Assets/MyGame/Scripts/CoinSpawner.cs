using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _coinSpawnPoints;

    private GameObject _coinOnScene;
    private Transform[] _spownPoints;

    private void Start()
    {
        _spownPoints = new Transform[_coinSpawnPoints.childCount];

        for (int i = 0; i < _coinSpawnPoints.childCount; i++)
        {
            _spownPoints[i] = _coinSpawnPoints.GetChild(i);
        }

        for (int i = 0; i < _spownPoints.Length; i++)
        {
            _coinOnScene = Instantiate(_coin, _spownPoints[i].position, Quaternion.identity);
        }

    }
}
