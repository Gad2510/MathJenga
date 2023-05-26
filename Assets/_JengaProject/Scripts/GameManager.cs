using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Public instance accesable to all classes
    public static GameManager _Instance;
    
    //Runs the mathod on play to create the instance ones per scene
    [RuntimeInitializeOnLoadMethod]
    public static void InitManager()
    {
        //Create a new gameobject and populate with the corresponding class
        GameObject go = new GameObject("GameManager");
        _Instance= go.AddComponent<GameManager>();
        //IT WILL CHANGE WHEN NEW MODES ARE ADDED
        go.AddComponent<StackTester>();
        //Precent the object from been destroy in scene change
        DontDestroyOnLoad(go);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
