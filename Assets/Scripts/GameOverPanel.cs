using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Text panelScore;
    public GameController gameController;
    public MainMenu mainMenu;

    // Update is called once per frame
    public void Show()
    {
        gameObject.SetActive(true);
        panelScore.text = gameController.core.gameScore.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ButtonNewGame()
    {
        gameController.NewGame();
        Hide();
    }

    public void ButtonMainMenu()
    {
        mainMenu.Show();
        Hide();
    }
}
