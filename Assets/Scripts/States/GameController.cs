using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public BaseStates currentState;
    public readonly MenuState ms = new MenuState();


    private void Awake()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(ms);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(BaseStates state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
