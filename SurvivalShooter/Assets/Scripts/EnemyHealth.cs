using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    private Transform m_Transform;
    private Animator m_Animator;
    private ParticleSystem hitParticles;
    public AudioClip hunt_Audio;//受到伤害音效
    public AudioClip death_Audio;//死亡音效

    public float hp = 100;
    public int killScore = 20;//击杀得分
    public float downSpeed = 0.3f;//敌人死亡后的下沉速度

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Animator = gameObject.GetComponent<Animator>();
        hitParticles = m_Transform.Find("HitParticles").GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 敌人受到伤害方法
    /// </summary>
    public void TakeDamage(int value, Vector3 hitPoint)
    {
        if (hp <= 0) return;

        hp -= value;

        hitParticles.transform.position = hitPoint;//将受到伤害的特效移动到被击中的位置
        hitParticles.Play();//播放受到伤害特效

        AudioSource.PlayClipAtPoint(hunt_Audio, m_Transform.position, GameManager.Instance.GameAudioVolume);//播放敌人受到伤害音效

        if (hp <= 0)
        {
            Daath();
        }
    }

    /// <summary>
    /// 敌人死亡方法
    /// </summary>
    private void Daath()
    {
        //禁用组件
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<EnemyAttack>().enabled = false;
        gameObject.GetComponent<EnemyMove>().enabled = false;

        GameManager.Instance.AddScore(killScore);//增加游戏得分

        m_Animator.SetTrigger("death");
        AudioSource.PlayClipAtPoint(death_Audio, m_Transform.position, GameManager.Instance.GameAudioVolume);//播放敌人死亡音效

        StartCoroutine("DeathDown");//开启死亡下沉携程
    }

    /// <summary>
    /// 死亡后下沉到地面携程
    /// </summary>
    private IEnumerator DeathDown()
    {
        while (true)
        {
            yield return Time.deltaTime;
            m_Transform.Translate(Vector3.down * downSpeed * Time.deltaTime, Space.World);
            if (m_Transform.position.y <= -2.2f)
            {
                GameObject.Destroy(gameObject);
            }
        }        
    }
}
