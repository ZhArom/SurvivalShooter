using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour {

    private ETCJoystick m_EtcJoystick;

	void Start () {
        m_EtcJoystick = gameObject.GetComponent<ETCJoystick>();

        m_EtcJoystick.onMoveStart.AddListener(OnMoveStart);
        m_EtcJoystick.onMove.AddListener(OnMove);
        m_EtcJoystick.onMoveEnd.AddListener(OnMoveEnd);
    }

    private void OnMoveStart()
    {
        PlayerMove.Instance.isMove = true;
    }

    private void OnMove(Vector2 v2)
    {
        PlayerMove.Instance.Move(v2);
    }

    private void OnMoveEnd()
    {
        PlayerMove.Instance.Move(new Vector2(0, 0));
        PlayerMove.Instance.isMove = false;
    }
}
