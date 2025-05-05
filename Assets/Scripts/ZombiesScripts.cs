using Interfaces;
using UnityEngine;

public class ZombiesScripts : MonoBehaviour

{
    public int zombieType;

    private int _damage = 2;
    private Rigidbody _rigidbody;
    private int _health = 10;
    private float _speed = -0.5f;
    private float _timer;
    private Material _material;
    private Color _color;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = _health * zombieType;
        _material = GetComponent<MeshRenderer>().material;
        _color = GetComponent<MeshRenderer>().material.color;
    }
    
    private void FixedUpdate()
    {
        Vector3 vec = new Vector3(0, 0, _speed);
        _rigidbody.linearVelocity = vec;
    }

    public void Hit(int damage)
    {
        _health = _health - damage;

        StartCoroutine(HitUtils.FlashRed(_material, _color));

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            _timer += Time.deltaTime;
            if (_timer >= 1f)
            {
                other.gameObject.GetComponent<IPlants>().Hit(_damage);
                _timer = 0f;
            }
        } 
    }
}
