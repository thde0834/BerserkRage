using UnityEngine;

[System.Serializable]
public struct TransformVariable
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;

    public TransformVariable(Vector3 position)
    {
        this.Position = position;
        this.Rotation = Vector3.zero;
        this.Scale = Vector3.one;
    }
    public TransformVariable(Vector3 position, Vector3 rotation)
    {
        this.Position = position;
        this.Rotation = rotation;
        this.Scale = Vector3.one;
    }
    public TransformVariable(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        this.Position = position;
        this.Rotation = rotation;
        this.Scale = scale;
    }

    public void SetPosition(Vector3 position) =>this.Position = position;
    public void SetPosition(float x, float y, float z)
    {
        this.Position.x = x;
        this.Position.y = y;
        this.Position.z = z;
    }

    public void SetRotation(Vector3 rotation) => this.Rotation = rotation;
    public void SetRotation(float x, float y, float z)
    {
        this.Rotation.x = x;
        this.Rotation.y = y;
        this.Rotation.z = z;
    }

    public void SetScale(Vector3 scale) => this.Scale = scale;
    public void SetScale(float x, float y, float z)
    {
        this.Scale.x = x;
        this.Scale.y = y;
        this.Scale.z = z;
    }

}
