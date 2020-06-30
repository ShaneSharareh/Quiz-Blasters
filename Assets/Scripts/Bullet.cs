using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public AudioSource audioSource;
    public Text text;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -3 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == GameManager.correctAnswer) {
                audioSource.Play();
                GameManager.questionCounter++;
                GameManager.resetEnemies();
              
                 //collision.gameObject.transform.position = respawn;

                //Destroy(collision.gameObject.transform.parent.gameObject);
                Destroy(bullet);
            };

           // Destroy(collision.gameObject);
           // Destroy(bullet);
        }
        if (collision.gameObject.tag == "bounds") {
            Destroy(bullet);

        }
    }

    
}
