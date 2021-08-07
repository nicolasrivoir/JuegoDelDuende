using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    bool selected;
    public GameObject camara;
    public GameObject scripter;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start...");
        selected = false;
    }

    private bool estadoActual;
    private GameObject selectedFicha;

    // Update is called once per frame
    void Update()
    {
        if(scripter.GetComponent<MapController>().GetMapSelected() != estadoActual){
            estadoActual = !estadoActual;
            foreach(Transform child in transform){
                child.gameObject.SetActive(estadoActual);
            }
        }

        transform.position = camara.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if(hit.collider != null && hit.collider.tag == "Boton"){
            // Debug.Log("Something Detected");
            // Debug.Log(hit.collider.tag);
            hit.collider.GetComponent<SingleFichaManajer>().selectFicha();
            selectedFicha = hit.collider.gameObject;
        }
        else{// if(!selected){
            // Debug.Log("Nothing Detected");
            if(selectedFicha != null){
                selectedFicha.GetComponent<SingleFichaManajer>().deselectFicha();
                selectedFicha = null;
            }
        }

        if(Input.GetMouseButtonDown(0) && selectedFicha != null){
            selectedFicha.GetComponent<SingleFichaManajer>().GoToThisPlace();
            // SceneManager.LoadScene("Bosque");
        }
    }
}
