using UnityEngine;

public class CarInputBridge : MonoBehaviour
{
    [SerializeField] private VirtualJoystick joystick;
    private CarController _car;

    void Update()
    {
        if (_car == null)
            _car = FindObjectOfType<CarController>();

        if (_car == null) return;
        _car.Move(joystick.Input);
    }
}