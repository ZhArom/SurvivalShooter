using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour {

    private Transform m_Transform;
    private Animator m_Animator;
    private Material player_Material;//角色材质球
    private AudioClip playerHurt;//角色受伤音效
    private AudioClip playerDeath;//角色死亡音效

    public float hp = 100;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Animator = gameObject.GetComponent<Animator>();
        player_Material = m_Transform.Find("Player").GetComponent<SkinnedMeshRenderer>().material;
        playerHurt = Resources.Load<AudioClip>("Audio/Effects/Player Hurt");
        playerDeath = Resources.Load<AudioClip>("Audio/Effects/Player Death");
    }

    public void TakeDamage(int value)
    {
        if (hp <= 0) return;

        hp -= value;

        HealthAndScorePanel.Instance.UpdateBloodBar(hp / 100);//更新血量UI

        AudioSource.PlayClipAtPoint(playerHurt, m_Transform.position, GameManager.Instance.GameAudioVolume);//播放角色受到伤害音效
        player_Material.color = Color.red;//将自身颜色变为红色
        player_Material.DOColor(Color.white, 0.2f);//0.2秒后将自身颜色变为白色

        if (hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        m_Animator.SetTrigger("death");//播放死亡动画
        AudioSource.PlayClipAtPoint(playerDeath, m_Transform.position, GameManager.Instance.GameAudioVolume);//播放死亡音效
        gameObject.GetComponent<PlayerShoot>().enabled = false;
        GameManager.Instance.GameOver();//游戏结束
    }
}
