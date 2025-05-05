using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCreateScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject selectedPlant;
    public int plantsType;
    public int price;
    
    private bool _isDragging = false;
    private GameObject _plant;
    private Camera _mainCamera;
    private Ray _ray;
    private Plane _groundPlane;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (_plant && Input.GetKeyDown(KeyCode.Escape))
        {
            EndDrag();
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_isDragging)
        {
            _isDragging = true;    
            _plant = Instantiate(selectedPlant);
            if (plantsType is 0 or 1)
            {
                _plant.GetComponent<ShooterPlantsScript>().isCanFire = false;
                
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_plant != null)
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            _groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (_groundPlane.Raycast(_ray, out float enter))
            {
                Vector3 hitPoint = _ray.GetPoint(enter);
                _plant.transform.position = hitPoint;
            }
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            var target = hit.collider.GetComponent<PlantsAreaScript>();
            Debug.Log("target :: " + target);
            if (target != null)
            {
                if (plantsType is 0 or 1)
                {
                    _plant.GetComponent<ShooterPlantsScript>().isCanFire = true;
                }
                target.CreatePlants(_plant, plantsType);
            }
        }
        
        EndDrag();
    }
    
    private void EndDrag()
    {
        _isDragging = false;
        Destroy(_plant);
        _plant = null;
    }
}
