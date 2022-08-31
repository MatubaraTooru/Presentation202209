using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    [SerializeField] GameObject _bulletPurefab;
    [SerializeField] int _bulletCount;
    [SerializeField] float _bulletSpeed;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _spreadAngle;
    List<Quaternion> _bullets;
    void Awake()
    {
        _bullets = new List<Quaternion>(_bulletCount);
        for (int i = 0; i < _bulletCount; i++)
        {
            _bullets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    public void Fire()
    {
        int i = 0;
        foreach(Quaternion quat in _bullets)
        {
            _bullets[i] = Random.rotation;
            GameObject b = Instantiate(_bulletPurefab, _muzzle.position, _muzzle.rotation);
            b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, _bullets[i], _spreadAngle);
            b.GetComponent<Rigidbody2D>().AddForce(b.transform.right * _bulletSpeed);
        }
    }
}
