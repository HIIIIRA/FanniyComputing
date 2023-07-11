using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class StartController : MonoBehaviour
{
    [SceneName]
    public string nextLevel;

    [SerializeField]
    private KeyCode enter = KeyCode.X;

    public bool checkStartKey;

    void Start()
    {
        checkStartKey = true;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(enter))
        {
            StartCoroutine(LoadStage());
        }
        
    }

    public void LoadStageTrigger()
    {
        
        if (checkStartKey)
        {
            StartCoroutine(LoadStage());
            checkStartKey = false;
        }
        
    }
    IEnumerator LoadStage()
    {
        foreach (AudioSource audioS in FindObjectsOfType<AudioSource>())
        {
            audioS.volume = 0.2f;
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 0.5f);

        //scene移行
        Scene ManagerScene = SceneManager.GetSceneByName("ManagerScene");
        foreach (var rootGameObject in ManagerScene.GetRootGameObjects())
        {
            GameSceneManagerScript script = rootGameObject.GetComponent<GameSceneManagerScript>();
            if (script != null)
            {
                //GameManagerが見つかったので
               
                script.LoadSceneLoader();
                break;
            }
        }
    }
}
