using System;
using System.Linq;
using UnityEngine;

public abstract class WeaponGripHandler : TransformHandler
{
    private float radius, localRot;

    private void Awake()
    {
        localRot = transform.localEulerAngles.z * Mathf.Deg2Rad;
        radius = Mathf.Sqrt(Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow(transform.localPosition.y, 2));
    }

    public override bool Transform(object[] args)
    {
        Vector3 pos = (Vector3)args[0];
        Vector3 rot = (Vector3)args[1];
        if (pos == null || rot == null) throw new ArgumentException($"{GetType()}: Expected Vector3 type argument");
        return this.Transform(pos, rot);
    }

    //
    // Calculates the Weapon Grip Position/Rotation based on the Weapon's Position/Rotation
    //
    private bool Transform(Vector3 weaponPosition, Vector3 weaponRotation)
    {
        TransformVariable weaponTransform = new TransformVariable(
            // position
            new Vector3(weaponPosition.x - radius * Mathf.Cos(weaponRotation.z * Mathf.Deg2Rad + localRot),
                weaponPosition.y - radius * Mathf.Sin(weaponRotation.z * Mathf.Deg2Rad + localRot),
                weaponPosition.z),
            // rotation
            new Vector3(0f, 0f, weaponRotation.z + localRot * Mathf.Rad2Deg));

        if (Successors.Count == 0 || Successors.All(s => s.Transform(new object[] { weaponTransform.Position, weaponTransform.Rotation })))
        {
            Save(weaponTransform);
            Execute(weaponTransform);
            return true;
        }

        return false;
    }

    protected override void Execute(TransformVariable val)
    {
        transform.position = val.Position;
        transform.eulerAngles = val.Rotation;
    }

    public override void Revert()
    {
        base.Revert();

        transform.position = TransformStack[0].Position;
        transform.eulerAngles = TransformStack[0].Rotation;
    }
}