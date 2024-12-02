using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubControllerBase<T> : MonoBehaviour where T : ViewBase //Klasa bazowa modułu Controller z MVC, przyjmuje dowolną klasę dziedziczącą z klasy ViewBase jako _ui
{
    [HideInInspector]
    public MainController MainController; //główny kontroler MVC

    [SerializeField]
    protected T _ui; //View/Widok z którym komunikuje się dany Controller

    public virtual void ActivateController()
    {
        enabled = true;
        _ui.ShowView();
    }

    public virtual void DeactivateController()
    {
        enabled = false;
        _ui.HideView();
    }
}
