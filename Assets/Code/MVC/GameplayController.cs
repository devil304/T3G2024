using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : SubControllerBase<GameplayView> //Klasa Controller/kontrolera UI podczas gry, dziedziczy z klasy SubControllerBase. Przyjmuje jako zmienną _ui klase o typie GameplayView, zmienna jest przypisywana w inspektorze.
{
    [SerializeField] InputProvider _inputProvider;

    private void OnEnable()
    {
        _inputProvider.ChangeInputState(true); //podczas aktywacji tego stanu UI włącz obsługę wejść gracza (klawiatura, mysz do rozgrywki)
        _ui.PauseButtonClicked += ActivatePauseState;
        if (Storage.GlobalStorage.HasValue("Points")) //sprawdza czy są już jakieś punkty i aktualizuje ich wartość w UI
            UpdatePoints();
    }

    private void OnDisable()
    {
        _inputProvider.ChangeInputState(false); //podczas dezaktywacji tego stanu UI wyłącz obsługę wejść gracza (klawiatura, mysz do rozgrywki)
        _ui.PauseButtonClicked -= ActivatePauseState;
    }

    public void UpdatePoints() //aktualizuje wartość punktów w swojej klasie view/widoku
    {
        _ui.UpdatePoints(Storage.GlobalStorage.GetValue<int>("Points").ToString());
    }

    private void ActivatePauseState() //Zmienia stan UI z gry na pauzę po wciśnięciu przycisku
    {
        MainController.ChangeUIState(MainController.UIState.Pause);
    }
}
