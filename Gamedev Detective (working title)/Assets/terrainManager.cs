using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.XR.WSA;


public class terrainManager : MonoBehaviour {

    public TileBase CurrentTile;

  //  [HideInInspector]
  //  public bool isOnDirt;

    private Tilemap GroundMap;

    [SerializeField]

private LayerMask dirtMask;
    
    // Start is called before the first frame update
    void Start() {
       // GroundMap = FindObjectOfType<Tilemap>()
    }

    // Update is called once per frame
    void Update() {


        if (GroundMap != null) {
            //CurrentTile = GroundMap.GetTile(GroundMap.WorldToCell(transform.position));
        }


       // RaycastHit2D hit; 
        
        //if (Physics2D.Raycast(transform.position, )

        if (Physics2D.OverlapPoint(transform.position, dirtMask)) {

            Player2DState.P2S.OnDirt = true;
            
        } else {

            Player2DState.P2S.OnDirt = false;
            
        }

    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (Checks.CompareLayers(dirtMask, other.gameObject)) {

          //  Player2DState.P2S.OnDirt = true;

        }

    }


    private void OnTriggerExit2D(Collider2D other) {

        if (Checks.CompareLayers(dirtMask, other.gameObject)) {

            //Player2DState.P2S.OnDirt = false;

        }

    }

}
