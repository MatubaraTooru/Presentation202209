using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤーの移動スピード</summary>
    [SerializeField, Header("プレイヤーの移動スピード")] float _moveSpeed;
    [SerializeField] GameManager _gm;
    [SerializeField] bool _godmode;
    [SerializeField] GameObject _crashEffect;
    [SerializeField] float _pitchRange = 0.1f;
    Rigidbody2D _rb;
    float _h;
    float _v;
    AudioSource _audioSource;
    [SerializeField] AudioClip[] _audioclips;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 dir = GameObject.Find("Crosshair").transform.position - transform.position;
        transform.up = dir;
        if (_gm._start == true)
        {
            _h = Input.GetAxisRaw("Horizontal");
            _v = Input.GetAxisRaw("Vertical");
        }

        if (_h != 0 || _v != 0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
    }
    private void FixedUpdate()
    {
        Vector2 dom = new Vector2(_h, _v).normalized;
        _rb.velocity = dom * _moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !_godmode)
        {
            Instantiate(_crashEffect, transform.position, Quaternion.identity);
            _gm._death = true;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            _audioSource.PlayOneShot(_audioclips[2]);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * 100, ForceMode2D.Impulse);
        }
    }
    public void PlayFootstepSound()
    {
        _audioSource.pitch = 1.0f + Random.Range(-_pitchRange, _pitchRange);
        _audioSource.PlayOneShot(_audioclips[Random.Range(0, 1)]);
    }
}
