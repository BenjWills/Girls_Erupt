using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public InGameMenuSettings iGMenuSettings;
    private Vector2 moveInput;
    public Rigidbody rb;
    [SerializeField] float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void PauseUnpause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        if (isPaused == true)
        {
            iGMenuSettings.PauseGame();
        }
        else
        {
            iGMenuSettings.ResumeGame();
        }
    }

    public void Movement()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
