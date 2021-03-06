using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp : MonoBehaviour {

	public GameObject pin;
	public float rotPerc;
	public float folPerc;

	private float zPoint;

	Vector2 pos;
	Vector2 pinPos;
	Quaternion rot;
	Quaternion pinRot;

	// Use this for initialization
	void Start () {

		zPoint = transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {


		//float perc = 
		//transform.position = Vector3.Lerp (transform.position, pin.transform.position, 0.1);
		//transform.rotation = Vector3.Lerp (transform.rotation, pin.transform.rotation, 0.1);

		pos = transform.position;
		pinPos = pin.transform.position;
		rot = transform.rotation;
		pinRot = pin.transform.rotation;


		transform.rotation = Quaternion.Lerp (rot, pinRot, rotPerc * Time.deltaTime);

		transform.position = Vector2.Lerp (pos, pinPos, folPerc * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, zPoint);




	}
}
