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
    public abstract void TestingBlock();
    public abstract void RestartBlock();

    public void ShowBlockInfo()
    {
        if (GameManager._Instance.Mode is StackTester)
            ((StackTester)GameManager._Instance.Mode).ShowEntryOnScreen(cl_info);
    }
}
