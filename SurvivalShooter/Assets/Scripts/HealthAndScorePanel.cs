using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndScorePanel : MonoBehaviour {

    public static HealthAndScorePanel Instance;

    private Transform m_Transform;

    private Image bloodBar_Image;
    private Text score_Text;
    private Button openSetting_Button;

    void Awake()
    {
        Instance = this;
    }
	
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        bloodBar_Image = m_Transform.Find("Health/BloodBarBG/BloodBar").GetComponent<Image>();
        score_Text = m_Transform.Find("Score").GetComponent<Text>();
        openSetting_Button = m_Transform.Find("OpenSettingButton").GetComponent<Button>();

        openSetting_Button.onClick.AddListener(OpenSettingButton);

        UpdateBloodBar(1);
        UpdateScore(0);
    }

    /// <summary>
    /// 更新血量UI
    /// </summary>
    public void UpdateBloodBar(float value)
    {
        bloodBar_Image.fillAmount = value;
    }


    /// <summary>
    /// 更新分数UI
    /// </summary>
    public void UpdateScore(int value)
    {
        score_Text.text = "游戏得分 : " + value;
    }


    private void OpenSettingButton()
    {
        GameManager.Instance.OpenSettingPanel();
    }
}
