using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//
// Chain of Responsibility / Memento design pattern
// https://cu-classcapture.colorado.edu/Mediasite/Channel/224b0f9436804957a28f4b372bdc4fbb5f/watch/73140fe09fdd4b9db198b35fc7fa53881d
//
public abstract class TransformHandler : MonoBehaviour
{
    [field: SerializeField] public List<TransformHandler> Successors { get; protected set; } = new List<TransformHandler>();

    public List<TransformVariable> TransformStack { get; protected set; } = new List<TransformVariable>();

    public abstract bool Transform(object[] args);

    protected abstract void Execute(TransformVariable val);

    //
    // Make sure TransformStack always contains 2 or less entries:
    //
    // TransformStack[0] = Previous Transform
    // TransformStack[1] = Current Transform
    //
    protected void Save(TransformVariable val)
    {
        // 
        // TransformStack at this point would be:
        //
        // TransformStack[0] = Previous-Previous Transform
        // TransformStack[1] = Previous Transform
        //
        while (TransformStack.Count > 1)
        {
            TransformStack.Remove(TransformStack.ElementAt(0));
        }
        //
        // TransformStack at this point would be:
        // 
        // TransformStack[0] = Previous Transform
        //
        TransformStack.Add(val);
        // 
        // TransformStack at this point would be:
        //
        // TransformStack[0] = Previous Transform
        // TransformStack[1] = Current Transform
        //
    }

    public virtual void Revert()
    {
        if (TransformStack.Count == 0) return;

        while (TransformStack.Count > 1)
        {
            TransformStack.Remove(TransformStack.ElementAt(TransformStack.Count - 1));
        }
    }
}
