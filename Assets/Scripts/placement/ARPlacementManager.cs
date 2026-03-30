using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastService))]
[RequireComponent(typeof(ARPlaneManager))]
public class ARPlacementManager : MonoBehaviour
{
    private ARRaycastService _raycastService;
    private ARPlaneManager _planeManager;

    void Awake()
    {
        _raycastService = GetComponent<ARRaycastService>();
        _planeManager = GetComponent<ARPlaneManager>();
    }

    public bool TryGetPlacementPose(Vector2 screenPoint, out Vector3 position, out Quaternion rotation)
    {
        if (!HasTrackedPlanes() || !_raycastService.TryRaycast(screenPoint, out Pose hitPose))
        {
            position = default;
            rotation = default;
            return false;
        }

        position = hitPose.position;
        rotation = ComputeRotationTowardsCamera(hitPose.position);
        return true;
    }

    private bool HasTrackedPlanes()
    {
        foreach (var plane in _planeManager.trackables)
            if (plane.trackingState == TrackingState.Tracking) return true;
        return false;
    }

    private Quaternion ComputeRotationTowardsCamera(Vector3 targetPosition)
    {
        Vector3 direction = Camera.main.transform.position - targetPosition;
        direction.y = 0;
        return direction != Vector3.zero
            ? Quaternion.LookRotation(direction)
            : Quaternion.identity;
    }
}