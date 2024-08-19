using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial;
using UnityEngine.Video;

public class ChromaKeyVideoScript : MonoBehaviour
{
    [SerializeField] RenderTexture renderTexture;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        PolySpatialObjectUtils.MarkDirty(renderTexture);
    }

    public void TogglePlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}
