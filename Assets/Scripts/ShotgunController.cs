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
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    public void Fire()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Quaternion r = Random.rotation;
            GameObject b = Instantiate(_bulletPurefab, _muzzle.position, transform.rotation);
            b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, r, _spreadAngle);
            b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * _bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
