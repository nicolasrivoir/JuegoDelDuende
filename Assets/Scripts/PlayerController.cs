//Cowboy
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string facing;
    public float speed;
    private Rigidbody2D rbody;
    public GameObject scripter;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        facing = "right";
        gameObject.GetComponent<Animator>().SetBool("Moving_up",false);
        gameObject.GetComponent<Animator>().SetBool("Moving_down",false);
        gameObject.GetComponent<Animator>().SetBool("Moving_right",false);
        gameObject.GetComponent<Animator>().SetBool("Moving_left",false);
    }
/*
    void FixedUpdate(){
        Debug.Log("Tratando de Mover al sujeto");
        rbody.MovePosition(rbody.position + Vector2.up * Time.fixedDeltaTime);
    }
*/
    // Update is called once per frame
    void Update(){
        //Debug.Log(codeKey());
        if(!scripter.GetComponent<MapController>().GetMapSelected()){
            MotionAnimation();
            Move2();
        }
        //transform.Translate(Vector3.up);
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

    private void Move2(){

        int codeK = codeKey();
        Vector2 inputVector;

        int a1 = codeK >> 3;
        int a2 = (codeK >> 2) & 1;
        int b1 = (codeK >> 1) & 1;
        int b2 = codeK & 1;

        float running = 1f;
        if(Input.GetKey("space")){
            running += 1f;
        }
        if(Math.Abs((a1 - a2)*(b1 - b2)) == 1){
            inputVector = isometricVector(a1 - a2, b1 - b2)*speed*running*Convert.ToSingle(Math.Sqrt(0.5));
        }else{
            inputVector = isometricVector(a1 - a2, b1 - b2)*speed*running;
        }

        rbody.MovePosition(rbody.position + inputVector*Time.deltaTime);
        //rbody.AddForce(inputVector*Time.deltaTime);
    }

    private int codeKey(){

        int res = 0;

        if(Input.GetKey("up")){
            res += 8;
        }

        if(Input.GetKey("down")){
            res += 4;
        }

        if(Input.GetKey("right")){
            res += 2;
        }

        if(Input.GetKey("left")){
            res += 1;
        }

        return res;

    }

    private Vector3 isometricVector(float x, float y){
        return up*x + right*y;
    }
}
