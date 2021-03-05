using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldKey : MonoBehaviour
{

    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void Addkey(Key.KeyType keyType) // add key to holder
    {
        Debug.Log("Added key:" + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType) // remove key
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType) // check if contain the key
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider) // check collider
    {
        Key key = collider.GetComponent<Key>(); // the key
        if (key!= null) // if t5he key is collided
        {
            Addkey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
           if(ContainsKey(keyDoor.GetKeyType()))
           {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
           }
        }
            

    }

}
