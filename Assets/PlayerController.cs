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
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(_h, _v).normalized;
        _rb.velocity = dir * _moveSpeed;
    }
}
