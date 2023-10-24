using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    public List<SpriteInfo> collidable = new List<SpriteInfo>();

   /* [SerializeField]
    SpriteRenderer enemyPrefab;*/

    //List<SpriteInfo> spawnEnemies = new List<SpriteInfo>();

    [SerializeField]
   // public SpawnManager spawnEnemy;

    public SpriteRenderer enemyRenderer;

    public int playerHealth = 100;
    public int score = 0;

    public Text healthText;
    public Text scoreText;
    public Text gameOverText;

    void UpdateUI()
    {
        // Update the UI Text elements with the current health and score
        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    void Awake()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SpawnManager.Instance.Spawn();
        enemyRenderer = SpawnManager.Instance.spawnedEnemyRenderer;

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
                SpriteInfo spaceSprite = collidable[i];
                Destroy(collidable[i].gameObject);
                collidable.RemoveAt(i);
                playerHealth--;
                score += 5;

                if(playerHealth <= 0)
                {
                    
                }
                
               // collidable.Add(enemyRenderer.GetComponent<SpriteInfo>());
                //collidable[i] = Instantiate(enemyRenderer.GetComponent<SpriteInfo>());

                //Destroy(collidable[i].gameObject);
            }

            collidable[0].IsColliding = spaceshipCollieded;
         
        }

        UpdateUI();
        gameOver();
    }

    void gameOver()
    {
      if (collidable.Count < 1) 
        {
            scoreText.text = "Game Over";
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
