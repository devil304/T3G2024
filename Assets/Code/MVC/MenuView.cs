using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : ViewBase //Klasa View/Widoku menu startowego
{
    public event Action PlayButtonClicked; //Event wywoływany po wciśnięciu przycisku
    public event Action QuitButtonClicked; //Event wywoływany po wciśnięciu przycisku

    public void PlayButtonClick() //Przypisywane do przycisku w inspektorze
    {
        PlayButtonClicked?.Invoke();
    }

    public void QuitButtonClick() //Przypisywane do przycisku w inspektorze
    {
        QuitButtonClicked?.Invoke();
    }
}
