using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingPanel : MonoBehaviour {

    private Transform m_Transform;
    private Image loadingBar_Image;
    private Text loadingNum_Text;

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        loadingBar_Image = m_Transform.Find("LoadingBG/LoadingBar").GetComponent<Image>();
        loadingNum_Text = m_Transform.Find("LoadingBG/LoadingNum").GetComponent<Text>();

        loadingBar_Image.fillAmount = 0;
        loadingNum_Text.text = "0%";
        StartCoroutine("LoadingGameScene");
	}

    private void UpdateLoadingUI(float value)
    {
        loadingBar_Image.fillAmount = value;
        loadingNum_Text.text = ((int)(value * 100)) + "%";
    }

    private IEnumerator LoadingGameScene()
    {
        yield return new WaitForSeconds(1);//等待1秒
        AsyncOperation ao = SceneManager.LoadSceneAsync("Game");
        while (!ao.isDone)
        {
            UpdateLoadingUI(ao.progress);
            yield return new WaitForEndOfFrame();
        }
    }
}
