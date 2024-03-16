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

    [SerializeField] float movementSpeed = 10f;
    PlayerInput playerInput;
    InputAction moveAction;

    private Team1Game inputActions;
    private InputAction menu;


    // Start is called before the first frame update
    void Start()
    {
        inputActions = new Team1Game();
        menu = inputActions.UI.PauseUnpause;
        menu.Enable();
        menu.performed += OnPause;

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    private void Update()
    {
        MovePlayer();
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

    public void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * movementSpeed * Time.deltaTime;
    }
}
