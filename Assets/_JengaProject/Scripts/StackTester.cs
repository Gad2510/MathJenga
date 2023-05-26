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

    }

    public void ShowEntryOnScreen(Entry en)
    {

    }

    protected override void LoadAssetsScene()
    {
        //Search for builders in scene
        arr_stackBuilders = GameObject.FindGameObjectsWithTag("Builder").
            Select(x => x.GetComponent<StackBuilder>()).
            OrderBy(x=>x.gameObject.name).ToArray();
        //Call the creation of building foreach
        foreach(StackBuilder stack in arr_stackBuilders)
        {
            Debug.Log(GameManager._Instance.gameObject.name);
            Entry[] entries = GameManager._Instance.GameInfo.FilterByGrade(stack.int_grade);
            stack.BuildStructure(entries);
        }
    }

}
