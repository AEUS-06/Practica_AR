using UnityEngine;

public static class PlacementEvents
{
    public static event System.Action<Vector3, Quaternion> OnImageDetected;

    public static event System.Action<Vector3, Quaternion> OnMovementRequested;

    public static void RaiseImageDetected(Vector3 position, Quaternion rotation)
        => OnImageDetected?.Invoke(position, rotation);

    public static void RaiseMovementRequested(Vector3 position, Quaternion rotation)
        => OnMovementRequested?.Invoke(position, rotation);
}