using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 respawn = new Vector3(-1.33F, -2.555F, 0);
    public GameObject enemyBullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position =respawn;
            Destroy(enemyBullet);
            GameManager.lives--;
            GameManager.resume = false;

        }

        if (collision.gameObject.tag == "bounds")
        {
            Destroy(enemyBullet);

        }
    }
}
