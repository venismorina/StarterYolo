using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WebGLVideoPlayer : MonoBehaviour
{
    public string url;
    VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url =  url;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if(!videoPlayer.isPlaying)
                Play();

        }
    }

    void Play()
    {
        videoPlayer.Play();
        videoPlayer.isLooping = true;
    }
}
