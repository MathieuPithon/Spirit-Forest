using UnityEngine;
using UnityEngine.AI;
public class snakepatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    public float lookRadius =10f;

    Transform cible;

    // Start is called before the first frame update
    void Start()
    {
        cible = PlayerManager.instance.player.transform;
        target = waypoints[0];
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    // Update is called once per frame
    void Update()
    {
        float vision = Vector3.Distance(cible.position, transform.position);

        if (vision <= lookRadius)
        {
            Vector3 dir = cible.position - transform.position;
            transform.Translate(dir.normalized * 5 * Time.deltaTime, Space.World);
        }
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
}
