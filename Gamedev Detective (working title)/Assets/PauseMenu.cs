using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {


    public Button Default;


    private void OnEnable() {
        
        Default.Select();
        
    }


    //TODO: Go through main 
    public void ReturnToMainMenu() {

        SceneManager.LoadScene(0);

    }

}
