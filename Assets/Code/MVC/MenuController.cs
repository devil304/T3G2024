using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : SubControllerBase<MenuView> //Klasa Controller/kontrolera pauzy gry, dziedziczy z klasy SubControllerBase. Przyjmuje jako zmienną _ui klase o typie MenuView, zmienna jest przypisywana w inspektorze.
{
    private void OnEnable()
    {
        _ui.PlayButtonClicked += ActivatePlayState;
        _ui.QuitButtonClicked += QuitGame;
    }

    private void OnDisable()
    {
        _ui.PlayButtonClicked -= ActivatePlayState;
        _ui.QuitButtonClicked += QuitGame;
    }

    private void ActivatePlayState() //Zmienia stan UI z menu na grę po wciśnięciu przycisku
    {
        MainController.ChangeUIState(MainController.UIState.Game);
    }

    private void QuitGame() //Wychodzi z gry po wciśnięciu przycisku
    {
        Application.Quit();
    }

}
