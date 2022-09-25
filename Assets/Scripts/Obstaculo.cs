using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _RB;
    private Player _player;

    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        if (!_player.IsDead)
        {
            _RB.velocity = Vector2.left * _movementSpeed * Time.deltaTime;

        }
        else
        {
            _RB.velocity = Vector2.zero;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore();

        }
    }
}
