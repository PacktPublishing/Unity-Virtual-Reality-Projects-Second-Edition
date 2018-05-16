using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidethroughController : MonoBehaviour
{
    public Transform playerRoot;
    public GameObject artWorks;
    public float startDelay = 3f;
    public float transitionTime = 5f;
    public bool isPlaying;

    private AnimationCurve xCurve, zCurve, rCurve;

    void OnEnable()
    {
        SetupCurves();
    }

    private void SetupCurves()
    {
        int count = artWorks.transform.childCount + 1;
        Keyframe[] xKeys = new Keyframe[count];
        Keyframe[] zKeys = new Keyframe[count];
        Keyframe[] rKeys = new Keyframe[count];

        int i = 0;
        float time = startDelay;
        xKeys[0] = new Keyframe(time, playerRoot.position.x);
        zKeys[0] = new Keyframe(time, playerRoot.position.z);
        rKeys[0] = new Keyframe(time, playerRoot.rotation.y);

        foreach (Transform artwork in artWorks.transform)
        {
            i++;
            time += transitionTime;
            Transform pose = artwork.Find("ViewPose");
            xKeys[i] = new Keyframe(time, pose.position.x);
            zKeys[i] = new Keyframe(time, pose.position.z);
            rKeys[i] = new Keyframe(time, pose.rotation.y);
        }
        xCurve = new AnimationCurve(xKeys);
        zCurve = new AnimationCurve(zKeys);
        rCurve = new AnimationCurve(rKeys);
    }

    void Update()
    {
        playerRoot.position = new Vector3(xCurve.Evaluate(Time.time), playerRoot.position.y, zCurve.Evaluate(Time.time));
        Quaternion rot = playerRoot.rotation;
        rot.y = rCurve.Evaluate(Time.time);
        playerRoot.rotation = rot;
        // done?
        if (Time.time >= xCurve[xCurve.length - 1].time)
            gameObject.SetActive(false);
    }
}
