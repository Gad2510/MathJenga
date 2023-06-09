using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Public instance accesable to all classes
    public static GameManager _Instance;
    private GameMode gm_currentMode;
    public Data sd_GameData;
    
    public Data GameInfo
    {
        get { return sd_GameData; }
    }

    public GameMode Mode
    {
        get { return gm_currentMode; }
    }

    //Runs the mathod on play to create the instance ones per scene
    [RuntimeInitializeOnLoadMethod]
    public static void InitManager()
    {
        //Create a new gameobject and populate with the corresponding class
        GameObject go = new GameObject("GameManager");
        _Instance= go.AddComponent<GameManager>();
        //Precent the object from been destroy in scene change
        DontDestroyOnLoad(go);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HttpRequest.GetBatch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //All action after the data is loaded should be put here
    public void LoadData()
    {
        sd_GameData=HttpRequest.LoadData;
        sd_GameData.SortList();
        //IT WILL CHANGE WHEN NEW MODES ARE ADDED
        gm_currentMode=gameObject.AddComponent<StackTester>();
    }
}
