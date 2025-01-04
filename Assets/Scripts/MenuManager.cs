using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button[] menuButtons;
    public GameObject[] panels;
    public Button[] newGamePanelButtons;
    public TextMeshProUGUI[] newGamePanelTexts;
    public Button[] settingsPanelButtons;
    public Button[] quitPanelButtons;

    public static int time;
    public static int point;
    public static int obj;

    void Start()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Panel aç-kapa iþlemleri
        menuButtons[0].onClick.AddListener(() => OpenPanel(0));
        menuButtons[1].onClick.AddListener(() => OpenPanel(1));
        menuButtons[2].onClick.AddListener(() => OpenPanel(2));
        newGamePanelButtons[1].onClick.AddListener(() => ClosePanel(0));
        settingsPanelButtons[1].onClick.AddListener(() => ClosePanel(1));
        quitPanelButtons[1].onClick.AddListener(() => ClosePanel(2));

        // Yeni oyun paneli butonlarý
        newGamePanelButtons[2].onClick.AddListener(TimeIncrement);
        newGamePanelButtons[3].onClick.AddListener(TimeDecrease);
        newGamePanelButtons[4].onClick.AddListener(PointIncrement);
        newGamePanelButtons[5].onClick.AddListener(PointDecrease);
        newGamePanelButtons[6].onClick.AddListener(ObjectIncrement);
        newGamePanelButtons[7].onClick.AddListener(ObjectDecrease);

        // Ayarlar paneli butonlarý
        settingsPanelButtons[0].onClick.AddListener(() => ClosePanel(1));
        settingsPanelButtons[1].onClick.AddListener(() => ClosePanel(1));

        //Oyun baþlatma
        newGamePanelButtons[0].onClick.AddListener(StartGame);

        // Oyun kapama
        quitPanelButtons[0].onClick.AddListener(QuitGame);
    }

    void OpenPanel(int index)
    {
        panels[index].SetActive(true);
    }

    void ClosePanel(int panelIndex)
    {
        panels[panelIndex].SetActive(false);
    }

    void TimeIncrement()
    {
        int time = int.Parse(newGamePanelTexts[0].text);
        if (time <= 20)
        {
            time++;
            newGamePanelTexts[0].text = time.ToString();
        }
        else
        {
            return;
        }
    }

    void TimeDecrease()
    {
        int time = int.Parse(newGamePanelTexts[0].text);
        if (time > 5)
        {
            time--;
            newGamePanelTexts[0].text = time.ToString();
        }
        else
        {
            return;
        }
    }

    void PointIncrement()
    {
        int point = int.Parse(newGamePanelTexts[1].text);
        if (point < 100)
        {
            if (point == 1)
            {
                point = 5;
                newGamePanelTexts[1].text = point.ToString();
            }
            else if (point >= 5)
            {
                point += 5;
                newGamePanelTexts[1].text = point.ToString();
            }
        }
        else
        {
            return;
        }
    }

    void PointDecrease()
    {
        int point = int.Parse(newGamePanelTexts[1].text);
        if (point > 1)
        {
            if (point == 5)
            {
                point = 1;
                newGamePanelTexts[1].text = point.ToString();
            }
            else
            {
                point -= 5;
                newGamePanelTexts[1].text = point.ToString();
            }
        }
        else
        {
            return;
        }
    }

    void ObjectIncrement()
    {
        int obj = int.Parse(newGamePanelTexts[2].text);
        if (obj < 6)
        {
            obj++;
            newGamePanelTexts[2].text = obj.ToString();
        }
        else
        {
            return;
        }
    }

    void ObjectDecrease()
    {
        int obj = int.Parse(newGamePanelTexts[2].text);
        if (obj > 1)
        {
            obj--;
            newGamePanelTexts[2].text = obj.ToString();
        }
        else
        {
            return;
        }
    }

    void StartGame()
    {
        Debug.Log("Oyun baþlatýlýyor...");
        time = int.Parse(newGamePanelTexts[0].text);
        point = int.Parse(newGamePanelTexts[1].text);
        obj = int.Parse(newGamePanelTexts[2].text);
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
        Debug.Log("Oyun kapatýldý.");
        Application.Quit();
    }
}