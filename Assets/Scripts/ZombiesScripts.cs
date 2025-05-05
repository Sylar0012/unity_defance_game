using System;
using UnityEngine;

public class ZombiesScripts : MonoBehaviour

{
    public int zombieType;

    private int _damage = 1;
    private Rigidbody _rigidbody;
    private int _health = 10;
    private float _speed = -0.5f;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = _health * zombieType;
    }
    
    private void FixedUpdate()
    {
        Vector3 vec = new Vector3(0, 0, _speed);
        _rigidbody.linearVelocity = vec;
    }

    public void Hit(int damage)
    {
        _health = _health - damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
