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

    public void ActivateAllBuildings()
    {
        ui_ref.gameObject.SetActive(true);
        foreach (StackBuilder sk in arr_stackBuilders)
        {
            sk.gameObject.SetActive(true);
        }
    }

    public void ChangeTarget(int index)
    {
        if (arr_stackBuilders.Any(x => x.int_grade == index))
        {
            sk_current = arr_stackBuilders.First(x => x.int_grade == index);
            cc_camera.Point = sk_current.transform;
        }
    }

    public void ShowEntryOnScreen(Entry en)
    {
        ui_ref.ShowBlockInfo(en);
    }

    protected override void LoadAssetsScene()
    {
        ui_ref = GameObject.FindGameObjectWithTag("UI").GetComponent<UI_StackTester>();
        cc_camera = Camera.main.transform.parent.GetComponent<CameraController>();
        //Search for builders in scene
        arr_stackBuilders = GameObject.FindGameObjectsWithTag("Builder").
            Select(x => x.GetComponent<StackBuilder>()).
            OrderBy(x=>x.gameObject.name).ToArray();
        sk_current = arr_stackBuilders[Mathf.RoundToInt(arr_stackBuilders.Length / 2)];
        //Call the creation of building foreach
        foreach (StackBuilder stack in arr_stackBuilders)
        {
            Entry[] entries = GameManager._Instance.GameInfo.FilterByGrade(stack.int_grade);
            stack.BuildStructure(entries);
        }
    }

}
