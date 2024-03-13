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
    private float yRotation;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        inputActions = new Team1Game();

        menu = inputActions.UI.PauseUnpause;
        menu.Enable();

        menu.performed += OnPause;
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

        Vector3 playerVelocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }
}
