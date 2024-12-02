using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

//Przykład nieoptymalnej klasy. Zbiera punkty, rzuca nimi, odkłada je do koszyka... robi za dużo rzeczy
[DefaultExecutionOrder(100)]
public class GetPoints : MonoBehaviour
{

    [SerializeField] string _pointTag = "Goal";
    [SerializeField] string _basketTag = "Basket";
    [SerializeField] InputProvider _inputProvider;
    [SerializeField] Vector3 _pickedPointOffset = Vector3.up; //gdzie względem gracza umieścić trzymany punkt
    [SerializeField] BallisticTrajectory _ballisticTrajectory;
    [SerializeField] Vector3 _throwDirection;  //kierunek rzutu względem _throwRotationReference
    [SerializeField] float _throwPower;
    [SerializeField] Transform _throwRotationReference; //obiekt definiujący referencję dla kierunku rzutu
    [SerializeField] GameplayController _gameplayController; //controller/kontroler MVC do aktualizacji punktów w UI

    Rigidbody _pickedPoint;
    bool _inBasket = false;
    bool _aiming = false;

    // Start is called before the first frame update
    void Start()
    {
        Storage.GlobalStorage.SetValue("Points", 0);
        _inputProvider.PlayerInput.PlayerMovement.Interact.started += PressedSpace;
        _inputProvider.PlayerInput.PlayerMovement.Throw.started += Throwing;
        _inputProvider.PlayerInput.PlayerMovement.Throw.canceled += Throwing;
    }

    private void Throwing(InputAction.CallbackContext context) //rzucanie trzymanym punktem
    {
        if (context.phase == InputActionPhase.Started)
        {
            _aiming = true;
        }
        else
        {
            _ballisticTrajectory.ClearTrajectory();
            _aiming = false;
            if (_pickedPoint != null)
            {
                _pickedPoint.isKinematic = false;
                _pickedPoint.velocity = _throwRotationReference.TransformDirection(_throwDirection) * _throwPower;
                _pickedPoint = null;
            }
        }
    }

    private void PressedSpace(InputAction.CallbackContext context) //zaliczanie punktów jeśli znajdujemy się w koszyku
    {
        if (_pickedPoint != null && _inBasket)
        {
            int lastPoints = Storage.GlobalStorage.GetValue<int>("Points");
            Storage.GlobalStorage.SetValue("Points", lastPoints + 1);
            _gameplayController.UpdatePoints();
            Debug.Log($"Points: {Storage.GlobalStorage.GetValue<int>("Points")}");
            Destroy(_pickedPoint.gameObject);
            _pickedPoint = null;
        }
    }

    private void LateUpdate() //rysywanie trajektorii balistycznej piodczas trzymania przycisku
    {
        if (_pickedPoint != null)
        {
            _pickedPoint.position = transform.position + _pickedPointOffset;
            if (_aiming)
            {
                _ballisticTrajectory.DrawTrajectory(_pickedPoint.position, _throwRotationReference.TransformDirection(_throwDirection), _throwPower);
            }
        }
    }


    private void OnCollisionEnter(Collision other) //podnoszenie punktów
    {
        if (other.gameObject.CompareTag(_pointTag))
        {
            if (_pickedPoint != null)
            {
                _pickedPoint.isKinematic = false;
            }

            _pickedPoint = other.gameObject.GetComponent<Rigidbody>();
            _pickedPoint.isKinematic = true;
            _pickedPoint.position = transform.position + _pickedPointOffset;
        }
    }

    private void OnTriggerStay(Collider other) //sprawdzanie czy weszliśmy w przestrzeń koszyka
    {
        if (other.gameObject.CompareTag(_basketTag))
        {
            _inBasket = true;
        }
    }

    private void OnTriggerExit(Collider other) //sprawdzanie czy wyszliśmy z przestrzeci koszyka
    {
        if (other.gameObject.CompareTag(_basketTag))
        {
            _inBasket = false;
        }
    }
}
