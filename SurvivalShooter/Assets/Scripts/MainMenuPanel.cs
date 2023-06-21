using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour {

    private Transform m_Transform;
    private Button start_Button;
    private Button score_Button;
    private Button about_Button;
    private Button quit_Button;

    private GameObject ScorePanel;
    private GameObject AboutPanel;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        start_Button = m_Transform.Find("Grid/StartButton").GetComponent<Button>();
        score_Button = m_Transform.Find("Grid/ScoreButton").GetComponent<Button>();
        about_Button = m_Transform.Find("Grid/AboutButton").GetComponent<Button>();
        quit_Button = m_Transform.Find("Grid/QuitButton").GetComponent<Button>();

        ScorePanel = GameObject.Find("Canvas/ScorePanel");
        AboutPanel = GameObject.Find("Canvas/AboutPanel");

        start_Button.onClick.AddListener(StartButton);
        score_Button.onClick.AddListener(ScoreButton);
        about_Button.onClick.AddListener(AboutButton);
        quit_Button.onClick.AddListener(QuitButton);

        ScorePanel.SetActive(false);
        AboutPanel.SetActive(false);
    }

    private void StartButton()
    {
        SceneManager.LoadScene("Loading");
    }

    private void ScoreButton()
    {
        ScorePanel.SetActive(true);
    }

    private void AboutButton()
    {
        AboutPanel.SetActive(true);
    }

    private void QuitButton()
    {
        Application.Quit();
    }
}
