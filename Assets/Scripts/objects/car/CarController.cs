using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private float acceleration = 2f;
    [SerializeField] private float deceleration = 3f;

    [Header("Giro")]
    [SerializeField] private float turnSpeed = 90f;

    private float _currentSpeed = 0f;

    public void Move(Vector2 input)
    {
        float throttle = input.y;
        float steering = input.x;

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
            float turnDirection = steering * turnSpeed * Time.deltaTime;

            if (_currentSpeed < 0) turnDirection = -turnDirection;

            transform.Rotate(0, turnDirection, 0);
        }

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }
}