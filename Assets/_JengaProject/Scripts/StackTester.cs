using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class StackTester : GameMode
{
    public int int_selectStack;
    public StackBuilder[] arr_stackBuilders;
    private CameraController cc_camera;
    private UI_StackTester ui_ref;
    private StackBuilder sk_current;
    //Hide all the elemnt now requiere for the test and only show the current structure
    public void TestBuilding()
    {
        ui_ref.gameObject.SetActive(false);
        foreach(StackBuilder sk in arr_stackBuilders)
        {
            sk.gameObject.SetActive(false);
        }
        sk_current.gameObject.SetActive(true);
        sk_current.TestStructure();
    }
    //Alfter the test building is rebuild it activates back everithing that is require
    public void ActivateAllBuildings()
    {
        ui_ref.gameObject.SetActive(true);
        foreach (StackBuilder sk in arr_stackBuilders)
        {
            sk.gameObject.SetActive(true);
        }
    }
    //Changes the target of the camera to focus in a different building base in the grade in witch is register
    public void ChangeTarget(int index)
    {
        if (arr_stackBuilders.Any(x => x.int_grade == index))
        {
            //Here udates the current building for the one selected
            sk_current = arr_stackBuilders.First(x => x.int_grade == index);
            cc_camera.Point = sk_current.transform;
        }
    }
    //Calls the UI to show the information 
    public void ShowEntryOnScreen(Entry en)
    {
        ui_ref.ShowBlockInfo(en);
    }

    protected override void LoadAssetsScene()
    {
        //Fill all the reference i nthe scene
        ui_ref = GameObject.FindGameObjectWithTag("UI").GetComponent<UI_StackTester>();
        cc_camera = Camera.main.transform.parent.GetComponent<CameraController>();
        //Search for builders in scene
        arr_stackBuilders = GameObject.FindGameObjectsWithTag("Builder").
            Select(x => x.GetComponent<StackBuilder>()).
            OrderBy(x=>x.gameObject.name).ToArray();
        //Set the deaful buildinf as the one in the middle of the array
        sk_current = arr_stackBuilders[Mathf.RoundToInt(arr_stackBuilders.Length / 2)];
        //Call the creation of building foreach
        foreach (StackBuilder stack in arr_stackBuilders)
        {
            Entry[] entries = GameManager._Instance.GameInfo.FilterByGrade(stack.int_grade);
            stack.BuildStructure(entries);
        }
    }

}
