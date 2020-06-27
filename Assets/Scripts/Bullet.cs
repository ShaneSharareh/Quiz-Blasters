﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
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
                GameManager.questionCounter++;
                resetEnemies();
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

    void resetEnemies() {
        GameObject.Find("Enemy1").transform.position = (new Vector3(-2.919728F, 2.02681F, 164.5656F));
        GameObject.Find("Enemy2").transform.position = (new Vector3(0.01F, 1.91F, 164.5656F));
        GameObject.Find("Enemy3").transform.position = (new Vector3(2.38F, 2.06681F, 164.5656F));
        GameObject.Find("Enemy4").transform.position = (new Vector3(-6.66F, 0.21F, 164.5656F));
        GameObject.Find("Enemy5").transform.position = (new Vector3(0.18F, -0.78F, 164.5656F));
        GameObject.Find("Enemy6").transform.position = (new Vector3(6.08F, 0.06F, 164.5656F));




    }
}
