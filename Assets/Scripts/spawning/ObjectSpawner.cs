using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    private GameObject _currentInstance;

    void OnEnable()
    {
        PlacementEvents.OnPlacementConfirmed += Spawn;
    }

    void OnDisable()
    {
        PlacementEvents.OnPlacementConfirmed -= Spawn;
    }

    private void Spawn(Vector3 position, Quaternion rotation)
    {
        if (_currentInstance != null)
            Destroy(_currentInstance);

        _currentInstance = Instantiate(prefabToSpawn, position, rotation);

        if (_currentInstance.TryGetComponent<ISpawnable>(out var spawnable))
            spawnable.OnSpawned(position, rotation);
    }
}