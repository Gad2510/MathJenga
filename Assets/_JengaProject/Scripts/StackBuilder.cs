using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBuilder : MonoBehaviour
{
    public int int_grade=1;

    [SerializeField]
    private GameObject go_glass, go_wood, go_stone;

    private List<Block> lst_blocks;

    private void Start()
    {
       // BuildStructure(null);
    }

    public void TestStructure()
    {

    }

    public void BuildStructure(Entry [] entries)
    {
        int floor = 0;
        for (int i=1; i <= entries.Length; i++)
        {
            float angle = 0;
            Vector3 dir = Vector3.forward * ((i % 3)-1);

            if (floor % 2 == 1)
            {
                angle = 90f;
                dir=Vector3.right * ((i % 3)-1);
            }

            Instantiate(go_glass, transform.position + dir+(Vector3.up*floor), Quaternion.AngleAxis(angle, Vector3.up));

            if (i % 3 == 0)
                floor++;
        }
    }
}
