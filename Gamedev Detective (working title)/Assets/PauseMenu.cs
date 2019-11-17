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

        //Time.timeScale = 1;
        GameManager.GM.SetPause(false);
        
        SceneManager.LoadScene(0);

    }

}
