using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ArmHandler : TransformHandler
{
    private const float FLOAT_THRESHOLD = 0.005f;

    [SerializeField]
    private Transform shoulder, elbow, hand;

    [SerializeField]
    private RangedFloat shoulderDegRange, elbowDegRange;

    // storage values
    private float upperArmLength, upperArmLengthSq,
                    forearmLength, forearmLengthSq,
                    handDist = 0f;

    // storage angle values in Degrees
    private float targetDeg, shoulderDeg, elbowDeg = 0f;

    private float handDistSq => Mathf.Pow(handDist, 2);

    private void Awake()
    {
        upperArmLength = Vector3.Distance(shoulder.transform.position, elbow.transform.position);
        upperArmLengthSq = Mathf.Pow(upperArmLength, 2);
        forearmLength = Vector3.Distance(elbow.transform.position, hand.transform.position);
        forearmLengthSq = Mathf.Pow(forearmLength, 2);
    }

    public override bool Transform(object[] args)
    {
        Vector3 pos = (Vector3)args[0];
        Vector3 rot = (Vector3)args[1];
        if (pos == null || rot == null) throw new ArgumentException($"{GetType()}: Expected Vector3 type argument");
        return this.Transform(pos, rot);
    }

    private bool Transform(Vector3 handPosition, Vector3 handRotation)
    {
        handDist = Vector3.Distance(shoulder.transform.position, handPosition);

        targetDeg = Mathf.Atan2(shoulder.transform.position.y - handPosition.y, shoulder.transform.position.x - handPosition.x) * Mathf.Rad2Deg;

        // necessary due to float point precision
        if ((upperArmLength + forearmLength >= handDist) == false) handDist -= FLOAT_THRESHOLD;

        shoulderDeg = Mathf.Acos(
                (upperArmLengthSq + handDistSq - forearmLengthSq) /
                (2 * upperArmLength * handDist)
                ) * 180 / Mathf.PI;

        if (float.IsNaN(shoulderDeg)) return false;

        shoulderDeg = targetDeg - shoulderDeg - 90f;

        elbowDeg = Mathf.Acos(
                (upperArmLengthSq + forearmLengthSq - handDistSq) /
                (2 * upperArmLength * forearmLength)
                ) * 180 / Mathf.PI;

        if (float.IsNaN(elbowDeg)) return false;

        elbowDeg = 180f - elbowDeg;

        TransformVariable armTransform = new TransformVariable(
            // Shoulder Rotation
            position:   shoulderDeg < -180f ? 
                new Vector3(0f, 0f, shoulderDeg + 360f) : new Vector3(0f, 0f, shoulderDeg),
            // Elbow Rotation
            rotation:   elbowDeg < -180f ?
                new Vector3(0f, 0f, elbowDeg + 360f) : new Vector3(0f, 0f, elbowDeg),
            // Hand Rotation
            scale: handRotation);

        if (!shoulderDegRange.Contains(armTransform.Position.z) || !elbowDegRange.Contains(armTransform.Rotation.z)) return false;

        Save(armTransform);
        Execute(armTransform);

        return true;
    }

    protected override void Execute(TransformVariable val)
    {
        // Using TransformVariable in a unique way here
        shoulder.localEulerAngles = val.Position;
        elbow.localEulerAngles = val.Rotation;
        hand.eulerAngles = val.Scale;
    }

    public override void Revert()
    {
        base.Revert();

        shoulder.localEulerAngles = TransformStack[0].Position;
        elbow.localEulerAngles = TransformStack[0].Rotation;
        hand.localEulerAngles = TransformStack[0].Scale;
    }
}
