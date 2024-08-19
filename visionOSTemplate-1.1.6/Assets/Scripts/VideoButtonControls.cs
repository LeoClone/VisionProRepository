using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoButtonControls : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public Image buttonImage;

    public GameObject playbackOptions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying && buttonImage.sprite.name != "Icon_Play")
        {
            buttonImage.sprite = Resources.Load<Sprite>("Icon_Play");
        } else if (videoPlayer.isPlaying && buttonImage.sprite.name != "Icon_Pause")
        {
            buttonImage.sprite = Resources.Load<Sprite>("Icon_Pause");
        }
    }

    public void ToggleVideo()
    {
        if(videoPlayer.isPlaying)
        {
            videoPlayer.Pause();

            buttonImage.sprite = Resources.Load<Sprite>("Icon_Play");
        } else
        {
            videoPlayer.Play();

            buttonImage.sprite = Resources.Load<Sprite>("Icon_Pause");
        }
    }

    public void ForwardVideo()
    {
        videoPlayer.time += 5;
    }

    public void BackwardVideo()
    {
        videoPlayer.time -= 5;
    }

    public void ChangeVideoSpeed(float newValue)
    {
        /*
        Debug.Log("change speed :" + videoPlayer.playbackSpeed);
        videoPlayer.playbackSpeed = newValue;
        Debug.Log("into :" + videoPlayer.playbackSpeed);
        */

        StartCoroutine(ChangeSpeedCoroutine(newValue));
    }

    private IEnumerator ChangeSpeedCoroutine(float newValue)
    {
        videoPlayer.playbackSpeed = newValue;

        // Restart the video to apply the speed change
        videoPlayer.Pause();
        yield return null; // Wait for the next frame
        videoPlayer.Play();
    }

    public void TogglePlaybackOptions()
    {
        if(playbackOptions.activeSelf)
        {
            playbackOptions.SetActive(false);
        } else
        {
            playbackOptions.SetActive(true);
        }
    }

    public void ChangeVolume(float volume)
    {
        videoPlayer.SetDirectAudioVolume(0, volume);
    }
}
