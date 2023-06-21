using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    private AudioSource m_AudioSource;

    private GameObject controllerPanel;
    private GameObject setttingPanel;
    private GameObject gameOverPanel;

    private float gameAudioVolume;//游戏音效音量

    private int score = 0;//游戏得分

    public float GameAudioVolume
    {
        get { return gameAudioVolume; }
        set { gameAudioVolume = value; }
    }

    void Awake()
    {
        Instance = this;

        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

	void Start () {
        controllerPanel = GameObject.Find("EasyTouchControlsCanvas/ControllerPanel");
        setttingPanel = GameObject.Find("EasyTouchControlsCanvas/SettingPanel");
        gameOverPanel = GameObject.Find("EasyTouchControlsCanvas/GameOverPanel");

        setttingPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        m_AudioSource.volume = PlayerPrefs.GetFloat("BGM", 0.2f);
        gameAudioVolume = PlayerPrefs.GetFloat("GM", 0.5f);
    }

    /// <summary>
    /// 设置背景音乐音量
    /// </summary>
    /// <param name="backGroundAudioVolume"></param>
    public void SetBackgroundAudioVolume(float backGroundAudioVolume)
    {
        m_AudioSource.volume = backGroundAudioVolume;
    }

    /// <summary>
    /// 设置游戏音量
    /// </summary>
    public void SetGameAudioVolume(float gameAudioVolume)
    {
        this.gameAudioVolume = gameAudioVolume;
    }

    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        controllerPanel.SetActive(false);//隐藏操控面板
        m_AudioSource.enabled = false;//关闭背景音乐
        StartCoroutine("ShowGameOverPanel");//开启显示结束面板携程
    }

    private IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(3);//等待3秒
        gameOverPanel.SetActive(true);//显示游戏结束面板
        gameOverPanel.GetComponent<GameOverPanel>().SetScore(score);//设置分数
        Time.timeScale = 0;//暂停游戏
    }

    /// <summary>
    /// 增加游戏得分
    /// </summary>
    public void AddScore(int value)
    {
        score += value;
        HealthAndScorePanel.Instance.UpdateScore(score);
    }

    /// <summary>
    /// 打开设置面板
    /// </summary>
    public void OpenSettingPanel()
    {
        if (setttingPanel.active == false)
        {
            setttingPanel.SetActive(true);
            Time.timeScale = 0;//暂停游戏
        }
    }

    /// <summary>
    /// 关闭设置面板
    /// </summary>
    public void CloseSettingPanel()
    {
        if (setttingPanel.active == true)
        {
            PlayerPrefs.SetFloat("BGM", m_AudioSource.volume);//写入背景音乐音量设置
            PlayerPrefs.SetFloat("GM", gameAudioVolume);//写入游戏音乐音量设置
            setttingPanel.SetActive(false);
            Time.timeScale = 1;//继续游戏
        }
    }
}
