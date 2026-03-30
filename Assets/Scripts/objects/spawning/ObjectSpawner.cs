using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    private static GameObject _currentInstance;
    private static IMovable _currentMovable;

    void Awake()
    {
        if (_currentInstance == null)
        {
            _currentInstance = null;
            _currentMovable = null;
        }
    }

    void OnEnable()
    {
        PlacementEvents.OnImageDetected += OnImageDetected;
        PlacementEvents.OnMovementRequested += OnMovementRequested;
    }

    void OnDisable()
    {
        PlacementEvents.OnImageDetected -= OnImageDetected;
        PlacementEvents.OnMovementRequested -= OnMovementRequested;
    }

    private void OnImageDetected(Vector3 position, Quaternion rotation)
    {
        if (_currentInstance != null)
        {
            _currentMovable?.MoveTo(position, rotation);
            return;
        }

        Spawn(position, rotation);
    }

    private void OnMovementRequested(Vector3 position, Quaternion rotation)
    {
        if (_currentInstance == null)
        {
            Debug.LogWarning("[ObjectSpawner] Toque ignorado — no hay objeto en escena todavía.");
            return;
        }

        _currentMovable?.MoveTo(position, rotation);
    }

    private void Spawn(Vector3 position, Quaternion rotation)
    {
        _currentInstance = Instantiate(prefabToSpawn, position, rotation);

        if (_currentInstance.TryGetComponent<ISpawnable>(out var spawnable))
            spawnable.OnSpawned(position, rotation);

        _currentMovable = _currentInstance.GetComponent<IMovable>();

        if (_currentMovable == null)
            Debug.LogWarning("[ObjectSpawner] El prefab no implementa IMovable — el movimiento no funcionará.");

        Debug.Log($"[ObjectSpawner] Objeto spawneado: {_currentInstance.name} en {position}");
    }
}