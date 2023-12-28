using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObstacleMovement : MonoBehaviour
{
    [Header("Dependencies")] 
    [SerializeField] private Transform _obstacleTransform;
    [SerializeField] private Transform _spawnerTransform;

    [Header("Values")] 
    [SerializeField] private float _velocity;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _lifeTime;

    [HideInInspector] public float time;
    
    public void OnEnable()
    { 
        _spawnerTransform = _obstacleTransform;
        ResetObstacle();
        SetRandomHeight();
    }

    public void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            gameObject.SetActive(false);
            time = _lifeTime;
            gameObject.SetActive(true);
        }
        _obstacleTransform.position += Vector3.left * (_velocity * Time.fixedDeltaTime);
    }

    private void SetRandomHeight()
    {
        _obstacleTransform.position = new Vector3(0, Random.Range(_minHeight, _maxHeight), 0);
    }

    private void ResetObstacle()
    {
        _obstacleTransform = _spawnerTransform;
    }
}
