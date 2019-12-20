using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    playerScript player_Instance;
    float x, y, z;
    [SerializeField]
    private float freq;
    [SerializeField]
    private float movementRange;
    public int initialPosition;
    private void Start()
    {
        player_Instance = FindObjectOfType<playerScript>();
    }
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        if (player_Instance.canMove == false)
        {
            z = Mathf.Sin(Time.time * freq) * movementRange; 
        }
        else
        {
            z = transform.position.z;
        }
        transform.position = new Vector3(x, y, z);
    }
}
