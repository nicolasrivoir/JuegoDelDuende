using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public bool mapSelected;
    public GameObject mapa;
    float timer;
    public float waiting_time;
    // Start is called before the first frame update
    void Start()
    {
        mapSelected = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKey("m") && timer > waiting_time){
            timer = 0;
            mapSelected =  !mapSelected;
            mapa.SetActive(mapSelected);
        }
    }

    public bool GetMapSelected(){
        return mapSelected;
    }
}
