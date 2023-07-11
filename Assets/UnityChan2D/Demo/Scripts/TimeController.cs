using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public int startTime;
    float timeF;
    int time;
    [SceneName]
    public string nextLevel;
    public Text timer;

    private void Start()
    {
        timeF = startTime;
    }
    void Update()
    {
        //int remainingTime = time - Mathf.FloorToInt(Time.timeSinceLevelLoad * 2.5f);
        timeF -= Time.deltaTime;
        time = (int)timeF;

        //if (0 <= remainingTime)
        if (0 <= time)
        {
            timer.text = time.ToString("000");
            //timer.text = remainingTime.ToString("000");
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                StartCoroutine(LoadNextLevel());
                enabled = false;
            }
        }
    }

    private IEnumerator LoadNextLevel()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            player.SendMessage("TimeOver", SendMessageOptions.DontRequireReceiver);
        }

        yield return new WaitForSeconds(3);

        //scene移行
        Scene ManagerScene = SceneManager.GetSceneByName("ManagerScene");
        foreach (var rootGameObject in ManagerScene.GetRootGameObjects())
        {
            GameSceneManagerScript script = rootGameObject.GetComponent<GameSceneManagerScript>();
            if (script != null)
            {
                //GameManagerが見つかったので

                script.StartSceneLoader();
                break;
            }
        }
    }
}
