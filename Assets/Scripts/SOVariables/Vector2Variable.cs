using UnityEngine;

[CreateAssetMenu(menuName = "SOVariables/Vector2")]
public class Vector2Variable : SOVariable<Vector2>
{
    public override void SetValue(Vector2 value)
    {
        Value = value;
    }

    public override void SetValue(SOVariable<Vector2> value)
    {
        Value = value.Value;
    }

    public override void ApplyChange(Vector2 amount)
    {
        Value += amount;
    }

    public override void ApplyChange(SOVariable<Vector2> amount)
    {
        Value += amount.Value;
    }
}