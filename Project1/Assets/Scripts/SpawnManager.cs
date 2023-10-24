using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    [SerializeField]
    SpriteRenderer enemyPrefab;

    //Hold and carry the enemy sprite reference
    public SpriteRenderer spawnedEnemyRenderer;

    List<SpriteRenderer> spawnEnemies = new List<SpriteRenderer>();

    [SerializeField]
    CollisionManager collisionManager;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public SpriteRenderer SpawnCreature()
    {
        return Instantiate(enemyPrefab);
    }

    public void Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            //spawnEnemies.Add(SpawnCreature());
            SpriteRenderer enemy = SpawnCreature();

            Vector2 spawnPosition;

            spawnPosition.x = 0;
            spawnPosition.y = Random.Range(-5, 5);

            enemy.transform.position = spawnPosition;

            collisionManager.collidable.Add(enemy.GetComponent<SpriteInfo>());
            spawnEnemies.Add(enemy);

            spawnedEnemyRenderer = enemy;
        }
    }
}
