using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] private int _obstaclesAmount;
    [SerializeField] private float _timeToActivate = 2.0f;

    [SerializeField] private float _posX = 10;
    [SerializeField] private float _posYMax = 2.0f;
    [SerializeField] private float _posYMin = -3.0f;
    
    private float _timeLapsed;
    private int _obstacleCount;

    private GameObject[] _obstaclesArray;

    private void Awake()
    {
        _obstaclesArray = new GameObject[_obstaclesAmount];
        
    }

    void Start()
    {
        Generator(_obstaclePrefab);
    }

    void Update()
    {
        _timeLapsed += Time.deltaTime;

        if (_timeLapsed > _timeToActivate)
        {
            ShowObstacle();

        }

    }

    private void ShowObstacle()
    {
       
        float yPos = UnityEngine.Random.Range(_posYMin,_posYMax);

        _obstaclesArray[_obstacleCount].transform.position = new Vector2(_posX, yPos);

        if (!_obstaclesArray[_obstacleCount].activeSelf)
        {
            _obstaclesArray[_obstacleCount].SetActive(true);

        }

        _timeLapsed = 0;
        _obstacleCount++;

        if (_obstacleCount == _obstaclesAmount)
        {
            _obstacleCount = 0;
        }
    }

    private void Generator(GameObject gameObject)
    {
        for (int i = 0; i < _obstaclesArray.Length; i++)
        {
            GameObject Obstaculo =  Instantiate(gameObject, transform);
            Obstaculo.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Obstaculo.SetActive(false);
            _obstaclesArray[i] = Obstaculo;

        }
    }
}
