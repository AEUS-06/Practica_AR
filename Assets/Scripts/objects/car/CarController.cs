using UnityEngine;

public class CarController : MonoBehaviour, ISpawnable, IMovable
{
    public void OnSpawned(Vector3 position, Quaternion rotation)
    {
        Debug.Log($"[CarController] Carro inicializado en {position}");
    }

    public void MoveTo(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        Debug.Log($"[CarController] Carro movido a {position}");
    }

    public void Move(Vector2 input) { }
}