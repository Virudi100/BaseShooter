using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefabs;
    [SerializeField] private GameObject _bulletFired;
    public int nbrMaxBullets = 0;
    public int nbrActuelBulletPlaying;
    [SerializeField] private GameObject canvasLose;
    [SerializeField] private GameObject scoreUI;
    private int maxBulletWanted;
    

    private void Start()
    {
        ResumeGame();
        canvasLose.SetActive(false);
        maxBulletWanted = scoreUI.GetComponent<Score>().maxBulletWanted;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Au clic gauche creer une balles par rapport a la position de la souris sur l'ecran
            //gère également le nbr de balles maximum ainsi que le nbr de balles en cours de jeu
            Vector3 pointTargetPosition = Aim();
            if (pointTargetPosition != Vector3.zero && nbrMaxBullets < maxBulletWanted)
            {
                _bulletFired = Instantiate(_bulletPrefabs, transform.position, transform.rotation);
                nbrMaxBullets++;
                nbrActuelBulletPlaying++;
                _bulletFired.transform.LookAt(pointTargetPosition);
                _bulletFired.GetComponent<Rigidbody>().AddForce(_bulletFired.transform.forward*1000f);
            }
        }

        if (nbrMaxBullets >= maxBulletWanted && nbrActuelBulletPlaying <= 0)
        {
            //si le nbr de balles est atteinte et que il n'y a plus de balles en jeu on perd
            canvasLose.SetActive(true);
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


    private Vector3 Aim()
    {
        //recupere la position de la souris en vecteur 3 pour généré un raycast qui vas permettre de retourné la position
        //pour la balle
        RaycastHit hit;
        Vector2 mousePosiiton = Input.mousePosition;

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(mousePosiiton.x,mousePosiiton.y,Camera.main.nearClipPlane));
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePosiiton.x,mousePosiiton.y,Camera.main.nearClipPlane));
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
