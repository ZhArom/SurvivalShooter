using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour {

    private Transform m_Transform;
    private Text scoreNum_Text;
    private Button close_Button;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        scoreNum_Text = m_Transform.Find("ScoreNum").GetComponent<Text>();
        close_Button = m_Transform.Find("Close").GetComponent<Button>();

        scoreNum_Text.text = PlayerPrefs.GetInt("Score", 0).ToString();

        close_Button.onClick.AddListener(CloseButton);
    }

    private void CloseButton()
    {
        gameObject.SetActive(false);
    }
}
