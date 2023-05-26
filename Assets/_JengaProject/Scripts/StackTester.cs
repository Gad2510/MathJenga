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

    public void TestBuilding()
    {

    }

    public void ChangeTarget(int index)
    {
        if(arr_stackBuilders.Any(x=>x.int_grade==index))
            cc_camera.Point =arr_stackBuilders.First(x=>x.int_grade==index).transform;
    }

    public void ShowEntryOnScreen(Entry en)
    {

    }

    protected override void LoadAssetsScene()
    {
        cc_camera = Camera.main.transform.parent.GetComponent<CameraController>();
        //Search for builders in scene
        arr_stackBuilders = GameObject.FindGameObjectsWithTag("Builder").
            Select(x => x.GetComponent<StackBuilder>()).
            OrderBy(x=>x.gameObject.name).ToArray();
        //Call the creation of building foreach
        foreach(StackBuilder stack in arr_stackBuilders)
        {
            Entry[] entries = GameManager._Instance.GameInfo.FilterByGrade(stack.int_grade);
            stack.BuildStructure(entries);
        }
    }

}
