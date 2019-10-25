using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEngine;
using UnityEngine.UI;


public class EnableOnButton : MonoBehaviour {

    //[Tooltip("The name of the button in the inputManager")]
    //public string ButtonName = "Give me a name";

    public float EnabledDuration;

    public bool UseWithGadget;
    
    [Space]
    public bool PopulateOnStart = true;
    
    [Space]
   public List<GameObject> GameObjectsToEnable = new List<GameObject>();


    public Mode mode = Mode.S2D;
    
    //private bool lockedOut;

    private bool wait;
    
    
    // Start is called before the first frame update
    void Start()
    {

        if (PopulateOnStart) {
               PopulateList();
        }

        //ockedOut = Checks.IsAxisAvailable(ButtonName);
        
      //  if (lockedOut) Debug.LogWarning("Locked out of: " + gameObject);

        ToggleAll(false);

    }

    void PopulateList() {



        foreach (Transform T in transform) {

            if (!GameObjectsToEnable.Contains(T.gameObject)) {
                GameObjectsToEnable.Add(T.gameObject);
            }

        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.TS == mode) {

            if (UseWithGadget || !GadgetManager.GadgetInUse ) {

                if (!wait) {

                    if (GameManager.GM.controls.Player.A.triggered) {

                        StartCoroutine(Unenable());


                    }
                }


            }
        }


    }

    void ToggleAll(bool on) {

        foreach (GameObject G in GameObjectsToEnable) {
            
            G.SetActive(on);
            
        }
        
    }

    IEnumerator Unenable() {

        wait = true;
        
        ToggleAll(true);
        
        yield return new WaitForSeconds(EnabledDuration);

        ToggleAll(false);

        wait = false;

    }

    private void OnDisable() {
        
        ToggleAll(false);

        wait = false;

    }

}
