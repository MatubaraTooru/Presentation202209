using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    [SerializeField] GameObject _bulletPurefab;
    [SerializeField] int _bulletCount = 9;
    [SerializeField] float _bulletSpeed = 30f;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _spreadAngle = 20f;
    [SerializeField] float _firerate = 3f;
    AudioSource _fireSound;
    float _t;
    private void Start()
    {
        _fireSound = GetComponent<AudioSource>();
        _t = _firerate;
    }
    void Update()
    {
        _t += Time.deltaTime;
        if (transform.root.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    public void Fire()
    {
        if (_t > _firerate)
        {
            _fireSound.Play();
            for (int i = 0; i < _bulletCount; i++)
            {
                //Šp“x‚ðƒ‰ƒ“ƒ_ƒ€‚ÅŒˆ‚ß‚é
                Quaternion r = Random.rotation;
                GameObject b = Instantiate(_bulletPurefab, _muzzle.position, transform.rotation);
                b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, r, _spreadAngle);
                b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * _bulletSpeed, ForceMode2D.Impulse);
            }
            _t = 0;
        }
    }
}
