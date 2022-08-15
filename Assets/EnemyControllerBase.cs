using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyControllerBase : MonoBehaviour
{
    /// <summary> 移動速度 </summary>
    [SerializeField] float _movespeed = 5;
    Rigidbody2D _rb;
    GameObject _player;
    [SerializeField] float _stoppingDistance = 0.05f;
    [SerializeField] float _playerSearchRangeRadius = 5f;
    float _saveSpeed;
    /// <summary>弾丸のプレハブ</summary>
    [SerializeField] GameObject _bullet;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _saveSpeed = _movespeed;
    }
    void FixedUpdate()
    {
        if (_player)
        {
            float distance = Vector2.Distance(transform.position, _player.transform.position);
            if (_stoppingDistance > distance)
            {
                _movespeed = default;
            }
            else
            {
                _movespeed = _saveSpeed;
            }
            Vector3 dir = (_player.transform.position - transform.position).normalized;
            _rb.velocity = dir * _movespeed;
            transform.up = dir;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _player = null;
    }
    GameObject SearchGunshot()
    {
        var cols = Physics2D.OverlapCircleAll(this.transform.position, _playerSearchRangeRadius);

        foreach (var c in cols)
        {
            if (c.gameObject.tag == "Player")
            {
                return c.gameObject;
            }
        }
        return null;
    }
}
