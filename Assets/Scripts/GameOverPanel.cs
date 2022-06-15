using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Text panelScore;

    // Update is called once per frame
    public void Show()
    {
        gameObject.SetActive(true);
        panelScore.text = GameController.Instance.core.gameScore.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ButtonNewGame()
    {
        GameController.Instance.NewGame();
        Hide();
    }

    public void ButtonMainMenu()
    {
        MainMenu.Instance.Show();
        Hide();
    }
}
