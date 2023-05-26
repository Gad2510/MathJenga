using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_StackTester : MonoBehaviour
{
    private Button btn_testBuilding;
    [SerializeField]
    private TMPro.TextMeshProUGUI txt_info;

    public void ChangeCameraTarget(int grade)
    {
        if (GameManager._Instance.Mode is StackTester)
            ((StackTester)GameManager._Instance.Mode).ChangeTarget(grade);
    }

    public void ShowBlockInfo(Entry en)
    {
        txt_info.gameObject.SetActive(true);
        txt_info.SetText($"{en.grade} : {en.domain} \n {en.cluster} \n {en.standardid} : {en.standarddescription}");
    }

    public void HideInfo()
    {
        txt_info.gameObject.SetActive(false);
    }

    public void TestBuilding()
    {
        if (GameManager._Instance.Mode is StackTester)
            ((StackTester)GameManager._Instance.Mode).TestBuilding();
    }
}
