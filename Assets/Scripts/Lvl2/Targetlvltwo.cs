using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Targetlvltwo : MonoBehaviour
{ 
    private GameObject scoreText;
    private GameObject player;
    private GameObject scriptManager;
    private Vector3 xmin;
    private Vector3 xmax;
    private float thisTransform;
    private bool isGoingL;
    private bool isGoingR = false;
    private bool isGoingU;
    private bool isGoingD = false;
    private Vector3 ymin;
    private Vector3 ymax;
    
    private float speed = 0.2f;
    
    private float i = 0;

    private void Awake()
    {
        isGoingL = true;
        isGoingU = true;
        scoreText = GameObject.FindWithTag("ScoreUI");
        player = GameObject.FindWithTag("MainCamera");
        scriptManager = GameObject.FindWithTag("scriptManager");
        thisTransform = transform.position.x;
        xmin = new Vector3(-4f, 0, 0);
        xmax = new Vector3(4f, 0, 0);
        ymax = new Vector3(0,9f, 0);
        ymin = new Vector3(0, 1.5f, 0);
        i = Random.value;
    }
    
    private void FixedUpdate()
    {
        RandomDirection();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si ma cible rencontre la balle, elle recupere le score et ce detruit elle meme
        if (other.gameObject.GetComponent<BulletLVLtwo>() != null)
        {
            scoreText.GetComponent<Score>().score++;
            player.GetComponent<Player>().nbrMaxBullets--;
            scriptManager.GetComponent<SpawnTargets>().isTaked = true;
            Destroy(this.gameObject);
        }
        
    }

    private void MoveTargetsHorizontale()
    {
        if (this.transform.position.x > xmin.x && isGoingL== true)
        {
            Debug.Log("go left");
            this.transform.position = this.transform.position + new Vector3(- speed, 0, 0);
            if (this.transform.position.x <= xmin.x)
            {
                isGoingL = false;
                isGoingR = true;
            }
        } else if (this.transform.position.x < xmax.x && isGoingR == true)
        {
            Debug.Log("go right");
            this.transform.position = this.transform.position + new Vector3(speed, 0, 0);
            if (this.transform.position.x >= xmax.x)
            {
                isGoingL = true;
                isGoingR = false;
            }
        }
    }

    private void MoveTargetsVerticale()
    {
        if (this.transform.position.y < ymax.y && isGoingU== true)
        {
            Debug.Log("go up");
            this.transform.position = this.transform.position + new Vector3(0,  speed, 0);
            if (this.transform.position.y >= ymax.y)
            {
                isGoingU = false;
                isGoingD = true;
            }
        } else if (this.transform.position.y > ymin.y && isGoingD == true)
        {
            Debug.Log("go down");
            this.transform.position = this.transform.position + new Vector3(0, -speed, 0);
            if (this.transform.position.y <= ymin.y)
            {
                isGoingU = true;
                isGoingD = false;
            }
        }
    }

    private void RandomDirection()
    {
        //Debug.Log(i);

        if (i < 0.4f)
        {
            MoveTargetsHorizontale();
            Debug.Log("go horizontale");
        }
        else if (i > 0.4f && i < 0.8f)
        {
            MoveTargetsVerticale();
            Debug.Log("go verticale");

        }
        else
        {
            MoveTargetsHorizontale();
            MoveTargetsVerticale();
            Debug.Log("go both");
        }
        
    }


}
