using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Klasa udostępniająca obiekt obsługujący wejścia gracza (klawiatura/mysz) podczas rozgrywki. DefaultExecutionOrder(-10) zapewnia wywołanie metod tej klasy przed innymi komponentami
[DefaultExecutionOrder(-10)]
public class InputProvider : MonoBehaviour
{
    public InputActions PlayerInput;

    private void OnEnable()
    {
        if (PlayerInput == null)
            Awake();
    }

    private void Awake()
    {
        PlayerInput = new InputActions();
    }

    public void ChangeInputState(bool active)
    {
        if (active)
            PlayerInput.Enable();
        else
            PlayerInput.Disable();
    }
}
