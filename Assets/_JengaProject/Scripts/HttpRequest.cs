using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class HttpRequest : MonoBehaviour
{
    private const string str_path = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
    private static Data d_loadData;

    public static Data LoadData
    {
        get { return d_loadData; }
    }
    //Get the information from the end point 
    public static IEnumerator GetBatch()
    {
        //Make the request
        UnityWebRequest www = UnityWebRequest.Get(str_path);
        yield return www.SendWebRequest();
        //Check for any errors
        if (www.result==UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Convert the Json to a local class 
            d_loadData = JsonUtility.FromJson<Data>("{\"lst_recordLst\":"+www.downloadHandler.text+"}");
            //Calls the GameMnager to retrive the data
            GameManager._Instance.LoadData();
        }
    }
}
