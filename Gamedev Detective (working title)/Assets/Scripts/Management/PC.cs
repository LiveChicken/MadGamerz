using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PC : MonoBehaviour
{
    public GameObject ScreenCamera;

    //public List<Level2D> Levels = new List<Level2D>();

    public Level2D ToLoad;


    private void Update() {

        if (GameManager.GM.TS == Mode.S2D) {

            if (Input.GetButtonDown("Cancel")) {

                Transition();
                
            }

        }

    }

    void Launch2DGame() {

        if (GameManager.GM.TS == Mode.S2D) {

        } else {
            return;
        }

         if (!GameManager.GM.CartHasChanged) {
             return;
         }

         //Unload previous 2D

        //Load new 2D

        if (SceneManager.sceneCount > 1) {

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));

        }


        // Level2D ToLoad = Levels.Find(Level2D => Level2D.Letter == GameManager.GM.CurrentLevel2D);

        if (ToLoad == null) {

            //Debug.Log("No Cartridege of the letter " + GameManager.GM.CurrentLevel2D);

            return;



        }

        SceneManager.LoadScene(ToLoad.Scene2DIndex, LoadSceneMode.Additive);


    }

    public void Transition() {

        StartCoroutine(Trans());

    }

    public IEnumerator Trans() {

        if (GameManager.GM.TS == Mode.S3D) {

            GameManager.GM.TS = Mode.Between;

            ScreenCamera.SetActive(true);

            yield return null;

            float time = 0.5f;

            try {
                time = GameManager.GM.Brain.ActiveBlend.Duration;
            } catch {

            }

            yield return new WaitForSeconds(time);

            GameManager.GM.TS = Mode.S2D;

            Launch2DGame();

        } else if (GameManager.GM.TS == Mode.S2D) {

            GameManager.GM.TS = Mode.Between;

            ScreenCamera.SetActive(false);

            yield return null;

            float time = 0.5f;

            try {
                time = GameManager.GM.Brain.ActiveBlend.Duration;
            } catch {

            }

            yield return new WaitForSeconds(time);

            GameManager.GM.TS = Mode.S3D;

        }


    }
    
    
    
}
