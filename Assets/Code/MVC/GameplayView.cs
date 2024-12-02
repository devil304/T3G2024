using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayView : ViewBase //Klasa View/Widoku podczas gry
{
    [SerializeField] TextMeshProUGUI _points; //Tekst ilości punktów

    public event Action PauseButtonClicked; //Event wywoływany po wciśnięciu przycisku

    public void PauseButtonClick() //Przypisywane do przycisku w inspektorze
    {
        PauseButtonClicked?.Invoke();
    }

    public void UpdatePoints(string points) //aktualizuje tekst ilości punktów
    {
        _points.text = points;
    }
}
