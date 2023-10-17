using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    [SerializeField]
    GameObject laserBullet;

    [SerializeField]
    float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject laser = Instantiate(laserBullet, transform.position, Quaternion.identity);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // Apply velocity to the bullet in the specified direction
        laser.transform.Translate(direction * speed * Time.deltaTime);

    }
}
