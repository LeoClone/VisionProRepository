using System.Collections.Generic;
using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace PolySpatial.Samples
{
    /// <summary>
    /// Current you can only select one object at a time and only supports a primary [0] touch
    /// </summary>
    public class MovementUIScript : MonoBehaviour
    {
        private bool stoppedClick = true;

        struct Selection
        {
            /// <summary>
            /// The piece that is selected
            /// </summary>
            public PieceSelectionBehavior Piece;

            /// <summary>
            /// The offset between the interaction position and the position selected object for an identity device rotation.
            /// This is computed at the beginning of the interaction and combined with the current device rotation and interaction position to translate the object
            /// as the user moves their hand.
            /// </summary>
            public Vector3 PositionOffset;

            /// <summary>
            /// The difference in rotations between the initial device rotation and the selected object.
            /// This is computed at the beginning of the interaction and combined with the current device rotation to rotate the object as the user moves their hand.
            /// </summary>
            public Quaternion RotationOffset;
        }

        internal const int k_Deselected = -1;
        readonly Dictionary<int, Selection> m_CurrentSelections = new();

        public GameObject recentlySelected;
        public GameObject previousSelectedUI;

        void OnEnable()
        {
            EnhancedTouchSupport.Enable();
        }

        private void Start()
        {
            //recentlySelected = GameObject.Find("BukitTimah");
        }

        void Update()
        {
            if (Touch.activeTouches.Count >= 2)
            {
                Touch touch1 = Touch.activeTouches[0];
                Touch touch2 = Touch.activeTouches[1];

                Vector2 previousTouch1 = touch1.screenPosition - touch1.delta;
                Vector2 previousTouch2 = touch2.screenPosition - touch2.delta;

                float previousTouchDeltaMagnitude = (previousTouch1 - previousTouch2).magnitude;
                float touchDeltaMagnitude = (touch1.screenPosition - touch2.screenPosition).magnitude;

                float deltaMagnitudeDifference = touchDeltaMagnitude - previousTouchDeltaMagnitude;

                float newScale = recentlySelected.transform.localScale.x + deltaMagnitudeDifference * 0.05f;
                newScale = Mathf.Clamp(newScale, 0.1f, 0.4f);

                recentlySelected.transform.localScale = new Vector3(newScale, newScale, newScale);

                return;
            }


            foreach (var touch in Touch.activeTouches)
            {
                //Debug.Log("touch");
                var spatialPointerState = EnhancedSpatialPointerSupport.GetPointerState(touch);
                var interactionId = spatialPointerState.interactionId;

                SpatialPointerState primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(touch);

                // Ignore poke input--piece will get stuck to the user's finger
                if (spatialPointerState.Kind == SpatialPointerKind.Touch)
                    continue;

                var pieceObject = spatialPointerState.targetObject;
                if (pieceObject != null)
                {
                    // Swap materials and record initial relative position & rotation from hand to object for later use when the piece is selected
                    if (pieceObject.TryGetComponent(out PieceSelectionBehavior piece) && piece.selectingPointer == -1)
                    {
                        var pieceTransform = piece.transform;
                        var interactionPosition = spatialPointerState.interactionPosition;
                        var inverseDeviceRotation = Quaternion.Inverse(spatialPointerState.inputDeviceRotation);
                        var rotationOffset = inverseDeviceRotation * pieceTransform.rotation;
                        var positionOffset = inverseDeviceRotation * (pieceTransform.position - interactionPosition);
                        piece.SetSelected(interactionId);

                        // Because events can come in faster than they are consumed, it is possible for target id to change without a prior end/cancel event
                        if (m_CurrentSelections.TryGetValue(interactionId, out var selection))
                            selection.Piece.SetSelected(k_Deselected);

                        m_CurrentSelections[interactionId] = new Selection
                        {
                            Piece = piece,
                            RotationOffset = rotationOffset,
                            PositionOffset = positionOffset
                        };

                    }
                }

                switch (spatialPointerState.phase)
                {
                    case SpatialPointerPhase.Moved:
                        if (m_CurrentSelections.TryGetValue(interactionId, out var selection))
                        {
                            if (selection.Piece.gameObject.tag == "MovementBarChild")
                            {
                                Debug.Log("xxx");
                                if(stoppedClick)
                                {

                                    stoppedClick = false;

                                    Debug.Log("AAAA");

                                    if (previousSelectedUI != null)
                                    {
                                        if (previousSelectedUI != selection.Piece.gameObject)
                                        {
                                            if (previousSelectedUI.tag == "MovementBarChild")
                                            {
                                                Debug.Log("ADS");
                                                GameObject barParent = previousSelectedUI.transform.parent.gameObject;

                                                barParent.GetComponent<Image>().enabled = false;
                                                barParent.GetComponent<BoxCollider>().enabled = false;

                                                GameObject barChild = previousSelectedUI.transform.Find("GrabberX").gameObject;
                                                barChild.GetComponent<Image>().enabled = false;
                                                barChild.GetComponent<BoxCollider>().enabled = false;

                                            }

                                        }
                                    }


                                    previousSelectedUI = selection.Piece.gameObject;

                                    GameObject movementBar = selection.Piece.gameObject.transform.parent.gameObject;
                                    Image barImage = movementBar.GetComponent<Image>();
                                    BoxCollider barCollider = movementBar.GetComponent<BoxCollider>();

                                    GameObject closeBar = selection.Piece.gameObject.transform.Find("GrabberX").gameObject;
                                    Image closeImage = closeBar.GetComponent<Image>();
                                    BoxCollider closeCollider = closeBar.GetComponent<BoxCollider>();

                                    bool isEnabled = barImage.enabled;

                                    barImage.enabled = !isEnabled;
                                    barCollider.enabled = !isEnabled;

                                    closeImage.enabled = !isEnabled;
                                    closeCollider.enabled = !isEnabled;

                                }
                            }
                            else if (selection.Piece.gameObject.name == "GrabberX")
                            {
                                GameObject mainUI = selection.Piece.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                                mainUI.SetActive(false);

                                //selection.Piece.gameObject.SetActive(false);
                                //Debug.Log(mainUI);
                            }
                            else if (selection.Piece.gameObject.name == "VideoCube")
                            {
                                Unity.PolySpatial.VisionOSVideoComponent videoComp = selection.Piece.gameObject.GetComponent<Unity.PolySpatial.VisionOSVideoComponent>();
                                videoComp.Play();
                                //Debug.Log(mainUI);
                            }
                            else if (selection.Piece.gameObject.tag == "MovementBar")
                            {
                                recentlySelected = selection.Piece.gameObject;

                                float deltaX = touch.delta.x * 0.0001f;
                                float deltaZ = touch.delta.y * 0.0001f;


                                //Debug.Log(deltaX);
                                //Debug.Log(touch.delta);

                                Vector3 newPosition = new Vector3(deltaX, 0, deltaZ);


                                // Position the piece at the interaction position, maintaining the same relative transform from interaction position to selection pivot
                                var deviceRotation = spatialPointerState.inputDeviceRotation;
                                var rotation = deviceRotation * selection.RotationOffset;
                                //var position = spatialPointerState.interactionPosition + deviceRotation * selection.PositionOffset;
                                //var position = newPosition + deviceRotation * selection.PositionOffset;
                                //Debug.Log(spatialPointerState.interactionPosition);
                                //Debug.Log(touch.screenPosition);

                                //var position = spatialPointerState.interactionPosition + deviceRotation * selection.PositionOffset;

                                //selection.Piece.transform.SetPositionAndRotation(position, rotation);

                                //selection.Piece.transform.Translate(newPosition);

                                selection.Piece.transform.position = primaryTouchData.interactionPosition;
                                selection.Piece.transform.rotation = rotation;

                            }
                        }
                        else
                        {
                            
                            stoppedClick = true;
                            /*
                            float rotationSpeed = -0.1f;
                            float deltaX = touch.delta.x * rotationSpeed;

                            //Debug.Log(deltaX);

                            Quaternion currentRotation = recentlySelected.transform.rotation;


                            // Calculate the new rotation by applying the rotation increment along the y-axis
                            recentlySelected.transform.rotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0, deltaX, 0));
                            //Debug.Log("not touching");
                            */
                        }

                        break;
                    case SpatialPointerPhase.None:
                        stoppedClick = true;
                        break;
                    case SpatialPointerPhase.Ended:
                        stoppedClick = true;
                        break;
                    case SpatialPointerPhase.Cancelled:
                        DeselectPiece(interactionId);
                        stoppedClick = true;
                        break;
                }
            }
        }

        void DeselectPiece(int interactionId)
        {
            if (m_CurrentSelections.TryGetValue(interactionId, out var selection))
            {
                // Swap materials back when the piece is deselected
                selection.Piece.SetSelected(k_Deselected);
                m_CurrentSelections.Remove(interactionId);
            }
        }
    }
}
