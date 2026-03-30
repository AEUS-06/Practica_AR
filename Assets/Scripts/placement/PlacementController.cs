using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ARPlacementManager))]
public class PlacementController : MonoBehaviour
{
    private ARPlacementManager _placementManager;

    void Awake()
    {
        _placementManager = GetComponent<ARPlacementManager>();
    }

    void Update()
    {
        HandleTapInput();
    }

    private void HandleTapInput()
    {
        var touchscreen = Touchscreen.current;
        if (touchscreen == null || !touchscreen.primaryTouch.press.wasPressedThisFrame) return;

        Vector2 tapPosition = touchscreen.primaryTouch.position.ReadValue();

        if (_placementManager.TryGetPlacementPose(tapPosition, out Vector3 position, out Quaternion rotation))
            PlacementEvents.RaiseMovementRequested(position, rotation);
    }
}