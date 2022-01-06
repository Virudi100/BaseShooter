using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si ma cible rencontre la balle, elle recupere le score et ce detruit elle meme
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            scoreText.GetComponent<Score>().score++;
            player.GetComponent<Player>().nbrMaxBullets--;
            Destroy(this.gameObject);
        }
        
    }
}
