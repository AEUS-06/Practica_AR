using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlacementController : MonoBehaviour
{
    public GameObject placementPrefab;

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        var touchscreen = Touchscreen.current;
        if (touchscreen == null) return;

        var primaryTouch = touchscreen.primaryTouch;
        if (!primaryTouch.press.wasPressedThisFrame) return;

        Vector2 tapPosition = primaryTouch.position.ReadValue();

        if (!HasDetectedPlanes())
        {
            Debug.Log("Sin planos detectados. Mueve la cámara lentamente sobre una superficie.");
            return;
        }

        if (raycastManager.Raycast(tapPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            Instantiate(placementPrefab, hitPose.position, hitPose.rotation);
            Debug.Log($"Prefab colocado en: {hitPose.position}");
        }
        else
        {
            Debug.Log("No se detectó un plano en ese punto. Apunta a una superficie plana.");
        }
    }

    bool HasDetectedPlanes()
    {
        foreach (var plane in planeManager.trackables)
        {
            if (plane.trackingState == TrackingState.Tracking)
                return true;
        }
        return false;
    }
}