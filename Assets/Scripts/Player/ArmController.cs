using System;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    private const float FLOAT_THRESHOLD = 0.005f;

    [SerializeField]
    private Transform upperArm, forearm, hand;
    private JointController shoulder, elbow, wrist;

    [SerializeField]
    private Vector3Variable handPosition, handRotation;

    // storage values
    private float upperArmLength, upperArmLengthSq,
                    forearmLength, forearmLengthSq,
                    handDist = 0f;

    // storage angle values in Degrees
    private float aimDeg, shoulderDeg, elbowDeg = 0f;

    private float handDistSq => Mathf.Pow(handDist, 2);

    private void Start()
    {
        shoulder = upperArm.GetComponent<JointController>();
        elbow = forearm.GetComponent<JointController>();
        wrist = hand.GetComponent<JointController>();

        upperArmLength = Vector3.Distance(upperArm.transform.position, forearm.transform.position);
        upperArmLengthSq = Mathf.Pow(upperArmLength, 2);
        forearmLength = Vector3.Distance(forearm.transform.position, hand.transform.position);
        forearmLengthSq = Mathf.Pow(forearmLength, 2);
    }

    private void OnEnable()
    {
        handPosition.OnValueChanged += PositionHandler;
        handRotation.OnValueChanged += RotationHandler;

    }

    private void OnDisable()
    {
        handPosition.OnValueChanged -= PositionHandler;
        handRotation.OnValueChanged -= RotationHandler;
    }

    private void PositionHandler(Vector3 handPos)
    {
        handDist = Vector3.Distance(upperArm.transform.position, handPos);

        aimDeg = Mathf.Atan2(upperArm.transform.position.y - handPos.y, upperArm.transform.position.x - handPos.x) * Mathf.Rad2Deg;
        aimDeg = aimDeg + 360 % 360;

        // necessary due to float point precision
        if ((upperArmLength + forearmLength >= handDist) == false) handDist -= FLOAT_THRESHOLD;

        shoulderDeg = Mathf.Acos(
                (upperArmLengthSq + handDistSq - forearmLengthSq) /
                (2 * upperArmLength * handDist)
                ) * 180 / Mathf.PI;

        elbowDeg = Mathf.Acos(
                (upperArmLengthSq + forearmLengthSq - handDistSq) /
                (2 * upperArmLength * forearmLength)
                ) * 180 / Mathf.PI;

        //if (!shoulder.CanRotate(90f + aimDeg - shoulderDeg) || !elbow.CanRotate(180f - elbowDeg)) return;

        Debug.Log($"aim: {aimDeg} shoulder: {shoulderDeg} elbow: {elbowDeg}");

        upperArm.localEulerAngles = new Vector3(0f, 0f, aimDeg - shoulderDeg - 90f);
        forearm.localEulerAngles = new Vector3(0f, 0f, 180f - elbowDeg);
    }

    private void RotationHandler(Vector3 rot)
    {
        hand.eulerAngles = rot;
    }
}


//public class ArmController : MonoBehaviour
//{
//    private const float FLOAT_THRESHOLD = 0.0005f;

//    [SerializeField]
//    private Transform upperArm, forearm, hand, holdPos;
//    private JointController shoulder, elbow, wrist;

//    [SerializeField] private Vector3Variable weaponPosition, weaponRotation, weaponPivot;
//    [SerializeField] private FloatVariable weaponRadius;

//    [SerializeField] private Vector2Variable aimVector;

//    // storage values
//    private float upperArmLength, upperArmLengthSq,
//                    forearmLength, forearmLengthSq,
//                    handDist,
//                    localPosAdjustDist = 0f;

//    private float handDistSq => Mathf.Pow(handDist, 2);

//    // storage angle values in Degrees
//    private float aimDeg, shoulderDeg, elbowDeg, wristDeg = 0f;

//    private Vector3 weaponPos, weaponRot = Vector3.zero;

//    private void Start()
//    {
//        shoulder = upperArm.GetComponent<JointController>();
//        elbow = forearm.GetComponent<JointController>();
//        wrist = hand.GetComponent<JointController>();

//        localPosAdjustDist = Mathf.Sqrt(Mathf.Pow(holdPos.localPosition.x, 2) + Mathf.Pow(holdPos.localPosition.y, 2));

//        upperArmLength = Vector3.Distance(upperArm.transform.position, forearm.transform.position);
//        upperArmLengthSq = Mathf.Pow(upperArmLength, 2);
//        forearmLength = Vector3.Distance(forearm.transform.position, hand.transform.position);
//        forearmLengthSq = Mathf.Pow(forearmLength, 2);
//    }

//    private void OnEnable() => aimVector.OnValueChanged += AimHandler;
//    private void OnDisable() => aimVector.OnValueChanged -= AimHandler;

//    private void AimHandler(Vector2 aim)
//    {
//        aim.Normalize();

//        // Radians to Degrees conversion
//        aimDeg = Mathf.Atan2(aim.y, aim.x) * 180f / Mathf.PI;

//        weaponPos.Set(
//            weaponPivot.Value.x + aim.x * weaponRadius.Value - aim.x * localPosAdjustDist,
//            weaponPivot.Value.y + aim.y * weaponRadius.Value - aim.y * localPosAdjustDist,
//            weaponPos.z);

//        weaponRot.Set(0f, 0f, aimDeg);

//        handDist = Vector3.Distance(upperArm.transform.position, weaponPos);

//        if ((upperArmLength + forearmLength >= handDist) == false) handDist -= FLOAT_THRESHOLD; // necessary due to float point precision

//        shoulderDeg = Mathf.Acos(
//                (upperArmLengthSq + handDistSq - forearmLengthSq) /
//                (2 * upperArmLength * handDist)
//                ) * 180 / Mathf.PI;

//        elbowDeg = Mathf.Acos(
//                (upperArmLengthSq + forearmLengthSq - handDistSq) /
//                (2 * upperArmLength * forearmLength)
//                ) * 180 / Mathf.PI;

//        wristDeg = 180f - shoulderDeg - elbowDeg;

//        if (!shoulder.CanRotate(90f + aimDeg - shoulderDeg) || !elbow.CanRotate(180f - elbowDeg) || !wrist.CanRotate(360f - wristDeg)) return;

//        shoulder.Rotate(90f + aimDeg - shoulderDeg);
//        elbow.Rotate(180f - elbowDeg);
//        wrist.Rotate(360f - wristDeg);

//        weaponPosition.SetValue(weaponPos);
//        weaponRotation.SetValue(weaponRot);

//    }

//}