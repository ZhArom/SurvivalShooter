using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform m_Transform;
    private Vector3 offset;//摄像机与角色的偏移量
    private float speed = 5;//摄像机跟随角色的速度

	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        offset = m_Transform.position - PlayerMove.Instance.transform.position;
    }
	
	void FixedUpdate () {
        m_Transform.position = Vector3.Lerp(m_Transform.position, PlayerMove.Instance.transform.position + offset, speed * Time.deltaTime);
	}
}
