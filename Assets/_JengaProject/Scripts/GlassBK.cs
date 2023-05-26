using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBK : Block
{
    public override void RestartBlock()
    {
        gameObject.SetActive(true);
    }

    public override void TestingBlock()
    {
        gameObject.SetActive(false);
    }
}
