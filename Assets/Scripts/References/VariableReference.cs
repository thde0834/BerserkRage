// Children MUST have [System.Serializable]
public abstract class VariableReference<T> where T : new()
{
    public bool UseConstant = true;

    public T ConstantValue;
    public SOVariable<T> Variable;

    public VariableReference(){ }

    public VariableReference(T value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public T Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

}
