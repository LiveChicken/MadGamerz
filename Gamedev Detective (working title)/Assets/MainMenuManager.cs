using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour {

    public MenuState state;

    public Controls controls;
    [Space] public GameObject QuitDialoGameObject;
    
    [Space]

    public UnityEvent OnStartPressed;

    public UnityEvent OnReturnToStart;

    private EventSystem eSystem;


    private void Awake() {
       // GM       = this;
        controls = new Controls();

    }

    private void OnEnable() {
        controls.UI.Enable();
    }

    private void OnDisable() {
        controls.UI.Disable();
    }
    
    
    
    public enum MenuState {

        Start,
        Main,
        Files,
        Options,
        Extras,
        Quit
        
    }

    public void StartPressed() {

        OnStartPressed?.Invoke();

        state = MenuState.Main;

    }


    public void ReturnToStart() {

        OnReturnToStart?.Invoke();
        
        QuitDialoGameObject.SetActive(false);

        state = MenuState.Start;

    }

    //TODO: MAKE IT NOT SHIT. load saves, load async, prevent multiload, do better

    public void LaunchGame() {

        SceneManager.LoadScene(1);

    }

    

    private void Start() {
        eSystem = FindObjectOfType<EventSystem>();
    }

    void Update() {


        if (controls.UI.Cancel.triggered) {

            if (state == MenuState.Main) {

                ReturnToStart();
                
            }

            else  if (state == MenuState.Start) {

                QuitDialoGameObject.SetActive(true);

                state = MenuState.Quit;

            }

           else if (state == MenuState.Quit) {

                QuitDialoGameObject.SetActive(false);

                state = MenuState.Start;

            }

        }



    }
}
