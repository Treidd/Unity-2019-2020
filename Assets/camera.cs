using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;
    private playerScript instancetusabe;
    private void Start()
    {
        instancetusabe = FindObjectOfType<playerScript>();
    }
    private void LateUpdate()
    {
        if (instancetusabe.canCamMove == true)
        {
            // Vector3 tempCamera = new Vector3(Camera.main.transform.position.x, 7.809785f, 0.6340883f);
            //Vector3 cameraDir = player.position - tempCamera;
            if (transform.position.x <= (player.position.x - 3))
            {
                transform.position += Vector3.right * Time.deltaTime * 15;
            }
            else
            {
                instancetusabe.canCamMove = false;
            }
           

           // transform.Translate(cameraDir * Time.deltaTime);
        }
    }
}
