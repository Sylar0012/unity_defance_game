using UnityEngine;

public class PlantsAreaScript : MonoBehaviour
{
    private GameObject _plant;
    
    public void CreatePlants(GameObject newPlant, int plantType)
    {
        if (_plant == null)
        {
            if (plantType < 4)
            {
                _plant = Instantiate(newPlant, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (plantType == 4)
            {
                Destroy(_plant);
                _plant = null;
                    
            }
        }
    }
}
