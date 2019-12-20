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
    private bool isAlive;
    public instantiator ghosts_instance;
    private camera camera_instance;
    private GameMaster master_Instance;
    public GameObject elPanel;
    private void Start()
    {
        ghosts_instance = FindObjectOfType<instantiator>();
        camera_instance = FindObjectOfType<camera>();
        master_Instance = FindObjectOfType<GameMaster>();
        isAlive = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            canMove = true;
        }
        if (canMove == true && isAlive != false) {
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "block") {
            isAlive = false;
            elPanel.SetActive(true);
            camera_instance.playerSaMatao = true;
            master_Instance.PlayAudio();
            StartCoroutine(master_Instance.ResetScene(0, 2));
        }
    }
    
}
