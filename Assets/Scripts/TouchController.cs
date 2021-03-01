using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static TouchController Instance;

    [SerializeField] Transform runn_e;
    [SerializeField] Transform minClampTr, maxClampTr;

    [SerializeField] float moveSensitivity;

    private Vector2 moveLastPos;
    private PointerEventData mousePosHolder;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePosHolder = eventData;
        TouchDetectionMovement(mousePosHolder);
    }

    private void TouchDetectionMovement(PointerEventData eventData)
    {
        if (moveLastPos == Vector2.zero) moveLastPos = eventData.position;

        Vector2 difVec = eventData.position - moveLastPos;

        //MOVEMENT
        runn_e.position += new Vector3(difVec.x, 0f, 0f) * moveSensitivity;
        moveLastPos = eventData.position;

        //CLAMP
        Vector3 clampedPos = runn_e.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minClampTr.position.x, maxClampTr.position.x);
        runn_e.position = clampedPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moveLastPos = Vector2.zero;

        if (mousePosHolder != null)
        {
            mousePosHolder.position = Vector2.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mousePosHolder = eventData;
    }
}