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
        //Debug.Log(collider.name);// the key
        if (collider.tag == "Key") // if the key is collided, collider.CompareTag("Key"), key != null
        {
            Key key = collider.GetComponent<Key>();
            Addkey(key.GetKeyType());
            //Debug.Log("added");
            Destroy(key.gameObject);
            //Debug.Log("collided");
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(collider.tag == "Door") // keyDoor != null, collider.tag == "Door"
        {
           if(ContainsKey(keyDoor.GetKeyType()))
           {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
           }
        }
            

    }

}
