using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryCollection : MonoBehaviour
{

    private int cherries = 0;
    private int pineapples = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            collectSound.Play();

            if(collision.gameObject.name.Contains("Cherry")){
                cherries++;
                UpdateText();
                Debug.Log("Cherry Plus 1"); 
            }
            else if(collision.gameObject.name.Contains("Pineapple")){
                pineapples++;
                UpdateText();
            }   
            Destroy(collision.gameObject);
        }
    }

    private void UpdateText()
    {
        if(cherries > 0 && pineapples > 0)
        {
            cherriesText.text = "Cherries: " + cherries + "\nPineapples: " + pineapples ;  
        }
        else if(pineapples > 0)
        {
            cherriesText.text = "Pineapples: " + pineapples;
        } 
        else
        {
            cherriesText.text = "Cherries: " + cherries;
        }
    }
    
}
