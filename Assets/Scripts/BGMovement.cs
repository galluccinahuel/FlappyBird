using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BGMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _RB;
    private BoxCollider2D _BC;
    private Player _player;

    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _BC = GetComponent<BoxCollider2D>();
        _player = FindObjectOfType<Player>();
    }

    private void FixedUpdate()
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

    void Update()
    {

        if (transform.position.x < -_BC.size.x)
        {
            transform.Translate(new Vector2(_BC.size.x * 2, transform.position.y));
        }    
    }
}
