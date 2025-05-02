using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner : MonoBehaviour
{
   public Transform[] spawnPoints;
   
   public GameObject[] zombies;

   private void Start()
   {
      InvokeRepeating("SpawnZombie", 0, 3);
   }

   void SpawnZombie()
   {
      int spawnZombie = Random.Range(0, 3);
      int spawnPoint = Random.Range(0, spawnPoints.Length);
      GameObject myZombie = Instantiate(zombies[spawnZombie], spawnPoints[spawnPoint].position, Quaternion.identity);
   }
}
