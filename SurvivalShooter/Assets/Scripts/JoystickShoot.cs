using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickShoot : MonoBehaviour {

    private ETCJoystick m_EtcJoystick;

    void Start()
    {
        m_EtcJoystick = gameObject.GetComponent<ETCJoystick>();

        m_EtcJoystick.onMoveStart.AddListener(OnMoveStart);
        m_EtcJoystick.onMove.AddListener(OnMove);
        m_EtcJoystick.onMoveEnd.AddListener(OnMoveEnd);
    }

    private void OnMoveStart()
    {
        PlayerShoot.Instance.ShootStart();
    }

    private void OnMove(Vector2 v2)
    {
        PlayerShoot.Instance.SetDirection(v2);
    }

    private void OnMoveEnd()
    {
        PlayerShoot.Instance.ShootEnd();
    }
}
