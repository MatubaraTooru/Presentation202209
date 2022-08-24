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
    [SerializeField] Transform _muzzlepos;
    [SerializeField] GameObject _bulletpurefab;
    [SerializeField] int _shellnumber = 9;
    [SerializeField] float _bulletspeed = 10.0f;
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
        if (Input.GetButtonDown("Fire1"))
        { 
        gunshot();
        }
    }
    private void FixedUpdate()
    {
        Vector2 dom = new Vector2(_h, _v).normalized;
        _rb.velocity = dom * _moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void gunshot()
    {
        for (int cnt = 0; cnt < _shellnumber; cnt++)
        {
            float random1 = Random.Range(50f, -50f);
            float random2 = Random.Range(50f, -50f);
            Vector2 force = new Vector2(random1, random2);
            GameObject go = Instantiate(_bulletpurefab);
            go.transform.position = _muzzlepos.position;
            Rigidbody2D bulletRb = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Rigidbody2D>();
            bulletRb.AddForce(force);
            bulletRb.AddForce(transform.up * _bulletspeed);
        }
    }
}
