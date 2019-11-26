using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Behavior {


    public float speed;

    public Transform Target;


    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }

    public override void OnActivate() {
        throw new System.NotImplementedException();
    }

   // public override void Perform() {
      // throw new System.NotImplementedException();
  //  }

    public override void OnDeactivate() {
        throw new System.NotImplementedException();
    }
}
