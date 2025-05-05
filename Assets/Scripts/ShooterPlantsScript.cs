using Interfaces;
using UnityEngine;

public class ShooterPlantsScript : MonoBehaviour, IPlants
{
    public GameObject bulletPrefab;
    public float fireInterval = 1f;
    public bool isCanFire = true;

    private int _health = 10;
    private float _timer;
    private Material _material;
    private Color _color;
    
    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _color = GetComponent<MeshRenderer>().material.color;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie") && isCanFire)
        {
            _timer += Time.deltaTime;
            if (_timer >= fireInterval)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.forward * 1.5f, Quaternion.identity);
                _timer = 0f;
            }
            
        } 
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
    
}
