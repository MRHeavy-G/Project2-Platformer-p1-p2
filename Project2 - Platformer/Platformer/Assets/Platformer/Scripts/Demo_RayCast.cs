using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_RayCast : MonoBehaviour
{

    public float proximityThreshold = 5f;
    public GameObject questBrick;
    

    // Start is called before the first frame update
    void Start()
    {




        StartCoroutine(UpdatePickingRaycast());
    }

    IEnumerator UpdatePickingRaycast() {

        while (true) {

            //Debug.Log($"current frame number { Time.frameCount}");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out RaycastHit hitInfo)) {

                Debug.DrawLine(hitInfo.point + Vector3.left *1, hitInfo.point + Vector3.right * 1, Color.magenta);
                Debug.DrawLine(hitInfo.point + Vector3.up * 1, hitInfo.point + Vector3.down * 1, Color.magenta);

            }

            yield return null;


        }

    }

    // Update is called once per frame
    void Update()
    {
        // this will be due to the direction of the object being hit
        Ray ray = new Ray(transform.position, Vector3.down);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo)) {
           // Debug.Log("Hit Object with mouse");
        }



    }

    public void onMousePressed() {

        if (Input.GetMouseButtonDown(0)) {
            //Destroy(questBrick);
            //Debug.Log("?");
        }
    }
}
