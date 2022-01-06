using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public int nbrTarget;
    [SerializeField] private GameObject canvasWin;
    private int nbrBallesRestantes;
    private GameObject player;
    [SerializeField] private Text UIRemainingBullets;
    public int maxBulletWanted = 5;
    
    void Start()
    {
        ResumeGame();
        canvasWin.SetActive(false);
        player = GameObject.FindWithTag("MainCamera");
        
    }

    private void FixedUpdate()
    {
        //recupere le nbr de balle dans le script du joueur pour l'utilisé pour l'afficher dans les textes
        nbrBallesRestantes = player.GetComponent<Player>().nbrMaxBullets;
        nbrBallesRestantes = maxBulletWanted - nbrBallesRestantes;
        
        this.gameObject.GetComponent<Text>().text = ("Score: "+score+" / "+nbrTarget);
        UIRemainingBullets.text = ("Balles restantes: " + nbrBallesRestantes);
        
        if (score == nbrTarget)
        {
            //si le score est egale au nbr de cibles initial on gagné
            canvasWin.SetActive(true);
            PauseGame();
        }
    }
    
    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
