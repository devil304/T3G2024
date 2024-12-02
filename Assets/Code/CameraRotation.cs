using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// klasa do bracania kamery muszką z wykorzystaniem nowego input systemu
public class CameraRotation : MonoBehaviour
{
    [SerializeField] float _sensitivity = 1f;
    [SerializeField] InputProvider _inputProvider;
    [SerializeField] Transform _target; //obiekt wokół którego obracamy kamerę

    // Update is called once per frame
    void Update()
    {
        var mouseDelta = _inputProvider.PlayerInput.PlayerMovement.CameraRotation.ReadValue<float>(); //przesunięcie kursora liczone względem poprzedniego razu
        var angle = mouseDelta * _sensitivity * Time.deltaTime; //Kąt o który obrócimy kamerę. _sensitivity reguluje prędkość obracania, a Time.deltaTime uzależnia obrót od ilości klatek na sekundę
        transform.RotateAround(_target.position, Vector3.up, angle); //Obrót tego obiektu wokół podanego obiektu, w podanej osi i o podany kąt.
    }
}
