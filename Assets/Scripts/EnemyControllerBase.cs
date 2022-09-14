using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyControllerBase : MonoBehaviour
{
    /// <summary> ˆÚ“®‘¬“x </summary>
    [SerializeField] float _movespeed = 5;
    Rigidbody2D _rb;
    GameObject _player;
    [SerializeField] float _stoppingDistancetoPlayer = 0.05f;
    [SerializeField] float _stoppingDistancetoTarget = 0.05f;
    //[SerializeField] float _gunshotSearchRangeRadius = 5f;
    float _saveSpeed;
    [SerializeField] GameObject _bullet;
    /// <summary>Enemy‚ÌˆÚ“®–Ú•W</summary>
    [SerializeField] Transform[] _targets;
    int _currentTargetIndex;
    float _timer;
    [SerializeField] LayerMask _wallLayer = 0;
    [SerializeField] Transform _lineend;
    [SerializeField] GameObject _crashEffect;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _saveSpeed = _movespeed;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
    }
    void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(_crashEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        Debug.DrawLine(transform.position, _lineend.position);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, _lineend.position, _wallLayer);
        if (_player)
        {
            float distancetoPlayer = Vector2.Distance(transform.position, _player.transform.position);
            if (!hit.collider.gameObject.CompareTag("Wall"))
            {
                transform.GetChild(2).GetComponent<ShotgunController>().Fire();
            }
            else if (_stoppingDistancetoPlayer > distancetoPlayer)
            {
                _movespeed = default;
            }
            else
            {
                _movespeed = _saveSpeed;
            }
            Vector2 dir = (_player.transform.position - transform.position).normalized;
            _rb.velocity = dir * _movespeed;
            transform.up = dir;
        }
        else if (_targets[0])
        {
            float distancetoTarget = Vector2.Distance(this.transform.position, _targets[_currentTargetIndex % _targets.Length].position);
            if (distancetoTarget > _stoppingDistancetoTarget)
            {
                Vector2 dir = (_targets[_currentTargetIndex % _targets.Length].transform.position - this.transform.position).normalized;
                _rb.velocity = dir * _movespeed;
                transform.up = dir;
            }
            else
            {
                _currentTargetIndex++;
            }
        }
    }
    //void shooting()
    //{
    //    Instantiate<GameObject>(_bullet, transform);
    //}
    //GameObject SearchGunshot()
    //{
    //    var cols = Physics2D.OverlapCircleAll(this.transform.position, _gunshotSearchRangeRadius);

    //    foreach (var c in cols)
    //    {
    //        if (c.gameObject.tag == "Gunshot")
    //        {
    //            return c.gameObject;
    //        }
    //    }
    //    return null;
    //}
}
