using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : MonoBehaviour
{
    private void Start()
    {
        LoadAssetsScene();
    }

    protected abstract void LoadAssetsScene(); 
}
