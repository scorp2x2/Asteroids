using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject panelGame;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        panelGame.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        panelGame.SetActive(false);
    }

    public void ButtonNewGame()
    {
        panelGame.SetActive(true);
        gameController.NewGame();
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
