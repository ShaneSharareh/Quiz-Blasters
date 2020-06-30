using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    public AudioSource gunNoise;
    public AudioSource hurt;
    float timer = 0;
    float moveTime = 0.1F;
    float speed = 0.25F;
    int numberOfMovements = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.resume)
        {
            if (numberOfMovements == 12)
            {
                transform.Translate(new Vector3(0, -.5f, 0));
                numberOfMovements = -1;
                numberOfMovements = 0;
                speed = -speed;
                timer = 0;

            }

            timer += Time.deltaTime;
            if (timer > moveTime && numberOfMovements < 12)
            {
                transform.Translate(new Vector3(speed, 0, 0));
                timer = 0;
                numberOfMovements++;
            }
            fireEnemyProjectile();


           
        }
    }

    void fireEnemyProjectile() {
        if (Random.Range(0f, 500F) < 1) {
            gunNoise.Play();
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.4f, 0), enemy.transform.rotation) as GameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerSpace")
        {
            GameManager.resetEnemies();
            GameManager.lives--;
            GameManager.resume = false;
            

        }
        if (collision.gameObject.tag == "bullet")
        {

            hurt.Play();

        }
    }
    }
