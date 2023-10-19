using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    [SerializeField]
    SpriteRenderer enemyPrefab;

    [SerializeField]
    public SpriteInfo spirte;

    List<SpriteRenderer> spawnEnemies = new List<SpriteRenderer>();

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
        for (int i = 0; i < 2; i++)
        {
            spawnEnemies.Add(SpawnCreature());

            Vector2 spawnPosition;

            spawnPosition.x = 0;
            spawnPosition.y = Random.Range(-5, 5);

            SpawnCreature().transform.position = spawnPosition;

            spawnEnemies[i].GetComponent<SpriteInfo>();
        }
    }
}
