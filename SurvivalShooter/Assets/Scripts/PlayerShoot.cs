using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public static PlayerShoot Instance;

    private Transform m_Transform;
    private Transform gunBarrelEnd_Transform;//枪口的Transform
    private ParticleSystem gunParticles;//枪焰特效
    private AudioClip gunShoot_Audio;//射击音效
    private LineRenderer gunShoot_LineRenderer;//射击线特效

    private Ray ray;
    private RaycastHit hit;

    private Vector3 dir;//射击的方向

    private bool canShoot = false;//是否能射击
    public float shootRate = 8;//射击速度
    private float shootTime;

    void Awake()
    {
        Instance = this;
    }

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        gunBarrelEnd_Transform = m_Transform.Find("GunBarrelEnd").GetComponent<Transform>();
        gunParticles = m_Transform.Find("GunBarrelEnd/GunParticles").GetComponent<ParticleSystem>();
        gunShoot_Audio = Resources.Load<AudioClip>("Audio/Effects/Player GunShot");
        gunShoot_LineRenderer = m_Transform.Find("ShootLineEffect").GetComponent<LineRenderer>();

        dir = m_Transform.position;

        shootTime = 1 / shootRate;//保证触发射击事件时能立即射击
    }

    /// <summary>
    /// 设置角色的方向
    /// </summary>
    public void SetDirection(Vector2 v2)
    {
        dir = new Vector3(v2.x, m_Transform.position.y, v2.y);
    }

    /// <summary>
    /// 开始射击
    /// </summary>
    public void ShootStart()
    {
        canShoot = true;
    }

    /// <summary>
    /// 结束射击
    /// </summary>
    public void ShootEnd()
    {
        canShoot = false;
        shootTime = 1 / shootRate;//保证触发射击事件时能立即射击
    }

    void FixedUpdate()
    {
        m_Transform.LookAt(m_Transform.position + dir);
        if (canShoot)
        {
            shootTime += Time.deltaTime;
            if (shootTime >= 1 / shootRate)
            {
                Shoot();
                shootTime = 0;
            }
        }
    }

    /// <summary>
    /// 射击
    /// </summary>
    private void Shoot()
    {
        gunParticles.Play();//播放射击特效
        AudioSource.PlayClipAtPoint(gunShoot_Audio, gunBarrelEnd_Transform.position, GameManager.Instance.GameAudioVolume);//播放射击音效

        ray = new Ray(gunBarrelEnd_Transform.position, gunBarrelEnd_Transform.forward);//从枪口位置向前方发射射线
        gunShoot_LineRenderer.SetPosition(0, gunBarrelEnd_Transform.position);//设置线特效的起始点为枪口位置
        if (Physics.Raycast(ray, out hit))//射线碰撞到物体
        {
            gunShoot_LineRenderer.SetPosition(1, hit.point);//设置线特效的终点为碰撞点位置
            if (hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(Random.Range(20, 40), hit.point);//是敌人受到伤害
            }
        }
        else//射线未碰撞到物体
        {
            gunShoot_LineRenderer.SetPosition(1, gunBarrelEnd_Transform.forward * 100);//设置线特效的终点为枪口的前方一百米处
        }

        gunShoot_LineRenderer.enabled = true;//开启射击线特效

        StartCoroutine("CleanEffect");
    }

    /// <summary>
    /// 清除射击特效
    /// </summary>
    private IEnumerator CleanEffect()
    {
        yield return new WaitForSeconds(0.05f);
        gunShoot_LineRenderer.enabled = false;//关闭线特效
    }
}
