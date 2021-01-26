using UnityEngine;
using System.Collections;
//fonction qui retire le YZ d'un vecteur
static public class VectorExtensions
{
    static public Vector3 Y(this Vector3 vec)
    {
        return new Vector3(vec.x, 0, 0);
    }
}
public class EnnemiPatrol : MonoBehaviour
{
    public int enemyHealth = 100;
    public int random;
    public int damageOnCollision = 10;

    public float speed;
    public float playerDamagedTimer = 1.5f;
    public float lookRadius = 10f;
    public float lookRadius2 = 2f;

    public bool damagedPlayer = false;
    
    private int destPoint = 0;
    
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    private Transform target;
    Transform cible;

    void Start()
    {
        target = waypoints[0];
        cible = PlayerManager.instance.player.transform;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius2);
    }

    void FixedUpdate()
    {
        float gap = Vector3.Distance(cible.position, transform.position);

        //l'ennemi avance vers le joueur si il est a proximité
        if (gap <= lookRadius /*& gap > lookRadius2*/) 
        {
            Vector3 dir = cible.position.Y() - transform.position.Y();
            transform.Translate(dir.normalized * 5 * Time.deltaTime, Space.World);
        }
        //fixer aux fps , a mettre dans une fonction a part et peut etre dans un fonction collider au lieu de update
        //attaque de l'ennemi
        if (gap <= lookRadius2)
        {
            random = Random.Range(1, 10);
        }
        if (gap <= lookRadius2 & random == 1)
        {
            Vector3 dur = cible.position.Y() - transform.position.Y();
            transform.Translate(dur.normalized * speed * Time.deltaTime, Space.World);
        }
        //l'ennemi recule si il est trop près du joueur 
        if (gap <= lookRadius2 && damagedPlayer)
        {
            Vector3 dar = transform.position.Y() - cible.position.Y();
            transform.Translate(dar.normalized * speed * Time.deltaTime, Space.World);
        }        
        //allez retour de l'ennemi entre les waypoints
        else
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
                graphics.flipX = !graphics.flipX;
            }
        }
    }

    //degats de l'ennemi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        if (collision.transform.CompareTag("Player"))
        {            
            playerHealth.TakeDamage(damageOnCollision);
            damagedPlayer = true;
        }
    }
    public IEnumerator PlayerDamagedTimer()
    {
        yield return new WaitForSeconds(playerDamagedTimer);
        damagedPlayer = false;
    }
}
