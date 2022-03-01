using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character_Controller : MonoBehaviour
{

    private Rigidbody body;

    public float runForce = 25f;

    public float maxRunSpeed = 6f;

    public float jumpForce = 15f;
    public float jumpB = 2f;

    public bool feetOG;

    private Collider collider;

    // this variable will be for the turbo and will only have 5 times to use
    public float turboBoost = 50f;
    public float turboACtions = 0f;
    public bool turboCheck;

    // animations
    private Animator animComp;

    // score and coins

    public float coinCounter = 0;
    public float scoreCounter = 0;

    public TMP_Text coinT;
    public TMP_Text scoreT;


    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        

        float castD = collider.bounds.extents.y + 0.1f;

        feetOG = Physics.Raycast(transform.position, Vector3.down, castD);


        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce ,ForceMode.Force);

        //jump 
        if (feetOG && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (body.velocity.y > 0f && Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up* jumpB, ForceMode.Force);
        }

        // if the player used shift then he gets a boost to the right 
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && turboACtions < 5)
        {
            turboCheck = true;

            // the force added to movement
            body.AddForce(Vector3.right *axis * turboBoost, ForceMode.Impulse);

            // counter for the times the player can use the trubo
            turboACtions++;
        }
       

        //  keeps the character from going all over the world
        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        if (axis < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        // this will be to make sure that marrio  has collided with the question box
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.up);

        if (Physics.Raycast(ray, out hit))
        {
            BoxCollider bc = hit.collider as BoxCollider;

            

            if (bc.name == "Question(Clone)")
            {
                // then we know we are over a question brick and we should be able to destory it.
                Destroy(bc.gameObject);
                coinCounter = coinCounter + 1;
                scoreCounter = scoreCounter +  100;


            }
        }


        //---------------------

        DisplayScore(scoreCounter);
        DisplayCoin(coinCounter);

        //-------------

        animComp.SetFloat("Speed", body.velocity.magnitude);




        // if we reach the pollPrefabs then we can finish the game
        RaycastHit hitPC;
        Ray rayPC = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(rayPC, out hitPC))
        {
            BoxCollider pc = hitPC.collider as BoxCollider;



            if (collider.name == "Poll(Clone)")
            {
                // For simpliticay i will log out a text and then close the game
                Debug.Log("End of the game!!!!!!!!!!!!!");
                Application.Quit();
            }

        }
        
        
    }


    // call the coin counter
    void DisplayScore(float scoreTD)
    {


        scoreT.text = string.Format("{000000}", scoreTD);
    }

    //x 00
    void DisplayCoin(float coinTD)
    {


        coinT.text = string.Format("x {00}", coinTD);
    }
}
