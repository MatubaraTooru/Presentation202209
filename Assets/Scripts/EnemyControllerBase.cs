using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

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
    /// <summary>Enemy‚ÌˆÚ“®–Ú•W</summary>
    [SerializeField] Transform[] _targets;
    int _currentTargetIndex;
    [SerializeField] LayerMask _wallLayer = 0;
    [SerializeField] GameObject _crashEffect;
    GameManager _gm;
    int _hp = 1;
    private void Awake()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _saveSpeed = _movespeed;
    }
    void FixedUpdate()
    {
        if (_gm._start == true)
        {
            Move();
        }
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
            _hp = 0;
            if (_hp <= 0)
            {
                GameObject crashEffect = Instantiate(_crashEffect, transform.position, Quaternion.identity);
                Destroy(crashEffect, 2);
                _gm._enemies.Remove(this.gameObject);
                _gm.GetScore(100);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            Rigidbody2D obrb = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(obrb.velocity.magnitude);
            if (obrb.velocity.magnitude > 0.5f)
            {
                Debug.Log("Start Coroutine");
                StartCoroutine(stun());
            }
        }
    }
    private void Move()
    {
        if (_player)
        {
            Debug.DrawLine(transform.position, _player.transform.position, Color.red);
            RaycastHit2D hit = Physics2D.Linecast(transform.position, _player.transform.position, _wallLayer);
            if (!hit)
            {
                float distancetoPlayer = Vector2.Distance(transform.position, _player.transform.position);
                transform.GetChild(2).GetComponent<ShotgunController>().Fire();
                if (_stoppingDistancetoPlayer > distancetoPlayer)
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
    IEnumerator stun()
    {
        _player = null;
        _rb.velocity = Vector2.zero;
        _rb.Sleep();
        yield return new WaitForSeconds(2);
        _rb.WakeUp();
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
