using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField]
    Transform playerGhost;
    public int playerSpeed;
    public bool canMove;
    public bool canCamMove;
    public instantiator ghosts_instance;

    private void Start()
    {
        ghosts_instance = FindObjectOfType<instantiator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            canMove = true;
        }
        if (canMove == true) {
            MovetoDir(playerSpeed);
            if (Vector3.Distance(transform.position, playerGhost.position) <= 0.3f) {
                canMove = false;
                playerGhost.gameObject.SetActive(false);
                canCamMove = true;
                ghosts_instance.ActivatenextGhost();
            }
        }
            playerGhost = FindObjectOfType<ghost>().transform;
       
    }
 
    void MovetoDir(int speed)
    {
        speed = playerSpeed;
        Vector3 dir = playerGhost.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * Time.deltaTime * speed);
    }
   
}
