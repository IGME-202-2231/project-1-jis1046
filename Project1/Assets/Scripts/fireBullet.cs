using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    [SerializeField]
    GameObject laserBullet;

    [SerializeField]
    float speed = 5f;



    float nextShot = 0.15f;
    float fireDelay = 0.5f;

    MovementController shipDirection;


    float forceAmount = 10.0f;

    // Screen boundaries
    float screenWidth;
    float screenHeight;

   /* void Start()
    {
        Invoke("Fire", 30f);
    } */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextShot)
        {
            Fire();
            
        }
    }


    public void Fire()
    {
        GameObject laser = Instantiate(laserBullet, transform.position, Quaternion.identity);

        Vector2 objectPosition = laser.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
       


        // Apply velocity to the bullet in the specified direction

        Vector2 velocity = direction * speed * Time.deltaTime;

        objectPosition += velocity;

        laser.transform.Translate(velocity);

        laser.transform.position = objectPosition;
        

        nextShot = Time.time + fireDelay;




    }

}
