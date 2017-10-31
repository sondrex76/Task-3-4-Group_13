using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
    private RaycastHit2D hit;
    
	void Start () {
       
	}
	
	
	void Update () {
       
        hit = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector2.up*10);

            if(hit.collider.tag == "Ground" && hit.distance < 1 && Input.GetKeyDown("space"))
            Debug.Log("Activate boots");
        
	}
}
