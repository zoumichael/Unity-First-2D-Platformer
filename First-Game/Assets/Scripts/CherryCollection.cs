using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryCollection : MonoBehaviour
{

    private int cherries = 0;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries; 
            Debug.Log("Cherries: " + cherries); 
        }
    }
    
}
