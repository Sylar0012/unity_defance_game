using System;
using UnityEngine;

public class ShooterPlantsScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireInterval = 1f;
    public bool isCanFire = true;

    private int _health = 10;
    private float _timer;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && isCanFire)
        {
            _timer += Time.deltaTime;
            if (_timer >= fireInterval)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.forward * 1f, Quaternion.identity);
                _timer = 0f;
            }
            
        } 
    }
    
}
