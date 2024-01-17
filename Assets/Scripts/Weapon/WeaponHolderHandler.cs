using System;
using System.Linq;
using UnityEngine;

public abstract class WeaponHolderHandler : TransformHandler
{
    private float radius, angle;

    private void Awake()
    {
        radius = Mathf.Sqrt(Mathf.Pow(transform.localPosition.x, 2) + Mathf.Pow(transform.localPosition.y, 2));
        angle = Mathf.Atan2(transform.localPosition.y, transform.localPosition.x);

        Successors = GetComponentsInParent<ArmHandler>().ToList<TransformHandler>();
    }

    public override bool Transform(object[] args)
    {
        Vector3 pos = (Vector3)args[0];
        Vector3 rot = (Vector3)args[1];
        if (pos == null || rot == null) throw new ArgumentException($"{GetType()}: Expected Vector3 type argument");
        return this.Transform(pos, rot);
    }

    //
    // Calculates the Player's Hand Position/Rotation based on the Grip's/Holder's Position/Rotation
    // (Grip Position/Rotation = Holder Position/Rotation)
    //
    private bool Transform(Vector3 gripPosition, Vector3 gripRotation)
    {
        TransformVariable weaponTransform = new TransformVariable(
            // position
            new Vector3(gripPosition.x - radius * Mathf.Cos(gripRotation.z * Mathf.Deg2Rad + angle),
                gripPosition.y - radius * Mathf.Sin(gripRotation.z * Mathf.Deg2Rad + angle),
                gripPosition.z),
            // rotation
            gripRotation);

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
