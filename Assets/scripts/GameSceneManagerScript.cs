using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagerScript : MonoBehaviour
{
    private void Start()
    {
        
        SceneManager.LoadScene("Start", LoadSceneMode.Additive);
        SceneManager.LoadScene("mmd", LoadSceneMode.Additive);
        
    }

    public void StartSceneLoader()
    {
        Debug.Log("StartSceneLoader");
        StartCoroutine(CoUnload("world"));
        SceneManager.LoadScene("Start", LoadSceneMode.Additive);
        
    }

    public void LoadSceneLoader ()
    {
        Debug.Log("LoadSceneLoader");
        StartCoroutine(CoUnload("Start"));
        SceneManager.LoadScene("Loading 1-1", LoadSceneMode.Additive);
        
    }

    public void IntroSceneLoader()
    {
        Debug.Log("IntroSceneLoader");
        StartCoroutine(CoUnload("Loading 1-1"));
        SceneManager.LoadScene("intro", LoadSceneMode.Additive);
        
    }
    public void IntroSceneSkipLoader()
    {
        Debug.Log("IntroSceneSkipLoader");
        StartCoroutine(CoUnload("Loading 1-1"));
        SceneManager.LoadScene("world", LoadSceneMode.Additive);

    }

    public void WorldSceneLoader()
    {
        Debug.Log("WorldSceneLoader");
        StartCoroutine(CoUnload("intro"));
        SceneManager.LoadScene("world", LoadSceneMode.Additive);
        
    }

    IEnumerator CoUnload(string scene)
    {
        //SceneAをアンロード
        var op = SceneManager.UnloadSceneAsync(scene);
        yield return op;

        //アンロード後の処理を書く

        //必要に応じて不使用アセットをアンロードしてメモリを解放する
        //けっこう重い処理なので、別に管理するのも手
        //yield return Resources.UnloadUnusedAssets();
    }
}
