using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public float speed;
    private Vector3 bulletDir;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bulletDir = CharacterMove.instance.transform.position - transform.position;
        bulletDir.Normalize();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.instance.HurtPlayer(10);
        }
        Destroy(gameObject);
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}