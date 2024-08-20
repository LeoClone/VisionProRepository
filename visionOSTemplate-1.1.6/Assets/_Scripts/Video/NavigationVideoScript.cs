using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NavigationVideoScript : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject videoCanvas;

    public string videoName;
    public VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenVideo()
    {
        mainCanvas.SetActive(false);
        videoCanvas.SetActive(true);

        ChangeVideoClipByName(videoName);
    }

    public void CloseVideo()
    {
        videoCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void ChangeVideoClip(VideoClip newClip)
    {
        // Stop the current video if it's playing
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }

        // Assign the new video clip
        videoPlayer.clip = newClip;

        // Optionally, prepare the video if you want it ready to play immediately when needed
        videoPlayer.Prepare();
    }

    public void ChangeVideoClipByName(string videoName)
    {
        // Load the video from the Resources folder
        VideoClip newClip = Resources.Load<VideoClip>(videoName);

        if (newClip != null)
        {
            ChangeVideoClip(newClip);
        }
        else
        {
            Debug.LogWarning("Video clip not found: " + videoName);
        }
    }
}
