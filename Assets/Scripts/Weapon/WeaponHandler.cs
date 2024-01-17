using System;
using System.Linq;
using UnityEngine;

public class WeaponHandler : TransformHandler
{
    [SerializeField]
    private Weapon weapon;

    private void Awake()
    {
        Successors = GetComponentsInChildren<WeaponGripHandler>().ToList<TransformHandler>();
    }

    public override bool Transform(object[] args)
    {
        Vector2 aimVector = (Vector2)args[0];
        if (aimVector == null) throw new ArgumentException($"{GetType()}: Expected Vector2 type argument");
        return this.Transform(aimVector);
    }

    //
    // Calculates the Weapon's Position/Rotation based on the Aim Input
    //
    private bool Transform(Vector2 aimVector)
    {
        TransformVariable weaponTransform = new TransformVariable(
                // position
                new Vector3(weapon.Pivot.Value.x + aimVector.x * weapon.Radius.Value,
                    weapon.Pivot.Value.y + aimVector.y * weapon.Radius.Value,
                    weapon.Pivot.Value.z),
                // rotation
                new Vector3(0f, 0f, Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg));

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