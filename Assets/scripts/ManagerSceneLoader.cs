using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneLoader : MonoBehaviour
{
    private static bool Loaded { get; set; }
    

    void Awake()
    {
        Debug.Log("iminAwake" + Loaded);
        
        if (Loaded) return;
        
        Loaded = true;
        SceneManager.LoadScene("ManagerScene", LoadSceneMode.Additive);
        
    }

}
