using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayPause : MonoBehaviour {
    private VideoPlayer player;

    void Start() {
        player = GetComponent<VideoPlayer>();

    }

    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            if (player.isPlaying)
            {
                player.Pause();
            }
            else
            {
                player.Play();
            }
        }
    }
}
