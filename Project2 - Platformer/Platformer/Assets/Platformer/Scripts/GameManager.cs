using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject questionBricks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        // if the right mouse click is being pressed and will be on the '?' box or brick then we can break it and add point to the score
        if (Input.GetMouseButtonDown(0)) {
            // Debug.Log("Test button to smash the question box");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;

                //Debug.Log(bc.name);

                if (bc.name == "Question(Clone)")
                {
                    // then we know we are over a question brick and we should be able to destory it.
                    Destroy(bc.gameObject);


                }


            }

            
        }
    }
}
