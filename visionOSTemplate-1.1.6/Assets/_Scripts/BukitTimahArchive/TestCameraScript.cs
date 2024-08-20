using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.PolySpatial;

public class TestCameraScript : MonoBehaviour
{
    public TextMeshPro text;
    Camera mainCam;
    public VolumeCamera volumeCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //volumeCamera.OutputDimensions.z;
        text.text = volumeCamera.transform.position.z.ToString();
    }
}
