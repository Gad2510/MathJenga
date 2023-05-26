using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBk : Block
{
    public override void RestartBlock()
    {
        rb_self.useGravity = false;
        rb_self.isKinematic = true;
    }

    public override void TestingBlock()
    {
        rb_self.useGravity = true;
        rb_self.isKinematic = false;
    }
}
