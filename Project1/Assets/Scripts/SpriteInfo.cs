using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public Vector2 position
    {
        get { return new Vector2(transform.position.x, transform.position.y); }
    }

    [SerializeField]
    Vector2 rectSize = Vector2.one;

    // Properties for Min and Max
    public Vector2 RectMin
    {
        get { return new Vector2(position.x - (rectSize.x / 2), position.y - (rectSize.y / 2)); }
    }
    public Vector2 RectMax
    {
        get { return new Vector2(position.x + (rectSize.x / 2), position.y + (rectSize.y / 2)); }
    }

    bool isColliding = false;

    public bool IsColliding
    {
        set { isColliding = value; }
    }

    [SerializeField]
    SpriteRenderer render;

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            render.color = Color.white;
        }
        else
        {
            render.color = Color.white;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(position, rectSize);
    }
}
