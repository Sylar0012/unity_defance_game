using System;
using UnityEngine;

public class ZombiesScripts : MonoBehaviour

{
    public int zombieType;

    private int _damage = 1;
    private int _health = 10;
    private float _speed = 0.02f;

    private void FixedUpdate()
    {
        _health = _health * zombieType;
        transform.position -= new Vector3(0, 0, _speed);
    }
}
