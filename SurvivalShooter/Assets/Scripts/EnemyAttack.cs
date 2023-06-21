using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    private Transform m_Transform;


    public int attackMin = 5;//最小攻击力
    public int attackMax = 10;//最大攻击力
    public float attackRate = 1;//攻击速度
    private float attackTime;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();

        attackTime = 1 / attackRate;
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            //敌人前方朝向角色
            Vector3 normalForward = m_Transform.forward;//得到敌人的前方
            Vector3 dir = coll.transform.position - m_Transform.position;//计算敌人与角色的方向
            normalForward = Vector3.Lerp(normalForward, dir, Time.deltaTime * 5);//差值计算敌人目标方向
            m_Transform.rotation = Quaternion.LookRotation(normalForward);//敌人转向该方向

            attackTime += Time.deltaTime;
            if (attackTime >= 1 / attackRate)
            {
                coll.transform.GetComponent<PlayerHealth>().TakeDamage(Random.Range(attackMin, attackMax));
                attackTime = 0;
            }
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            attackTime = 1 / attackRate;
        }
    }
}
