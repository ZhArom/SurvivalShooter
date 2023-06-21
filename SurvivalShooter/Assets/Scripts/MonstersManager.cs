using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour {

    private Transform m_Transform;
    private Transform zombBearsParent_Transform;
    private Transform zombBunnysParent_Transform;
    private Transform HellephantsParent_Transform;

    private GameObject prefab_ZombBear;
    private GameObject prefab_ZombBunny;
    private GameObject prefab_Hellephant;

    public int createZombBearTime = 5;
    public int createZombBunnyTime = 8;
    public int createHellephantTime = 12;

    private float levelTime = 0;

    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        zombBearsParent_Transform = m_Transform.Find("ZombBearsParent").GetComponent<Transform>();
        zombBunnysParent_Transform = m_Transform.Find("ZombBunnysParent").GetComponent<Transform>();
        HellephantsParent_Transform = m_Transform.Find("HellephantsParent").GetComponent<Transform>();

        prefab_ZombBear = Resources.Load<GameObject>("ZomBear");
        prefab_ZombBunny = Resources.Load<GameObject>("Zombunny");
        prefab_Hellephant = Resources.Load<GameObject>("Hellephant");

        StartCoroutine("CreateZombBear");
        StartCoroutine("CreateZombBunny");
        StartCoroutine("CreateHellephant");
    }
	
	void Update () {
        levelTime += Time.deltaTime;
        if (levelTime >= 60)
        {
            levelTime = 0;

            createZombBearTime--;
            createZombBunnyTime--;
            createHellephantTime--;

            if (createZombBearTime <= 0)
            {
                createZombBearTime = 1;
            }
            if (createZombBunnyTime <= 0)
            {
                createZombBunnyTime = 1;
            }
            if (createHellephantTime <= 0)
            {
                createHellephantTime = 1;
            }
        }
	}

    /// <summary>
    /// 生成僵尸熊
    /// </summary>
    private IEnumerator CreateZombBear()
    {
        while (true)
        {
            yield return new WaitForSeconds(createZombBearTime);
            GameObject.Instantiate<GameObject>(prefab_ZombBear, zombBearsParent_Transform);
        }        
    }

    /// <summary>
    /// 生成僵尸兔子
    /// </summary>
    private IEnumerator CreateZombBunny()
    {
        while (true)
        {
            yield return new WaitForSeconds(createZombBunnyTime);
            GameObject.Instantiate<GameObject>(prefab_ZombBunny, zombBunnysParent_Transform);
        }
    }

    /// <summary>
    /// 生成僵尸大象
    /// </summary>
    private IEnumerator CreateHellephant()
    {
        while (true)
        {
            yield return new WaitForSeconds(createHellephantTime);
            GameObject.Instantiate<GameObject>(prefab_Hellephant, HellephantsParent_Transform);
        }        
    }
}
