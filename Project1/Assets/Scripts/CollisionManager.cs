using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collidable = new List<SpriteInfo>();

    // Update is called once per frame
    void Update()
    {
        bool spaceshipCollieded = false;

        for (int i = 1; i < collidable.Count; i++)
        {

            bool isColliding = AABBCheck(collidable[0], collidable[i]);

            collidable[0].IsColliding = isColliding;
            collidable[i].IsColliding = isColliding;

            if (isColliding == true)
            {
                spaceshipCollieded = true;
            }

            collidable[0].IsColliding = spaceshipCollieded;

        }
    }

    bool AABBCheck(SpriteInfo spriteA, SpriteInfo spriteB)
    {
        // Check for collision
        if(spriteB.RectMin.x < spriteA.RectMax.x &&
            spriteB.RectMax.x > spriteA.RectMin.x &&
            spriteB.RectMax.y > spriteA.RectMin.y &&
            spriteB.RectMin.y < spriteA.RectMax.y)
        {
            return true;
        }

        return false;
    }
}
