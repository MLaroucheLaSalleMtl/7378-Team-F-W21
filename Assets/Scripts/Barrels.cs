using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    public GameObject brokenBarrel;
    public bool lootbox;
    public float dropChance = 0f;
    public GameObject items;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" || collision.tag=="PlayerBullets")
        {
            Destroy(gameObject);
            Instantiate(brokenBarrel, transform.position, transform.rotation);
        }

        if (lootbox)
        {
            float dropChanceRandom = Random.Range(0f,1f);
            if (dropChanceRandom > dropChance)
            {
                Instantiate(items, transform.position, transform.rotation);
            }
        }
    }
}
