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
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation *= Quaternion.Euler(Mathf.Clamp(-mouseY,-90f,90f), 0f, 0f);


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
