using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public InGameMenuSettings iGMenuSettings;
    private Vector2 moveInput;
    public Rigidbody rb;
    public Transform playerBody;
    [SerializeField] float movementSpeed = 10f;
    private Team1Game inputActions;
    private InputAction menu;

    public float mouseSensitivity;
    private Vector2 mouseLook;
    private float xRotation;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new Team1Game();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        inputActions.Enable();

        menu = inputActions.UI.PauseUnpause;
        menu.Enable();

        menu.performed += OnPause;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Look();
    }

    public void Movement()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    public void Look()
    {
        mouseLook = inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void OnPause(InputAction.CallbackContext context)
    {
        iGMenuSettings.isPaused = !iGMenuSettings.isPaused;
        if (iGMenuSettings.isPaused == true)
        {
            iGMenuSettings.PauseGame();
        }
        else
        {
            iGMenuSettings.ResumeGame();
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
