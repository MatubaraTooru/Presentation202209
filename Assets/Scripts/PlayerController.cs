using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤーの移動スピード</summary>
    [SerializeField] float _moveSpeed;
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
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 dom = new Vector2(_h, _v).normalized;
        _rb.velocity = dom * _moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
