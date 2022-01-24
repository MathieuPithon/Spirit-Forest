using UnityEngine;

/**
    Classe implémentant des murs "cassables", pouvant cacher des zones secrètes ou autres. 
    Les murs se cassent lorsque le personnage les touches. 
**/
public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    private void OnTriggerEnter2D (Collider2D collision)
    {   
        //Le personnage touche le mur ce qui entraîne à la destruction de l'obstacle
        if(collision.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }
}
