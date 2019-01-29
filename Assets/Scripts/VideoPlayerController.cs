using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject menu;
    public GameObject skipButton;
    public static VideoPlayerController instance;

    private void Start()
    {
        menu.SetActive(false);
        instance = this;
        if (VideoSkipController.instance.skipped)
            Skip();
    }

    private void Update()
    {
        if (videoPlayer.frame >= (long) videoPlayer.clip.frameCount)
        {
            Skip();
        }
    }

    public void Skip()
    {
        videoPlayer.Stop();
        menu.SetActive(true);
        skipButton.SetActive(false);
        VideoSkipController.instance.skipped = true;
    }
}