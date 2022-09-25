using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _jumpForce;

    [SerializeField] AudioClip[] _jumpAudios;

    private bool _isDead;
    private bool _clickDerecho;
    private Rigidbody2D _RB;
    private Animator _animator;
    private AudioSource _audioSource;

    public bool IsDead { get => _isDead; set => _isDead = value; }


    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CapturarInputs();

        if (_clickDerecho && !IsDead)
        {
            Flap();
            JumpSounds();
        }

    }



    private void JumpSounds()
    {
        int currentClip = UnityEngine.Random.Range(0, _jumpAudios.Length);
        _audioSource.clip = _jumpAudios[currentClip];
        _audioSource.Play();
    }

    private void Flap()
    {
        _animator.SetTrigger("Flap");
        _RB.velocity = Vector3.zero;
        _RB.AddForce(Vector2.up * _jumpForce);
    }

    private void OnCollisionEnter2D()
    {
        _animator.SetTrigger("Died");
        IsDead = true;
        GameManager.Instance.GameOver();
        
    }

    private void CapturarInputs()
    {
        _clickDerecho = Input.GetMouseButtonDown(0);
    }

}
