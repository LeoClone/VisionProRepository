using UnityEngine;

namespace PolySpatial.Samples
{
    [RequireComponent(typeof(Rigidbody))]
    public class PieceSelectionBehavior : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer m_MeshRenderer;

        [SerializeField]
        Material m_DefaultMat;

        [SerializeField]
        Material m_SelectedMat;

        Rigidbody m_RigidBody;

        public int selectingPointer { get; private set; } = ManipulationInputManager.k_Deselected;

        private Vector3 initialPosition;
        private Quaternion initialRotation;
        private float initialScale;

        void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();

            initialPosition = transform.position;
            initialRotation = transform.rotation;
            initialScale = transform.localScale.x;
        }

        public void SetSelected(int pointer)
        {
            var isSelected = pointer != ManipulationInputManager.k_Deselected;
            selectingPointer = pointer;
            m_RigidBody.isKinematic = isSelected;
            if (m_DefaultMat != null)
            {
                m_MeshRenderer.material = isSelected ? m_SelectedMat : m_DefaultMat;
            }
            
        }

        public void ResetTransform()
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            transform.localScale = new Vector3(initialScale, initialScale, initialScale);
        }
    }
}
