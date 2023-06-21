using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingPanel : MonoBehaviour {

    private Transform m_Transform;
    private Slider backgroundMusic_Slider;
    private Slider gameMusic_Slider;
    private Button mainMenu_Button;
    private Button continue_Button;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        backgroundMusic_Slider = m_Transform.Find("SettingBG/BackgroundMusic/Slider").GetComponent<Slider>();
        gameMusic_Slider = m_Transform.Find("SettingBG/GameMusic/Slider").GetComponent<Slider>();
        mainMenu_Button = m_Transform.Find("SettingBG/MainMenuButton").GetComponent<Button>();
        continue_Button = m_Transform.Find("SettingBG/ContinueButton").GetComponent<Button>();

        backgroundMusic_Slider.onValueChanged.AddListener(BGMSlider);
        gameMusic_Slider.onValueChanged.AddListener(GMSlider);
        mainMenu_Button.onClick.AddListener(MainMenuButton);
        continue_Button.onClick.AddListener(ContinueButton);

        backgroundMusic_Slider.value = PlayerPrefs.GetFloat("BGM", 0.2f);
        gameMusic_Slider.value = PlayerPrefs.GetFloat("GM", 0.5f);
    }

    /// <summary>
    /// 背景音乐滑块事件
    /// </summary>
    private void BGMSlider(float value)
    {
        GameManager.Instance.SetBackgroundAudioVolume(value);
    }

    /// <summary>
    /// 游戏音乐滑块事件
    /// </summary>
    private void GMSlider(float value)
    {
        GameManager.Instance.SetGameAudioVolume(value);
    }

    /// <summary>
    /// 主菜单按钮事件
    /// </summary>
    private void MainMenuButton()
    {
        Time.timeScale = 1;//继续游戏
        SceneManager.LoadScene("Start");
    }

    /// <summary>
    /// 继续游戏按钮事件
    /// </summary>
    private void ContinueButton()
    {
        GameManager.Instance.CloseSettingPanel();
    }
}
