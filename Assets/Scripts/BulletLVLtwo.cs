using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLVLtwo : MonoBehaviour
{
    private float secondsToDestroy = 0;
    private GameObject player;
    

    private void Start()
    {
        player = GameObject.FindWithTag("MainCamera");

    }

    private void Update()
    {
        secondsToDestroy += Time.deltaTime;
        if (secondsToDestroy >= 2)
        {
            //detruit la balle apres 2 sec de durée de vie
            player.GetComponent<Player>().nbrActuelBulletPlaying--;
            
            Destroy(this.gameObject);
        }
    }
}
