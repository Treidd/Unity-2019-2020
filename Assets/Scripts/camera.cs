using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;
    private playerScript instancetusabe;
    [SerializeField]
    private Vector3 offset = new Vector3(-3f, 7.809785f, 0);
    public bool playerSaMatao;
    private void Start()
    {
        instancetusabe = FindObjectOfType<playerScript>();
    }
    private void LateUpdate()
    {
        if (instancetusabe.canCamMove == true)
        {
            if (transform.position.x < (player.position.x - 3))
            {
                Vector3 cameraDir = player.position - transform.position + offset;
                cameraDir.Normalize();
                transform.position += cameraDir * Time.deltaTime * 30;
            }
            else {
                instancetusabe.canCamMove = false;
            }
        }
       
    }
    private void Update()
    {
        //transform.position = new Vector3(transform.position.z,Mathf.Sin(Time.time),transform.position.z);
        if (playerSaMatao != false) {
            FocusPlayer();
        }
    }
    public void FocusPlayer() {
        Vector3 direction2 = player.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction2);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1 * Time.deltaTime);
        GetComponent<Camera>().fieldOfView -= 0.2f;
    }
}
