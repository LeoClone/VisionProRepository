using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnScript : MonoBehaviour
{
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Translate(new Vector3(0, 0, -distance));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.allCameras[0].transform.position);
    }
}
