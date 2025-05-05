using System;
using Interfaces;
using UnityEngine;

public class WallPlantsScript : MonoBehaviour, IPlants
{
    public int plantsType;
    
    private int _health = 20;
    private Material _material;
    private Color _color;
    
    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _color = GetComponent<MeshRenderer>().material.color;
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
