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
                _plant = Instantiate(newPlant, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity);
            }
        }
        else
        {
            if (plantType == 4)
            {
                Debug.Log("유닛 제거함 ㅇㅇ");
                Destroy(_plant);
                _plant = null;
                    
            }
        }
    }
}
