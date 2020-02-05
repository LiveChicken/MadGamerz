using UnityEngine;
public class ContinuousRotation : MonoBehaviour {

    [Tooltip("Degrees per second")]
    public float Speed;
    public Vector3 Axis = Vector3.right;

    private float theta;
 
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(theta, Axis.normalized);
        theta += Speed * Time.deltaTime;
    }
}
