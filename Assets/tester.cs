using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{

	public GameObject kulka;
    private Patrol patrol;
    public bool isPatrol = false;
    public GameObject[] patrolPoints;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            togglePatrol();
            UpdatePatrolList();
        }
    }

    void UpdatePatrolList () {
        kulka.GetComponent<Patrol>().updatePatrolList(new List<GameObject>(patrolPoints));
    }

    void togglePatrol(){
        kulka.GetComponent<Patrol>().enabled = !kulka.GetComponent<Patrol>().enabled;
    }
}
