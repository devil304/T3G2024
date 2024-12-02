using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : SubControllerBase<PauseView> //Klasa Controller/kontrolera pauzy gry, dziedziczy z klasy SubControllerBase. Przyjmuje jako zmienną _ui klase o typie PauseView, zmienna jest przypisywana w inspektorze.
{
    private void OnEnable()
    {
        _ui.ResumeButtonClicked += ActivateGameState;
        _ui.MenuButtonClicked += ReloadGame;
    }

    private void OnDisable()
    {
        _ui.ResumeButtonClicked -= ActivateGameState;
        _ui.MenuButtonClicked += ReloadGame;
    }

    private void ActivateGameState() //Zmienia stan UI z pauzy na grę po wciśnięciu przycisku
    {
        MainController.ChangeUIState(MainController.UIState.Game);
    }

    private void ReloadGame() //Przeładowuje scenę po powrocie do menu, jest to w cely zresetowania stanu gry
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
