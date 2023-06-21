using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutPanel : MonoBehaviour {

    private Transform m_Transform;
    private Button close_Button;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        close_Button = m_Transform.Find("Close").GetComponent<Button>();

        close_Button.onClick.AddListener(CLoseButton);
	}

    private void CLoseButton()
    {
        gameObject.SetActive(false);
    }
}
