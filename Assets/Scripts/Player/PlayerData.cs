using UnityEngine;

[CreateAssetMenu()]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public PlayerController PlayerController { get; private set; }
    
}
