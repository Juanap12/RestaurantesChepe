using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClienteController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;

    public Animator animatorChepe;

    public SpriteRenderer spriteChepe;

    // fila, carta, comiendo, ...
    private string estado;

    private bool selected;

    // Use this for initialization
    void Start()
    {
        estado = "fila";
        selected = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selected == true)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Move our Agent
                    agent.SetDestination(hit.point);

                    //animatorChepe.SetBool("ChepeIsMoving", true);

                    if (hit.point.x > this.transform.position.x)
                    {
                        spriteChepe.flipX = false;
                    }
                    else
                    {
                        spriteChepe.flipX = true;
                    }

                    //Debug.Log(Input.mousePosition.x);
                    Debug.Log(hit.point.x);
                }
            }
            
        }
        

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    //animatorChepe.SetBool("ChepeIsMoving", false);
                    selected = false;
                }
            }
        }

    }

    private void OnMouseDown()
    {
        if (estado.Equals("fila"))
        {
            selected = true;
        }
    }
}
