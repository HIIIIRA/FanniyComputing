using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getAvatorPosition : MonoBehaviour
{
    public GameObject avator;
    Transform avatorCenter;
    Animator animator;
    public TextMeshProUGUI tmproHead;
    public TextMeshProUGUI tmproLeftHand;
    public TextMeshProUGUI tmproRightHand;
    public TextMeshProUGUI tmproHip;
    public TextMeshProUGUI tmproLeftFoot;
    public TextMeshProUGUI tmproRightFoot;
    Transform head;
    Transform leftHand;
    Transform rightHand;
    Transform hip;
    Transform leftFoot;
    Transform rightFoot;
    public Vector3 headPosition;
    public Vector3 leftHandPosition;
    public Vector3 rightHandPosition;
    public Vector3 hipPosition;
    public Vector3 leftFootPosition;
    public Vector3 rightFootPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = avator.GetComponent<Animator>();
        avatorCenter = avator.transform;
        head = animator.GetBoneTransform(HumanBodyBones.Head);
        leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
        rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
        hip = animator.GetBoneTransform(HumanBodyBones.Hips);
        leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);

    }

    // Update is called once per frame
    void Update()
    {
        headPosition = GetRelativePosition(head);
        leftHandPosition = GetRelativePosition(leftHand);
        rightHandPosition = GetRelativePosition(rightHand);
        hipPosition = GetRelativePosition(hip);
        leftFootPosition = GetRelativePosition(leftFoot);
        rightFootPosition = GetRelativePosition(rightFoot);

        Write(tmproHead, headPosition);
        Write(tmproLeftHand ,leftHandPosition);
        Write(tmproRightHand, rightHandPosition);
        Write(tmproHip, hipPosition);
        Write(tmproLeftFoot, leftFootPosition);
        Write(tmproRightFoot, rightFootPosition);


    }
    Vector3 GetRelativePosition(Transform bone)
    {
        Vector3 relativePosition = bone.position - avatorCenter.position;
        return relativePosition;
    }
    void Write(TextMeshProUGUI target_TMPro, Vector3 bonePosition)
    {
        target_TMPro.text = (bonePosition.x.ToString("f2") + "," + bonePosition.y.ToString("f2") + "," + bonePosition.z.ToString("f2"));
    }
}
