using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A parent class use to define the commun methods for the Gamemode
public abstract class GameMode : MonoBehaviour
{
    private void Start()
    {
        LoadAssetsScene();
    }

    protected abstract void LoadAssetsScene(); 
}
