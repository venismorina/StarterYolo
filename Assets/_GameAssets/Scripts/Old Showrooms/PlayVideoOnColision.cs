using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnColision : MonoBehaviour
{
    VideoPlayer player;
    private void Start()
    {
        if (GetComponent<VideoPlayer>())
        {
            player = GetComponent<VideoPlayer>();
            player.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && player != null)
        {
            player.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && player != null)
        {
            player.Pause();
        }
    }
}
