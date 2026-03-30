using UnityEngine;

public class CarController : MonoBehaviour, ISpawnable
{
    public void OnSpawned(Vector3 position, Quaternion rotation)
    {
        Debug.Log($"[CarController] Carrito colocado en {position}");
    }

    public void Move(Vector2 input) { }
}