using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DialogueFilter))]
public class DialogueSpawner : MonoBehaviour {

     //[RequireComponent(typeof(FloatingTextBox)]
     public GameObject RandomTextBoxPrefab;


     private DialogueFilter DF;

     private int index;

     public delegate void SpawnTextDelegate();

     public static SpawnTextDelegate spawnTextDelegate = delegate {

     };


     private void OnEnable() {
          spawnTextDelegate += SpawnNext;
     }

     private void OnDisable() {
          spawnTextDelegate -= SpawnNext;
     }


     private void Start() {

          DF = GetComponent<DialogueFilter>();

     }


     public void SpawnNext() {


          GameObject temp = Instantiate(RandomTextBoxPrefab);
          temp.transform.SetParent(transform);
          temp.transform.localPosition = Vector3.zero;
          temp.transform.localScale = Vector3.one;
          temp.GetComponent<FloatingTextBox>().BeginText(DF.Lines[index].Dialogue, DF.Lines[index].Name);
          
          
          index++;


     }




}
