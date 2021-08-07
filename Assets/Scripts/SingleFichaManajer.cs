using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleFichaManajer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public string place;
    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = FichasManager.notSelectedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void selectFicha(){
        Debug.Log("DoSomething : " + this.name);
        spriteRenderer.sprite = selectedSprite;
    }

    public void deselectFicha(){
        spriteRenderer.sprite = notSelectedSprite;
    }
    public void destruir(){
        Destroy(gameObject);
    }
    public void GoToThisPlace(){
        Debug.Log("You are trying to go somewhere");
        SceneManager.LoadScene(place);
    }
}
