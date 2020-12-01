using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

  
public class Patrol : MonoBehaviour
{

 public float moveSpeed = 2.0f;  // Units per second
 public List<GameObject> patrolList = new List<GameObject>();
 private GameObject nextTarget = null;
 private int current = 0;

    // Start is called before the first frame update
    void Start() {
		SetNextPoint() ;
	}
  
	 void Update () {
		 move();
	 }

	void move () {
		if (nextTarget == null)
			return;
        transform.position = Vector3.MoveTowards (transform.position, nextTarget.transform.position, 3.0f * Time.deltaTime);
		if (Vector3.Distance (transform.position, nextTarget.transform.position) <= 0.1f)
			SetNextPoint();
	}

	void SetNextPoint() {
		if (current >= patrolList.Count())
		current = 0;

		nextTarget = patrolList[current++];
	}

	// test only
	void moveToCursor() {
	     if (Input.GetMouseButton(0)) {
	         Vector3 pos = Input.mousePosition;
	         pos.z = transform.position.z - Camera.main.transform.position.z;
	         pos = Camera.main.ScreenToWorldPoint(pos);
	         transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);
	     }
	}

	 public void updatePatrolList(List<GameObject> patrolList){
		 this.patrolList = patrolList;
		SetNextPoint();
	 }
}