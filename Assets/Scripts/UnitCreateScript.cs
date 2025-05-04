using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCreateScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject[] plants;
    public int plantsType;
    public int price;
    private bool _isDragging = false;
    
    // 생성한 Prefab을 저장할 변수
    private GameObject _plant;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    private void Update()
    {
        // ESC 키로 드래그 취소
        if (_plant && Input.GetKeyDown(KeyCode.Escape))
        {
            CancelDrag();
        }

        // 마우스 우클릭으로 드래그 취소
        if (_plant && Input.GetMouseButtonDown(1)) // 1 == 오른쪽 클릭
        {
            CancelDrag();
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_isDragging)
        {
            _isDragging = true;    
            _plant = Instantiate(plants[plantsType]);
            Debug.Log("드래그 시작 - 프리팹 생성: " + _plant.name);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_plant != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
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
        _isDragging = false;
        Destroy(_plant);
        _plant = null;
        Debug.Log("드래그 끝 - 위치 확정");
    }
    
    private void CancelDrag()
    {
        Debug.Log("드래그 취소");
        Destroy(_plant);
        _plant = null;
    }
}
