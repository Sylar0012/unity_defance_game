using System;
using UnityEngine;

public class BulletScripts : MonoBehaviour

{

    private int _damage = 1;

    private void Update()
    {
        transform.position += new Vector3(0, 0, 0.14f);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<ZombiesScripts>().Hit(_damage);

        } 
    }
}
