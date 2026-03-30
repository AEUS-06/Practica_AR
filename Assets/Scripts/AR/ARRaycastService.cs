using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARRaycastService : MonoBehaviour
{
    private ARRaycastManager _raycastManager;
    private readonly List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    public bool TryRaycast(Vector2 screenPoint, out Pose hitPose)
    {
        if (_raycastManager.Raycast(screenPoint, _hits, TrackableType.PlaneWithinPolygon))
        {
            hitPose = _hits[0].pose;
            return true;
        }

        hitPose = default;
        return false;
    }
}