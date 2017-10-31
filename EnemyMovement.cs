using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject player;
    public GameObject shot;


    private Vector2 pDistance;
    private Vector2 myDistance;
    private Vector2 startPos;
    private Rigidbody2D mobMove;
    private int moved = 0;
    private float start = 0;
    private float speed = 2f;
    private int direction = 1;

    public int coolDown;
    public float rangeX;
    public float rangeY;
    public bool close;


	void Start () {
        mobMove = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position;
	}
	
	
	void Update () {

        //movement
        if (transform.position.x > startPos.x + 2 || transform.position.x < startPos.x - 2)
            direction *= -1;

            mobMove.velocity = new Vector2(direction, 0) * speed;


        //shooting
        pDistance = player.transform.position;
        myDistance = transform.position;


        if (pDistance.x - myDistance.x >= -rangeX && pDistance.x - myDistance.x <= rangeX
            && pDistance.y - myDistance.y >= -rangeY && pDistance.y - myDistance.y <= rangeY)
        {
            close = true;
        }
        else
        {
            close = false;
        }

        if(close)
        {
            if (Time.time > start + coolDown)
            {
                start = Time.time;

                shot.transform.position = transform.position;
                Instantiate(shot);
                

            }

        }


	}
}
