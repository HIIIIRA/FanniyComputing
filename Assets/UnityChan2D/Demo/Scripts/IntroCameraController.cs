using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class IntroCameraController : MonoBehaviour
{
    public Transform target;
    private float resetTime;
    private Vector3 pos;
    //Vector3 pos;

    [SceneName]
    public string nextLevel;
    
    IEnumerator Start()
    {
        pos = transform.position;
        resetTime = Time.time; 
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length + 1);
        
        //scene移行
        Scene ManagerScene = SceneManager.GetSceneByName("ManagerScene");
        foreach (var rootGameObject in ManagerScene.GetRootGameObjects())
        {
            GameSceneManagerScript script = rootGameObject.GetComponent<GameSceneManagerScript>();
            if (script != null)
            {
                //GameManagerが見つかったので

                script.WorldSceneLoader();
                break;
            }
        }
    }

    void Update()
    {
        float newPosition = Mathf.SmoothStep(pos.x, target.position.x, (Time.time -  resetTime)/ GetComponent<AudioSource>().clip.length);

        transform.position = new Vector3(newPosition, pos.y, pos.z);
    }
}
