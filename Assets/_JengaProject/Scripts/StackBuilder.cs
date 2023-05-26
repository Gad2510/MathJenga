using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBuilder : MonoBehaviour
{
    public int int_grade = 1;

    [SerializeField]
    private GameObject go_glass, go_wood, go_stone;

    private List<Block> lst_blocks;

    private void Start()
    {
        lst_blocks = new List<Block>();
    }

    public void TestStructure()
    {

    }

    public void BuildStructure(Entry[] entries)
    {
        int floor = 0;
        for (int i = 1; i <= entries.Length; i++)
        {
            //Set init values for position and angle
            //CASE nonpair floors
            float angle = 0;
            Vector3 dir = Vector3.forward * ((i % 3) - 1);
            //CASE pair floors
            if (floor % 2 == 1)
            {
                angle = 90f;
                dir = Vector3.right * ((i % 3) - 1);
            }

            CreateBlock(entries[i-1],angle, transform.position + dir + (Vector3.up * floor));
            
            //Change the floor eahc 3 blocks
            if (i % 3 == 0)
                floor++;
        }
    }


    private void CreateBlock(Entry en,float angle,Vector3 pos)
    {
        Block bl= Instantiate(selectBlock(en),pos, Quaternion.AngleAxis(angle, Vector3.up), transform).GetComponent<Block>();
        lst_blocks.Add(bl);
        bl.cl_info = en;
    }

    //Select the block to intanciete base on mastery
    private GameObject selectBlock(Entry en)
    {
        GameObject block;

        switch (en.mastery)
        {
            case 1:
                block = go_wood;
                break;
            case 2:
                block = go_stone;
                break;
            default:
                block = go_glass;
                break;
        }

        return block;
    }

}
