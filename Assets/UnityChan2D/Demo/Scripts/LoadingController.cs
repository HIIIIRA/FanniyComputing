using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    [SceneName]
    public string nextLevel;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);


        //scene移行
        Scene ManagerScene = SceneManager.GetSceneByName("ManagerScene");
        foreach (var rootGameObject in ManagerScene.GetRootGameObjects())
        {
            GameSceneManagerScript script = rootGameObject.GetComponent<GameSceneManagerScript>();
            if (script != null)
            {
                //GameManagerが見つかったので

                script.IntroSceneLoader();
                break;
            }
        }
    }
}
