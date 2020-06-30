using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public AudioSource audioSource;
    Vector3 respawn = new Vector3(0.05F, -4.12F, 0F);
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
            audioSource.Play();
            collision.gameObject.transform.position =respawn;
            GameManager.resetEnemies();
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
