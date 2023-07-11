using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform stopPosition;

    [SceneName]
    public string nextLevel;

    private Camera m_camera;

    void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        var right = m_camera.ViewportToWorldPoint(Vector2.right);
        var center = m_camera.ViewportToWorldPoint(Vector2.one * 0.5f);
        var pos = m_camera.transform.position;
        float newX = pos.x;
        float newY = pos.y;
        if (center.x < target.position.x)
        {
            

            if (Math.Abs(pos.x - target.position.x) >= 0.0000001f)
            {
                newX = target.position.x;
            }
        }
        if(target.position.y < 1)
        {
            newY = target.position.y + 2;
        }

        m_camera.transform.position = new Vector3(newX, newY, pos.z);

        if (stopPosition.position.x - right.x < 0)
        {
            StartCoroutine(INTERNAL_Clear());
            enabled = false;
        }
    }

    private IEnumerator INTERNAL_Clear()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            player.SendMessage("Clear", SendMessageOptions.DontRequireReceiver);
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
