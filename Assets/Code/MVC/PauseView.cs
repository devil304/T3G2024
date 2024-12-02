using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseView : ViewBase //Klasa View/Widoku podczas pauzy gry
{
    public event Action ResumeButtonClicked; //Event wywoływany po wciśnięciu przycisku
    public event Action MenuButtonClicked; //Event wywoływany po wciśnięciu przycisku

    public void ResumeButtonClick() //Przypisywane do przycisku w inspektorze
    {
        ResumeButtonClicked?.Invoke();
    }

    public void MenuButtonClick() //Przypisywane do przycisku w inspektorze
    {
        MenuButtonClicked?.Invoke();
    }
}
