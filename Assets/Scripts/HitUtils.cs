using System.Collections;
using UnityEngine;

public static class HitUtils
{
    public static IEnumerator FlashRed(Material material, Color color)
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        material.color = color;
    }
}