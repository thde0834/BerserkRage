using UnityEngine;

[CreateAssetMenu(menuName = "SOVariables/Vector3")]
public class Vector3Variable : SOVariable<Vector3>
{
    public override void SetValue(Vector3 value)
    {
        Value = value;
    }

    public override void SetValue(SOVariable<Vector3> value)
    {
        Value = value.Value;
    }

    public override void ApplyChange(Vector3 amount)
    {
        Value += amount;
    }

    public override void ApplyChange(SOVariable<Vector3> amount)
    {
        Value += amount.Value;
    }
}
