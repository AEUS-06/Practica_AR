using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARImageTrackingService : MonoBehaviour
{
    private ARTrackedImageManager _imageManager;

    void Awake()
    {
        _imageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _imageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    void OnDisable()
    {
        _imageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    private void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> args)
    {
        foreach (var image in args.added)
            HandleImageAdded(image);
    }

    private void HandleImageAdded(ARTrackedImage image)
    {
        if (image.trackingState == TrackingState.None) return;

        Vector3 position = image.transform.position;
        Quaternion rotation = ComputeRotationTowardsCamera(position);

        Debug.Log($"[ARImageTrackingService] Detectada: {image.referenceImage.name} en {position}");

        PlacementEvents.RaiseImageDetected(position, rotation);
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