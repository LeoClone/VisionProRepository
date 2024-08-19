using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronManStartPositionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(FollowSingleton.Instance.finalPosition.x, FollowSingleton.Instance.finalPosition.y - 0.5f, FollowSingleton.Instance.finalPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
