using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    private int _points = 0;


    public static GameManager Instance { get { return _instance; } }

    public int Points { get => _points; set => _points = value; }

    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public bool _isGameOver;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance ==null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }

    private void Start()
    {
        _scoreText.text = "Score: " + Points;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGameOver)
        {
            StartCoroutine("RestartLevel");
        }
    }



    public void GameOver()
    {
        _isGameOver = true;
        _gameOverText.SetActive(true);

    }


    public void AddScore()
    {
        Points++;
        _scoreText.text = "Score: " + Points;

    }


    private IEnumerator RestartLevel()
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

}
