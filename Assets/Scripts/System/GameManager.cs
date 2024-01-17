using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() => Instance = this;

    [SerializeField] private UnityEvent OnInit = new UnityEvent();

    private void Start()
    {
        OnInit.Invoke();
    }

}
