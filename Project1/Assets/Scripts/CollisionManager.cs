using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<SpriteInfo> collidable = new List<SpriteInfo>();

    [SerializeField]
    SpriteRenderer enemyPrefab;

    //List<SpriteInfo> spawnEnemies = new List<SpriteInfo>();

    [SerializeField]
    public SpawnManager spawnEnemy;

    public SpriteRenderer enemyRenderer;

    void Awake()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spawnEnemy.Spawn();

    }


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
                collidable.Add(collidable[i]);
                DestroyImmediate(collidable[i].gameObject,true);
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
    
    /*
    public SpriteRenderer SpawnCreature()
    {
        return Instantiate(enemyPrefab);
    }

    public void Spawn()
    {
        for (int i = 0; i < 1; i++)
        {
            spawnEnemies.Add(SpawnCreature());

            Vector2 spawnPosition;

            spawnPosition.x = 0;
            spawnPosition.y = Random.Range(-5, 5);

            SpawnCreature().transform.position = spawnPosition;
        }
    } */
}
