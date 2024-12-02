using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour //główny kontroler MVC
{
    [SerializeField] MenuController _menuController;
    [SerializeField] GameplayController _gameplayController;
    [SerializeField] PauseController _pauseController;

    void Start()
    {
        //Ustawia ten kontroler jako główny w pod kontrolerach
        _menuController.MainController = this;
        _gameplayController.MainController = this;
        _pauseController.MainController = this;

        ChangeUIState(UIState.Menu); //zmienia na start stan UI na Menu Start
    }

    public void ChangeUIState(UIState state)  //obsługa zmiany stanu UI
    {
        DeactivateControllers();

        switch (state)
        {
            case UIState.Menu:
                _menuController.ActivateController();
                break;
            case UIState.Game:
                _gameplayController.ActivateController();
                break;
            case UIState.Pause:
                _pauseController.ActivateController();
                break;
            default:
                break;
        }
    }

    public void DeactivateControllers() //wyłącza wszystkie kontrolery
    {
        _menuController.DeactivateController();
        _gameplayController.DeactivateController();
        _pauseController.DeactivateController();
    }

    public enum UIState //enum mozliwych stanów UI
    {
        Menu,
        Game,
        Pause
    }
}
