using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public Entry cl_info;
    protected Rigidbody rb_self;

    private void Start()
    {
        rb_self = GetComponent<Rigidbody>();
    }
    //Use in the children of the class to set all testing condition base in tis material
    public abstract void TestingBlock();
    //Use in the children of the class to reset the blocks conditions 
    public abstract void RestartBlock();
    //Use to send the info of the block to the UI through teh gamemode
    public void ShowBlockInfo()
    {
        if (GameManager._Instance.Mode is StackTester)
            ((StackTester)GameManager._Instance.Mode).ShowEntryOnScreen(cl_info);
    }
}
