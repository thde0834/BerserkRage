using UnityEngine;

[CreateAssetMenu(menuName = "SOVariables/Float")]
public class FloatVariable : SOVariable<float>
{
    public override void SetValue(float value)
    {
        Value = value;
    }

    public override void SetValue(SOVariable<float> value)
    {
        Value = value.Value;
    }

    public override void ApplyChange(float amount)
    {
        Value += amount;
    }

    public override void ApplyChange(SOVariable<float> amount)
    {
        Value += amount.Value;
    }
}
