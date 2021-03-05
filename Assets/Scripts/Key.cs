using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
        Yellow,
        Green,
        Blue
    }

    public KeyType GetKeyType() //key color
    {
        return keyType;
    }
}