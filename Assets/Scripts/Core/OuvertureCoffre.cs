
using UnityEngine;
using UnityEngine.UI;

public class OuvertureCoffre : MonoBehaviour
{
    [SerializeField] private GameObject interactUI;
    private bool isInRange = false;
     private bool hasBeenOpened = false;  // Pour suivre si le coffre a été ouvert
    public Animator animator;
    [SerializeField] private  GameObject itemToAdd;
    void Awake()
    {
        interactUI.SetActive(false);  
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.E)&& isInRange && !hasBeenOpened)  
      {
        Debug.Log("appuie sur E");
        OpenChest();

      } else if (isInRange && !hasBeenOpened) 
        {
        interactUI.SetActive(true);
      }

      else
        {
            interactUI.SetActive(false);
        }
            
        
    }
    void OpenChest()
    {
        animator.SetTrigger("open_chest");
        // Instancie l'item à la position du coffre
            Instantiate(itemToAdd, transform.position, Quaternion.identity); 
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //interactUI.enabled = true;
            isInRange = true;
            Debug.Log("enter");
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //interactUI.enabled = false;
            isInRange = false;
            Debug.Log("exit");
        }  
    }

}

