using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform trs_target;
    [SerializeField]
    private float f_speed;
    //Use t set its new position
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
    //Is use to update all the movement of the camera 
    private void RotateAround()
    {
        Vector2 dir = GetPlayerInputs();
        transform.Rotate(Vector3.up, dir.x*f_speed);
        transform.Translate(Vector3.up * dir.y);
    }
    //CHECK FOR ALL PLAYER INPUTS
    private Vector2 GetPlayerInputs()
    {
        Vector2 dir=new Vector2();
        //Check Direction ti rotaTe
        if (Input.GetMouseButton(0))
        {
            dir.x = Input.GetAxis("Mouse X");
            //dir.y = Input.GetAxis("Mouse Y")/10;
        }
        //Check input to show info
        else if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("Block"))
                {
                    hit.collider.GetComponentInParent<Block>().ShowBlockInfo();
                }
            }
        }
        return dir;
    }
}
