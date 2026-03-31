using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform handle;
    [SerializeField] private float handleLimit = 60f;

    public Vector2 Input { get; private set; }

    public void OnPointerDown(PointerEventData data) => MoveHandle(data);
    public void OnDrag(PointerEventData data)        => MoveHandle(data);

    public void OnPointerUp(PointerEventData data)
    {
        Input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    private void MoveHandle(PointerEventData data)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            handle.parent as RectTransform,
            data.position,
            data.pressEventCamera,
            out Vector2 localPoint
        );

        localPoint = Vector2.ClampMagnitude(localPoint, handleLimit);
        handle.anchoredPosition = localPoint;
        Input = localPoint / handleLimit;
    }
}