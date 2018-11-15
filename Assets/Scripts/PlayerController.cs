using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;

    public Animator animatorChepe;

    public SpriteRenderer spriteChepe;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if( Physics.Raycast(ray, out hit) )
            {
                // Move our Agent
                agent.SetDestination(hit.point);

                animatorChepe.SetBool("ChepeIsMoving", true);

                if( hit.point.x > this.transform.position.x ){
                    spriteChepe.flipX = false;
                }else{
                    spriteChepe.flipX = true;
                }

                //Debug.Log(Input.mousePosition.x);
                Debug.Log(hit.point.x);
            }
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    animatorChepe.SetBool("ChepeIsMoving", false);
                }
            }
        }

    }
}
