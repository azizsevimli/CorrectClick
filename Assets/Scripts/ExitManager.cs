using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitManager : MonoBehaviour
{
    public GameObject quitGamePanel;
    public Button[] buttons;

    void Start()
    {
        quitGamePanel.SetActive(false);
        buttons[0].onClick.AddListener(ShowExitPopup);
        buttons[1].onClick.AddListener(QuitGame);
        buttons[2].onClick.AddListener(CloseExitPopup);
    }

    void ShowExitPopup()
    {
        quitGamePanel.SetActive(true);
    }

    void QuitGame()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void CloseExitPopup()
    {
        quitGamePanel.SetActive(false);
    }
}