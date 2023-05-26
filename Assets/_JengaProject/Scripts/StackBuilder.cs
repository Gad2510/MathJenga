using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBuilder : MonoBehaviour
{
    public int int_grade = 1;

    [SerializeField]
    private GameObject go_glass, go_wood, go_stone; //Reference to the prefabs 

    private List<Block> lst_blocks; // A list of all the blocks that compose the structure

    private WaitForSeconds wfs_interval= new WaitForSeconds(0.5f); //Set the interval between shakes
    private const int int_numShakes = 6; //Determine how many times the structuere is going to shake
    private Vector3 v3_shakeForce= new Vector3(10,0,0); // Set the force to be use un the shaking

    private Rigidbody rb_self;
    private void Start()
    {
        lst_blocks = new List<Block>();
        rb_self = GetComponent<Rigidbody>();
    }
    //Action all the test behaviors in the blocks
    public void TestStructure()
    {
        foreach(Block bl in lst_blocks)
        {
            bl.TestingBlock();
        }
        //Start shaking
        StartCoroutine(StructureShake());
    }

    private IEnumerator StructureShake()
    {
        Vector3 origin=transform.position;

        for(int i =0;i< int_numShakes; i++)
        {  
            //Dterminate the direccion base in the number to shake back and forward
            Vector3 dir = (i % 2 == 1) ? -v3_shakeForce : v3_shakeForce;
            rb_self.AddForce(dir);
            yield return wfs_interval;
        }

        yield return wfs_interval;
        //Reset the position of the building
        transform.position = origin;
        rb_self.velocity = Vector3.zero;
        //Reconstruct the structure
        BuildStructure(new Entry[lst_blocks.Count], false);

        ((StackTester)GameManager._Instance.Mode).ActivateAllBuildings();
    }

    public void BuildStructure(Entry[] entries, bool createNew=true)
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
            //Check if is a rebuild or creation
            if (createNew)
                CreateBlock(entries[i - 1], angle, transform.position + dir + (Vector3.up * floor));
            else
                RestartBlock(lst_blocks[i - 1], transform.position + dir + (Vector3.up * floor), angle);

            //Change the floor eahc 3 blocks
            if (i % 3 == 0)
                floor++;
        }
    }


    private void CreateBlock(Entry en,float angle,Vector3 pos)
    {
        Block bl= Instantiate(selectBlock(en), transform).GetComponent<Block>();
        SetBlockPos(bl.gameObject, pos, angle);
        lst_blocks.Add(bl);
        bl.cl_info = en;
    }

    private void RestartBlock(Block bk, Vector3 pos, float angle)
    {
        bk.RestartBlock();
        SetBlockPos(bk.gameObject, pos, angle);
    }

    private void SetBlockPos(GameObject go,Vector3 pos, float angle)
    {
        go.transform.position = pos;
        go.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
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
