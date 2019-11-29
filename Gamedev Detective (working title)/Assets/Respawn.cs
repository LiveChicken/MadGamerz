using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void RespawnMe() {

        if (Checkpoint.Active == null) {

            DestroyImmediate(gameObject);
            
        } else {

            transform.position = Checkpoint.Active.transform.position;

            GetComponent<Health>().ChangeHealth(3);

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }


    }
}
