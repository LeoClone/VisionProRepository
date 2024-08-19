using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoProgressBar : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider videoSlider;

    private bool isDragging = false;

    public float currentSpeed = 1f;

    public TMPro.TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        // Set the slider's max value to 1 (normalized progress)
        videoSlider.minValue = 0f;
        videoSlider.maxValue = 1f;

        // Add listeners for the slider
        videoSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Optionally, prepare the video if it's not already playing
        videoPlayer.Prepare();
    }

    void Update()
    {
        // Update the slider value if the user is not dragging it
        //if (!isDragging && videoPlayer.isPlaying)
        if (!isDragging)
        {
            videoSlider.value = (float)(videoPlayer.time / videoPlayer.length);
        }

        //Debug.Log(videoPlayer.canSetPlaybackSpeed);

        double currentTime = videoPlayer.time;
        double totalDuration = videoPlayer.length;

        string currentTimeString = FormatTime(currentTime);
        string totalDurationString = FormatTime(totalDuration);

        timeText.text = $"{currentTimeString} / {totalDurationString}";

    }

    // This method is called when the user interacts with the slider
    public void OnSliderValueChanged(float value)
    {
        if (isDragging)
        {
            videoPlayer.time = value * videoPlayer.length;
        }
    }

    // These methods are used to detect when the user starts and stops dragging the slider
    public void OnPointerDown()
    {
        isDragging = true;
        //currentSpeed = videoPlayer.playbackSpeed;
        //videoPlayer.playbackSpeed = 0.001f;
    }

    public void OnPointerUp()
    {
        isDragging = false;
        //videoPlayer.playbackSpeed = 1f;
        //videoPlayer.Play();
        videoPlayer.time = videoSlider.value * videoPlayer.length;
    }

    private void OnEnable()
    {
        // Subscribe to the video player's prepareCompleted event
        videoPlayer.prepareCompleted += OnVideoPrepared;

        // Ensure the slider is correctly linked to the pointer events
        videoSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Optionally, subscribe to UI events
        EventTrigger trigger = videoSlider.gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        pointerDown.callback.AddListener((e) => OnPointerDown());
        trigger.triggers.Add(pointerDown);

        var pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        pointerUp.callback.AddListener((e) => OnPointerUp());
        trigger.triggers.Add(pointerUp);

        // Prepare the video if it's not already prepared
        if (!videoPlayer.isPrepared)
        {
            videoPlayer.Prepare();
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from the video player's prepareCompleted event
        videoPlayer.prepareCompleted -= OnVideoPrepared;

        // Remove the listeners to avoid memory leaks
        videoSlider.onValueChanged.RemoveListener(OnSliderValueChanged);

        // Clean up the event triggers to avoid duplicate entries
        EventTrigger trigger = videoSlider.GetComponent<EventTrigger>();
        if (trigger != null)
        {
            trigger.triggers.Clear();
        }
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        // Optionally start playing the video when it’s ready
        vp.Play();
    }

    private string FormatTime(double time)
    {
        int minutes = Mathf.FloorToInt((float)time / 60F);
        int seconds = Mathf.FloorToInt((float)time - minutes * 60);

        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}