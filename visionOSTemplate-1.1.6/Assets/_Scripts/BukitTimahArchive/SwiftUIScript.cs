using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using PolySpatial.Samples;
using UnityEngine;

public class SwiftUIScript : MonoBehaviour
{
    [SerializeField]
    SpatialUIButton m_Button;

    [SerializeField]
    List<GameObject> m_ObjectsToSpawn;

    [SerializeField]
    Transform m_SpawnPosition;

    [SerializeField]
    PieceSelectionBehavior bukitTimahScript;

    [SerializeField]
    PieceSelectionBehavior cubeScript;

    [SerializeField]
    ObjectUIScript _uiScript;

    bool m_SwiftUIWindowOpen = false;

    void OnEnable()
    {
        m_Button.WasPressed += WasPressed;
        SetNativeCallback(CallbackFromNative);
    }

    void OnDisable()
    {
        SetNativeCallback(null);
        CloseSwiftUIWindow("Test");
    }

    void WasPressed(string buttonText, MeshRenderer meshrenderer)
    {
        if (m_SwiftUIWindowOpen)
        {
            CloseSwiftUIWindow("Test");
            m_SwiftUIWindowOpen = false;
        }
        else
        {
            OpenSwiftUIWindow("Test");
            m_SwiftUIWindowOpen = true;
        }
    }

    delegate void CallbackDelegate(string command);

    // This attribute is required for methods that are going to be called from native code
    // via a function pointer.
    [MonoPInvokeCallback(typeof(CallbackDelegate))]
    static void CallbackFromNative(string command)
    {
        Debug.Log("Callback from native: " + command);

        // This could be stored in a static field or a singleton.
        // If you need to deal with multiple windows and need to distinguish between them,
        // you could add an ID to this callback and use that to distinguish windows.
        var self = Object.FindFirstObjectByType<SwiftUIScript>();

        if (command == "closed")
        {
            self.m_SwiftUIWindowOpen = false;
            return;
        }

        if (command == "reset bukit timah")
        {
            self.bukitTimahScript.ResetTransform();
        }
        else if (command == "swap cube")
        {
            self._uiScript.SwitchObject(self.cubeScript.gameObject);
            CloseSwiftUIWindow("Test");
            OpenSwiftUIWindow("Cube");
        }
        else if (command == "reset cube")
        {
            self.cubeScript.ResetTransform();
        }
        else if (command == "swap bukit timah")
        {
            self._uiScript.SwitchObject(self.bukitTimahScript.gameObject);
            CloseSwiftUIWindow("Cube");
            OpenSwiftUIWindow("Test");
        }
    }

    void Spawn(Color color)
    {
        var randomObject = Random.Range(0, m_ObjectsToSpawn.Count);
        var thing = Instantiate(m_ObjectsToSpawn[randomObject], m_SpawnPosition.position, Quaternion.identity);
        thing.GetComponent<MeshRenderer>().material.color = color;
    }

#if UNITY_VISIONOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        static extern void SetNativeCallback(CallbackDelegate callback);

        [DllImport("__Internal")]
        static extern void OpenSwiftUIWindow(string name);

        [DllImport("__Internal")]
        static extern void CloseSwiftUIWindow(string name);
#else
    static void SetNativeCallback(CallbackDelegate callback) { }
    static void OpenSwiftUIWindow(string name) { }
    static void CloseSwiftUIWindow(string name) { }
#endif

}
