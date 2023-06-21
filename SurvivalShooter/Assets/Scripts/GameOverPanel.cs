using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour {

    private Transform m_Transform;
    private Text score_Text;
    private Button mainMenu_Button;
    private Button again_Button;
	
	void Awake () {
        m_Transform = gameObject.GetComponent<Transform>();
        score_Text = m_Transform.Find("Score").GetComponent<Text>();
        mainMenu_Button = m_Transform.Find("MainMenuButton").GetComponent<Button>();
        again_Button = m_Transform.Find("AgainButton").GetComponent<Button>();

        score_Text.text = "score : 0";
        mainMenu_Button.onClick.AddListener(MainMenuButton);
        again_Button.onClick.AddListener(AgainButton);
	}

    public void SetScore(int value)
    {
        score_Text.text = "score : " + value;
    }

    private void MainMenuButton()
    {
        Time.timeScale = 1;//开启游戏
        SceneManager.LoadScene("Start");
    }

    private void AgainButton()
    {
        Time.timeScale = 1;//开启游戏
        SceneManager.LoadScene("Loading");
    }
}
