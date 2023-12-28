using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Dependencies")] 
    [SerializeField] private GameObject _obstaclePrefab;

    [Header("Values")]
    [SerializeField] private int _obstaclesToSpawn;
    [SerializeField] private float _timeBetweenSpawn;

    private List<GameObject> _obstacles;
    private int _obstacleIndex;
        
    private void Start()
    {
        _obstacles = new List<GameObject>();
        for (int i = 0; i < _obstaclesToSpawn; i++)
        {
            var obj = Instantiate(_obstaclePrefab);
            _obstacles.Add(obj);
        }
        InvokeRepeating("EnableObstacles", 0f, _timeBetweenSpawn);
    }

    private void EnableObstacles()
    {
        if (_obstacleIndex >= _obstacles.Count)
        {
            CancelInvoke();
            return;
        }
        _obstacles[_obstacleIndex].SetActive(true);
        _obstacleIndex++;
    }
}
