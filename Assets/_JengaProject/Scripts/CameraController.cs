using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform trs_target;
    [SerializeField]
    private float f_speed;
    public Transform Point
    {
        set
        {
            trs_target = value;
            transform.position = value.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        RotateAround();
    }

    private void RotateAround()
    {
        transform.Rotate(Vector3.up, GetPlayerInputs()*f_speed);
    }

    private float GetPlayerInputs()
    {
        float dir=0;
        if (Input.GetMouseButton(0))
        {
            dir = Input.GetAxis("Mouse X");
        }
        return dir;
    }
}
