using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    //设置单例
    public static PlayerMove Instance;

    private Transform m_Transform;
    private CharacterController m_CC;
    private Animator m_Animator;

    private Vector3 dir;//移动的方向

    public bool isMove = false;//是否在移动
    public float speed = 5;//角色移动的速度

    void Awake()
    {
        Instance = this;

        m_Transform = gameObject.GetComponent<Transform>();
        m_CC = gameObject.GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponent<Animator>();

        dir = m_Transform.position;
    }

    /// <summary>
    /// 角色移动方法
    /// </summary>
    public void Move(Vector2 v2)
    {
        //角色move与idle状态的切换
        if (Mathf.Abs(v2.x) > 0 || Mathf.Abs(v2.y) > 0)
        {
            m_Animator.SetBool("move", true);
        }
        else
        {
            m_Animator.SetBool("move", false);
        }

        dir = new Vector3(v2.x, 0, v2.y);
        m_CC.SimpleMove(dir * speed);
    }
}
