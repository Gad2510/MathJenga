using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_StackTester : MonoBehaviour
{
    private Button btn_6th, btn_7th, btn_8th, btn_testBuilding;
    private TMPro.TextMeshProUGUI txt_info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCameraTarget(int grade)
    {
        if (GameManager._Instance.Mode is StackTester)
            ((StackTester)GameManager._Instance.Mode).ChangeTarget(grade);
    }
}
