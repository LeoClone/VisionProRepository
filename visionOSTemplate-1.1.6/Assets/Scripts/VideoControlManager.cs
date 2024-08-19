//using UnityEngine;

//namespace Unity.PolySpatial
//{
//    public class VideoControlManager : MonoBehaviour
//    {
//        public VisionOSVideoComponent videoComponent;

//        void Update()
//        {
//            if (videoComponent != null)
//            {
//                // Check if the GameObject is active and the video is not playing, then play the video
//                if (gameObject.activeInHierarchy && videoComponent.GetState() != VisionOSVideoComponent.PlayerState.IsPlaying)
//                {
//                    videoComponent.Play();
//                }
//                // Check if the GameObject is inactive and the video is playing, then stop the video
//                else if (!gameObject.activeInHierarchy && videoComponent.GetState() == VisionOSVideoComponent.PlayerState.IsPlaying)
//                {
//                    videoComponent.Stop();
//                    Debug.Log("Video Stopped");

//                }
//            }
//        }
//    }
//}


//using UnityEngine;

//namespace Unity.PolySpatial
//{
//    public class VideoControlManager : MonoBehaviour
//    {
//        public VisionOSVideoComponent[] videoComponent;

//        public void StopVideo(int videoIdx)
//        {
//            if (videoComponent[videoIdx] != null && videoComponent[videoIdx].GetState() == VisionOSVideoComponent.PlayerState.IsPlaying)
//            {
//                videoComponent[videoIdx].Stop();
//                Debug.Log("Video Stopped");
//            }
//        }
//    }
//}


using UnityEngine;
using System.Collections;

namespace Unity.PolySpatial
{
    public class VideoControlManager : MonoBehaviour
    {
        public VisionOSVideoComponent[] videoComponent;
        public GameObject[] objectsToTurnOff; // Array of GameObjects to be turned off

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
                if (videoComponent[videoIdx] != null && videoComponent[videoIdx].GetState() == VisionOSVideoComponent.PlayerState.IsPlaying)
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
}

