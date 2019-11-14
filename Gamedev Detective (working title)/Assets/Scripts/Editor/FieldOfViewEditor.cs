using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (TargetingScript2))]
public class FieldOfViewEditor : Editor
{

     private void OnSceneGUI() {

          TargetingScript2 ts2 = (TargetingScript2) target;
          Handles.color = Color.white;
          Handles.DrawWireArc(ts2.transform.position, Vector3.up, Vector3.forward, 360, ts2.ViewRadius);
          Vector3 viewAngleA = ts2.DirFromAngle(-ts2.ViewAngle / 2);
          Vector3 viewAngleB = ts2.DirFromAngle(ts2.ViewAngle / 2);
          
         
          
         //Handles.color = Color.gray;

          Color col = Color.gray;
          col.a = 0.5f;

          Handles.color = col;
          //Handles.color.a = 0.5f;
          
          Handles.DrawSolidArc(ts2.transform.position, Vector3.up, ts2.transform.forward, ts2.ViewAngle / 2, ts2.ViewRadius);
          Handles.DrawSolidArc(ts2.transform.position, Vector3.up, ts2.transform.forward, -ts2.ViewAngle / 2, ts2.ViewRadius);
          
          Handles.color = Color.magenta;

          Handles.DrawLine(ts2.transform.position, ts2.transform.position + viewAngleA * ts2.ViewRadius);
          Handles.DrawLine(ts2.transform.position, ts2.transform.position + viewAngleB * ts2.ViewRadius);

     }


}
