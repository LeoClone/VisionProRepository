using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyFollowStartScript : MonoBehaviour
{

    UnityEngine.XR.Interaction.Toolkit.UI.LazyFollow lazyFollow;

    

    // Start is called before the first frame update
    void Start()
    {
        lazyFollow = GetComponent<UnityEngine.XR.Interaction.Toolkit.UI.LazyFollow>();

        if (FollowSingleton.Instance.hasFollowed)
        {
            lazyFollow.enabled = false;
            transform.position = FollowSingleton.Instance.finalPosition;
            Debug.Log(FollowSingleton.Instance.finalPosition);
        }

        Invoke("Wait", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DisableComponent()
    {
        lazyFollow.enabled = false;

        FollowSingleton.Instance.finalPosition = transform.position;

        Debug.Log(FollowSingleton.Instance.finalPosition);
    }

    void Wait()
    {
        Debug.Log(FollowSingleton.Instance);
        if (!FollowSingleton.Instance.hasFollowed)
        {
            Invoke("DisableComponent", 0.5f);
            FollowSingleton.Instance.hasFollowed = true;
        }
    }
}
