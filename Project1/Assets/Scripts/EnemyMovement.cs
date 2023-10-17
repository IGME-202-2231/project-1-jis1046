using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 objectPosition = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;

    //[SerializeField]
    Vector3 direction;
    Vector3 velocity = Vector3.zero;

    // Screen boundaries
    float screenWidth;
    float screenHeight;

    void Awake()
    {
        direction = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));

    }
    // Start is called before the first frame update
    void Start()
    {
        Awake();
        objectPosition = transform.position;

        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        objectPosition += velocity;

        if (IsOffScreen())
        {
            WrapAroundScreen();
        }

        //Check for OB

        transform.position = objectPosition;
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (newDirection != null)
        {
            direction = newDirection.normalized;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
            }
        }
    }

    bool IsOffScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return screenPosition.x < 0 || screenPosition.x > screenWidth || screenPosition.y < 0 || screenPosition.y > screenHeight;
    }

    void WrapAroundScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0)
        {
            objectPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x;
        }

        else if (screenPosition.x > screenWidth)
        {
            objectPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        }

        if (screenPosition.y < 0)
        {
            objectPosition.y = Camera.main.ScreenToWorldPoint(new Vector3(0, screenHeight, 0)).y;
        }
        else if (screenPosition.y > screenHeight)
        {
            objectPosition.y = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        }

    }
}
