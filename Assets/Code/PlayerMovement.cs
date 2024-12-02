using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

//klasa odpowiedzialna za poruszanie się gracza, wymaga Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] InputProvider _inputProvider;
    [SerializeField] Transform _rotationTarget; //obiekt będący referencją do kierunków gracza

    Rigidbody _myRigidbody;
    Vector2 _movementInputvalue = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        _inputProvider.PlayerInput.PlayerMovement.Movement.performed += MovementInputHandling;
        _inputProvider.PlayerInput.PlayerMovement.Movement.canceled += MovementInputHandling;

        _myRigidbody = GetComponent<Rigidbody>();
    }

    private void MovementInputHandling(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            _movementInputvalue = Vector2.zero;
        }
        else
        {
            _movementInputvalue = context.ReadValue<Vector2>();
        }
    }

    // Update is called once per physic engine interval
    void FixedUpdate()
    {
        Vector3 newForward = Vector3.ProjectOnPlane(_rotationTarget.forward, Vector3.up).normalized; //wyliczanie nowego kierunku przodu gracza przez projekcje na płaszczyźnie, ze zwrotem w górę, lokalnej osi przodu obiektu referencyjnego
        Vector3 newVelocity = Vector3.zero;
        newVelocity += Vector3.up * _myRigidbody.velocity.y; //zachowujemy aktualną prędkość w osi pionowej aby działała grawitacja
        newVelocity += newForward * _movementInputvalue.y; //prędkość w nowej osi do przodu
        newVelocity += _rotationTarget.right * _movementInputvalue.x; //prędkość w osi w prawo
        _myRigidbody.velocity = newVelocity * _speed;
    }
}
