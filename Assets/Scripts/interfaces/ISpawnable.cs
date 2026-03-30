using UnityEngine;

public interface ISpawnable
{
    void OnSpawned(Vector3 position, Quaternion rotation);
}