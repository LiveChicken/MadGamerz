using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FreeLookInput : MonoBehaviour {

    private CinemachineFreeLook MyFreelook;
    // Start is called before the first frame update
    void Start() {

        MyFreelook = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update() {

        if (GameManager.GM.TS == Mode.S3D && GameManager.GM.CanMove) {

            Vector2 input = GameManager.GM.controls.Player.Look.ReadValue<Vector2>();


            MyFreelook.m_XAxis.m_InputAxisValue = input.x;
            MyFreelook.m_YAxis.m_InputAxisValue = input.y;
        }

    }
}
