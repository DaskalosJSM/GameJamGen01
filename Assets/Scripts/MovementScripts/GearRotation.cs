using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] Vector3 RotationSpeedAngle = new Vector3(0f, 0f, 1f);
    private Quaternion NewRotation;
    private float TiempoNormal = 1f;
    private float TiempoRewind = -1f;
    private float RotationSpeedM;
    void Start()
    {
         RotationSpeedM = RotationSpeed;
         //Gear = this.transform;
    }
    void Update()
    {
        InputTime();
        this.transform.RotateAround(this.transform.position, RotationSpeedAngle, RotationSpeed * Time.deltaTime);
    }
    void InputTime()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            RotationSpeed = RotationSpeed * TiempoRewind;

        if (Input.GetKeyUp(KeyCode.Mouse0))
            RotationSpeed = 0;

        if (Input.GetKeyDown(KeyCode.Mouse1))
            RotationSpeed = RotationSpeedM * TiempoNormal;
    }

}
