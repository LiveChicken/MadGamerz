using UnityEngine;


public class GeckoController : MonoBehaviour {
     public Transform Target;
     [Space]
     [SerializeField] private Transform headBone;

     [SerializeField] private float headMaxTurnAngle;
     [SerializeField]        private float headTrackingSpeed;

     [Space]
     [SerializeField]     Transform leftEyeBone;
     [SerializeField]     Transform rightEyeBone;
     [SerializeField]         float eyeTrackingSpeed;
     [SerializeField]         float leftEyeMaxYRotation;
     [SerializeField]         float leftEyeMinYRotation;
     [SerializeField]         float rightEyeMaxYRotation;
     [SerializeField]         float rightEyeMinYRotation;

     

     private void LateUpdate() {

         HeadTrackingUpdate();
         //EyeTrackingUpdate();

     }

     void EyeTrackingUpdate() {
          Quaternion targetEyeRotation = Quaternion.LookRotation(
               Target.position - headBone.position, // toward target
               transform.up
          );

          leftEyeBone.rotation = Quaternion.Slerp(
               leftEyeBone.rotation,
               targetEyeRotation,
               1 - Mathf.Exp(-eyeTrackingSpeed * Time.deltaTime)
          );

          rightEyeBone.rotation = Quaternion.Slerp(
               rightEyeBone.rotation,
               targetEyeRotation,
               1 - Mathf.Exp(-eyeTrackingSpeed * Time.deltaTime)
          );

          float leftEyeCurrentYRotation  = leftEyeBone.localEulerAngles.y;
          float rightEyeCurrentYRotation = rightEyeBone.localEulerAngles.y;

// Move the rotation to a -180 ~ 180 range
          if (leftEyeCurrentYRotation > 180) {
               leftEyeCurrentYRotation -= 360;
          }

          if (rightEyeCurrentYRotation > 180) {
               rightEyeCurrentYRotation -= 360;
          }

// Clamp the Y axis rotation
          float leftEyeClampedYRotation = Mathf.Clamp(
               leftEyeCurrentYRotation,
               leftEyeMinYRotation,
               leftEyeMaxYRotation
          );

          float rightEyeClampedYRotation = Mathf.Clamp(
               rightEyeCurrentYRotation,
               rightEyeMinYRotation,
               rightEyeMaxYRotation
          );

// Apply the clamped Y rotation without changing the X and Z rotations
          leftEyeBone.localEulerAngles = new Vector3(
               leftEyeBone.localEulerAngles.x,
               leftEyeClampedYRotation,
               leftEyeBone.localEulerAngles.z
          );

          rightEyeBone.localEulerAngles = new Vector3(
               rightEyeBone.localEulerAngles.x,
               rightEyeClampedYRotation,
               rightEyeBone.localEulerAngles.z
          );
          
          
     }

     void HeadTrackingUpdate() {
          var currentLocalRotation = headBone.localRotation;

          // Reset the head rotation so our world to local space transformation will use the head's zero rotation. 
          // Note: Quaternion.Identity is the quaternion equivalent of "zero"
          headBone.localRotation = Quaternion.identity;

          var targetWorldLookDir = Target.position - headBone.position;
          var targetLocalLookDir = headBone.InverseTransformDirection(targetWorldLookDir);

          // Apply angle limit
          targetLocalLookDir = Vector3.RotateTowards(
               Vector3.forward,
               targetLocalLookDir,
               Mathf.Deg2Rad * headMaxTurnAngle, // Note we multiply by Mathf.Deg2Rad here to convert degrees to radians
               0 // We don't care about the length here, so we leave it at zero
          );

          // Get the local rotation by using LookRotation on a local directional vector
          var targetLocalRotation = Quaternion.LookRotation(targetLocalLookDir, Vector3.up);

          // Apply smoothing
          headBone.localRotation = Quaternion.Slerp(
               currentLocalRotation,
               targetLocalRotation,
               1 - Mathf.Exp(-headTrackingSpeed * Time.deltaTime)
          );
     }

}