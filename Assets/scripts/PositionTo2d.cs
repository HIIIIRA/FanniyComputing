using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PositionTo2d : MonoBehaviour
{
    Scene mmd;
    getAvatorPosition script;
    public float avatorx;
    public bool avatorJump;
    public bool avatorStartKey;
    private bool canJump;
    private float speed = 1f;

    public static PositionTo2d instance;

    UnityChan2DController unityChan2DController;
    GameObject StartController;
    StartController startController;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        mmd = SceneManager.GetSceneByName("mmd");
        foreach (var rootGameObject in mmd.GetRootGameObjects())
        {
            script = rootGameObject.GetComponent<getAvatorPosition>();
            if (script != null)
            {
                //script�����������̂�
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 headPosition = script.headPosition;
        Vector3 leftHandPosition = script.leftHandPosition;
        Vector3 rightHandPosition = script.rightHandPosition;
        Vector3 leftFootPosition = script.leftFootPosition;
        Vector3 rightFootPosition = script.rightFootPosition;
        //移動速度
        if (rightHandPosition.x - leftHandPosition.x < 2)
        {
            speed = 0.5f;
        } else
        {
            speed = 1f;
        }
        //左右移動条件
        if(headPosition.x >0.5)
        {
            avatorx =  speed;
        } 
        else if (headPosition.x < -0.5)
        {
            avatorx = -speed;
        }
        else
        {
            avatorx = 0;
        }

        //ジャンプ条件
        int jumpHardle = 6;
        if(rightHandPosition.y > jumpHardle && leftHandPosition.y > jumpHardle)
        {
            if (canJump)
            {
                unityChan2DController = GetComponent<UnityChan2DController>();
                if(unityChan2DController != null)
                {
                    bool ground = unityChan2DController.m_isGround;
                    unityChan2DController.Jump();
                    if (ground == true)
                    {

                        canJump = false;
                    }
                }
                
            }
        }
        if(rightHandPosition.y < jumpHardle && leftHandPosition.y < jumpHardle && 
            canJump == false) {
            canJump = true;
        }

        //スタート条件
        StartController = GameObject.Find("StartController");
        if (rightHandPosition.y > 8 &&
            rightHandPosition.x > -1.5 &&
            rightHandPosition.x < 1.5 &&
            rightHandPosition.y - leftHandPosition.y > 2 &&
            rightFootPosition.y > 1 &&
            rightFootPosition.x > -0.5 &&
            rightFootPosition.x < 0.5
            )
        {
            if (StartController != null)
            {

                startController = StartController.GetComponent<StartController>();
                if (startController.checkStartKey)
                {
                    
                    startController.LoadStageTrigger();
                }
            }
        }
        else
        {
            avatorStartKey = false;
        }
        

    }
    /*
    IEnumerator ChangeColor()
    {
        avatorJump = true;
        yield return new WaitForSeconds(0.0000001f);
        avatorJump = false;
    }
    */

}




