using UnityEngine;

namespace _Scripts
{
    public class MouseLook : MonoBehaviour
    {
        [Header("Options:")]
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private float minAngle = -90f;
        [SerializeField] private float maxAngle = 90f;
        
        private float xRotation;

        private Transform playerBody;
   

        private void Awake()
        {
            playerBody = transform.parent.transform;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
