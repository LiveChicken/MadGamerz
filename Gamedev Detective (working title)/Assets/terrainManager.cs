using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.XR.WSA;


public class terrainManager : MonoBehaviour {

    public TileBase CurrentTile;

    [HideInInspector]
    public bool isOnDirt;

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



    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (Checks.CompareLayers(dirtMask, other.gameObject)) {

            isOnDirt = true;

        }

    }


    private void OnTriggerExit2D(Collider2D other) {

        if (Checks.CompareLayers(dirtMask, other.gameObject)) {

            isOnDirt = false;

        }

    }

}
