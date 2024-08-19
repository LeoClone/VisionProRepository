using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Unity.PolySpatial;

public class ChromaKeyVideoControls : MonoBehaviour
{
    public VideoPlayer[] videoComponent;

    public GameObject[] objectsToTurnOff;

    public RenderTexture renderTexture;

    void Update()
    {
        PolySpatialObjectUtils.MarkDirty(renderTexture);
    }

    public void StopVideo(int videoIdx)
    {
        StartCoroutine(DelayedStop(videoIdx));
    }


    private IEnumerator DelayedStop(int videoIdx)
    {

        // Wait for 1 second before continuing
        //yield return new WaitForSeconds(1);

        if (videoIdx >= 0 && videoIdx < videoComponent.Length && videoIdx < objectsToTurnOff.Length)
        {
            if (videoComponent[videoIdx] != null && videoComponent[videoIdx].isPlaying == true)
            {

                yield return new WaitForSeconds(1);
                videoComponent[videoIdx].Stop();
                Debug.Log("Video Stopped");

                // Turn off the corresponding GameObject after stopping the video
                if (objectsToTurnOff[videoIdx] != null)
                {
                    yield return new WaitForSeconds(1);
                    objectsToTurnOff[videoIdx].SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning($"Index {videoIdx} is out of bounds for video components or game objects.");
        }
    }
}
