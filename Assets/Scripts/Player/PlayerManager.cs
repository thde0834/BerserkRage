using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    private void Awake() => Instance = this;

    private static PlayerData playerData;

    public static async UniTask LoadPlayerData()
    {
        // Access Player Database and get active Player Data

    }



}

public class PlayerDatabase
{
    public PlayerData PlayerData;
    public bool isActive;
    public bool isUnlocked;
}