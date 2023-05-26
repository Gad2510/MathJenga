using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public Entry cl_info;

    public abstract void TestingBlock();

    public void ShowBlockInfo()
    {
        if (GameManager._Instance.Mode is StackTester)
            ((StackTester)GameManager._Instance.Mode).ShowEntryOnScreen(cl_info);
    }
}
