using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤーの移動スピード</summary>
    [SerializeField] float _moveSpeed;
    [SerializeField] GameManager _gm;
    [SerializeField] bool _godmode;
    [SerializeField] GameObject _crashEffect;
    Rigidbody2D _rb;
    float _h;
    float _v;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * 100, ForceMode2D.Impulse);
        }
    }
}
