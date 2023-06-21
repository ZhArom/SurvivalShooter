using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    private Transform m_Transform;
    private NavMeshAgent m_Nav;
    private Animator m_Animator;

    public float speed = 2;//敌人的移动速度
    public float distance = 1.5f;//敌人停止追赶角色的距离

	// Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Nav = gameObject.GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();

        m_Nav.speed = speed;//设置敌人的移动速度
        m_Nav.stoppingDistance = distance;//设置敌人停止追赶角色的距离
	}
	
	void FixedUpdate () {
        m_Nav.SetDestination(PlayerMove.Instance.transform.position);//追赶角色

        //当敌人与角色的距离大于1.2时，播放move动画，否则播放idle动画
        if (Vector3.Distance(m_Transform.position, PlayerMove.Instance.transform.position) >= distance - 0.3f)
        {
            m_Animator.SetBool("move", true);
        }
        else
        {
            m_Animator.SetBool("move", false);
        }
    }
}
