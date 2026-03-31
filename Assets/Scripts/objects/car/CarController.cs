using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float deceleration = 6f;

    [Header("Giro")]
    [SerializeField] private float turnSpeed = 120f;

    private float _currentSpeed = 0f;
    private Transform _cachedTransform;

    void Awake()
    {
        _cachedTransform = transform;
    }

    void Start()
    {
        _cachedTransform.SetParent(null);
        Debug.Log($"[CarController] forward={_cachedTransform.forward} up={_cachedTransform.up}");
    }

    public void Move(Vector2 input)
    {
        float throttle = input.y;
        float steering = input.x;

        Debug.Log($"[CarController] input={input} speed={_currentSpeed}");

        if (Mathf.Abs(throttle) > 0.1f)
        {
            _currentSpeed = Mathf.MoveTowards(
                _currentSpeed,
                throttle * maxSpeed,
                acceleration * Time.deltaTime
            );
        }
        else
        {
            _currentSpeed = Mathf.MoveTowards(
                _currentSpeed,
                0f,
                deceleration * Time.deltaTime
            );
        }

        if (Mathf.Abs(_currentSpeed) > 0.05f)
        {
            float turn = steering * turnSpeed * Time.deltaTime;
            if (_currentSpeed < 0) turn = -turn;
            _cachedTransform.Rotate(Vector3.up, turn, Space.World);
        }

        _cachedTransform.position += _cachedTransform.forward * _currentSpeed * Time.deltaTime;
    }
}