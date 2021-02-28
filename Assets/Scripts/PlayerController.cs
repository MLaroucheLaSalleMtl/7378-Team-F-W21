using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullets;
    public Transform shootingPoint;
    [SerializeField] private AudioSource audioShoot;
    public bool Paused;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Paused ==false)
        {
            Shooting();
        }
            
            
        
            
        
        //Shooting();
    }


    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullets, shootingPoint.position, shootingPoint.rotation);

           if (audioShoot) audioShoot.PlayOneShot(audioShoot.clip);
        }
    }
}