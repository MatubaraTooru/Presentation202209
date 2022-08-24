using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _bulletspeed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        float random1 = Random.Range(50f, 50f);
        float random2 = Random.Range(50f, 50f);
        Vector2 force = new Vector2(random1, random2);
        _rb.AddForce(force);
        _rb.AddForce(tra)
    }

    void Update()
    {
        
    }
}
