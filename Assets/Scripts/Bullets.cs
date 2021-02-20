using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    public Rigidbody2D rbBullet;

    public GameObject bulletEffects;
    private GameManager manager;


  
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rbBullet.velocity = transform.right*bulletSpeed;
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletEffects, transform.position, transform.rotation);
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
            //Destroy(GameObject.FindWithTag("Enemy"));
             //Health -= 10.0f;

            //Debug.Log(Health);

        //}
        Destroy(gameObject);

    }

    void OnBecameInvinsible ()
    {
        Destroy(gameObject);
    }

}
