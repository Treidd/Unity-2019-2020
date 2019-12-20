using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiator : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    int cont;
    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++) {
            points[i] = transform.GetChild(i);
        }
        ActivatenextGhost();
    }
    public void ActivatenextGhost() {
        
        points[cont].gameObject.SetActive(true);
        cont++;
    }
    private void Update()
    {
       
    }



}
