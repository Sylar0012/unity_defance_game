using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCreateScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject selectedPlant;
    public int plantsType;
    public int price;
    private bool _isDragging = false;
    
    // 생성한 Prefab을 저장할 변수
    private GameObject _plant;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        if (_plant && Input.GetKeyDown(KeyCode.Escape))
        {
            EndDrag();
            Debug.Log("드래그 취소");
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_isDragging)
        {
            _isDragging = true;    
            _plant = Instantiate(selectedPlant);
            Debug.Log("드래그 시작 - 프리팹 생성: " + _plant.name);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_plant != null)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                _plant.transform.position = hitPoint;
            }
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
        Debug.Log("드래그 끝");
    }
    
    private void EndDrag()
    {
        _isDragging = false;
        Destroy(_plant);
        _plant = null;
    }
}
