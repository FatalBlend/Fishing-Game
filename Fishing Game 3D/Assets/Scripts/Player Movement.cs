using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float playerMovementSpeed = 4f;
    [SerializeField] private new Camera camera;

    private float mouseX;
    private float mouseY;
    private float xRotation;
    private float yRotation;


    private float x;
    private float z;


    private Vector3 move;
    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        #region Player look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Update xRotation and clamp
        xRotation -= mouseY; // Subtract mouseY to invert it for looking up/down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotations
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Up/down rotation
        transform.Rotate(Vector3.up * mouseX); // Left/right rotation


        #endregion

        #region Player movement
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, 1f);
        characterController.Move(move * playerMovementSpeed * Time.deltaTime);
        #endregion
    }
}
