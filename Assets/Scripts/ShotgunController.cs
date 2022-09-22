using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    [SerializeField, Header("�e�ۂ̃v���n�u")] GameObject _bulletPurefab;
    [SerializeField, Header("�ˏo�����e�̐�")] int _bulletCount = 9;
    [SerializeField, Header("�e�ۂ̔�ԃX�s�[�h")] float _bulletSpeed = 30f;
    [SerializeField] Transform _muzzle;
    [SerializeField, Header("�e�ۂ̎ˏo�����͈�")] float _spreadAngle = 20f;
    [SerializeField, Header("�e�̌��Ă�Ԋu")] float _firerate = 3f;
    [SerializeField] bool _playerIdentification = false;
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
                //�p�x�������_���Ō��߂�
                if (_playerIdentification)
                {
                    Quaternion r = Random.rotation;
                    GameObject b = Instantiate(_bulletPurefab, _muzzle.position, transform.rotation);
                    b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, r, _spreadAngle);
                    b.GetComponent<Rigidbody2D>().AddForce(b.transform.right * _bulletSpeed, ForceMode2D.Impulse);
                }
                else
                {
                    Quaternion r = Random.rotation;
                    GameObject b = Instantiate(_bulletPurefab, _muzzle.position, transform.rotation);
                    b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, r, _spreadAngle);
                    b.GetComponent<Rigidbody2D>().AddForce(b.transform.up * _bulletSpeed, ForceMode2D.Impulse);
                }
            }
            _t = 0;
        }
    }
}
