//Cowboy
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string facing;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        facing = "right";
        gameObject.GetComponent<Animator>().SetBool("Moving_up",false);
        gameObject.GetComponent<Animator>().SetBool("Moving_down",false);
        gameObject.GetComponent<Animator>().SetBool("Moving_right",false);
        gameObject.GetComponent<Animator>().SetBool("Moving_left",false);
    }

    // Update is called once per frame
    void Update(){
        MotionAnimation();
        Move();
    }
    private void MotionAnimation() {

        if(!Input.GetKey(facing) && gameObject.GetComponent<Animator>().GetBool("Moving_" + facing)){
                gameObject.GetComponent<Animator>().SetBool("Moving_" + facing,false);
        }

        if(Input.GetKey("left") && (facing != "left" || !gameObject.GetComponent<Animator>().GetBool("Moving_left") )){

            if(facing != "left"){
                gameObject.GetComponent<Animator>().SetBool("Moving_" + facing,false);
            }
            gameObject.GetComponent<Animator>().SetBool("Moving_left",true);
            facing = "left";

        }

        if(Input.GetKey("right") && (facing != "right" || !gameObject.GetComponent<Animator>().GetBool("Moving_right") )){

            if(facing != "right"){
                gameObject.GetComponent<Animator>().SetBool("Moving_" + facing,false);
            }
            gameObject.GetComponent<Animator>().SetBool("Moving_right",true);
            facing = "right";

        }

        if(Input.GetKey("up") && (facing != "up" || !gameObject.GetComponent<Animator>().GetBool("Moving_up") )){

            if(facing != "up"){
                gameObject.GetComponent<Animator>().SetBool("Moving_" + facing,false);
            }
            gameObject.GetComponent<Animator>().SetBool("Moving_up",true);
            facing = "up";

        }
        if(Input.GetKey("down") && (facing != "down" || !gameObject.GetComponent<Animator>().GetBool("Moving_down") )){

            if(facing != "down"){
                gameObject.GetComponent<Animator>().SetBool("Moving_" + facing,false);
            }
            gameObject.GetComponent<Animator>().SetBool("Moving_down",true);
            facing = "down";

        }
    }

    static Vector3 up = new Vector3(Convert.ToSingle(Math.Sqrt(0.75)),0.5f,0f);
    static Vector3 right = new Vector3(Convert.ToSingle(Math.Sqrt(0.75)),-0.5f,0f);
    static Vector3 left = new Vector3(-Convert.ToSingle(Math.Sqrt(0.75)),0.5f,0f);
    static Vector3 down = new Vector3(-Convert.ToSingle(Math.Sqrt(0.75)),-0.5f,0f);

    private void Move(){

        if(Input.GetKey("up")){
            gameObject.transform.position += up*speed;
        }
        if(Input.GetKey("down")){
            gameObject.transform.position += down*speed;
        }

        if(Input.GetKey("right")){
            gameObject.transform.position += right*speed;
        }

        if(Input.GetKey("left")){
            gameObject.transform.position += left*speed;
        }
    }
}
