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
        //SceneA���A�����[�h
        var op = SceneManager.UnloadSceneAsync(scene);
        yield return op;

        //�A�����[�h��̏���������

        //�K�v�ɉ����ĕs�g�p�A�Z�b�g���A�����[�h���ă��������������
        //���������d�������Ȃ̂ŁA�ʂɊǗ�����̂���
        //yield return Resources.UnloadUnusedAssets();
    }
}
