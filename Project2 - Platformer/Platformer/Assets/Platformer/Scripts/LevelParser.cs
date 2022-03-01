using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;


public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;

    [FormerlySerializedAs("stone")]
    public GameObject StonePrefab;

    public GameObject WaterPrefab;
    public GameObject MetalPollPrefab;

    public Transform environmentRoot;



    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        //Gets informatio for the level in order to build it
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        // stack: we want to read from top to bottom, so we use the stack to start at the bottom and read to the top
        Stack<string> levelRows = new Stack<string>();


        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();

            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter

                var testObj = Instantiate(StonePrefab);
                var brickObj = Instantiate(brickPrefab);
                var questionObj = Instantiate(questionBoxPrefab);
                var rockObj = Instantiate(rockPrefab);

                var waterObj = Instantiate(WaterPrefab);
                var metalpollObj = Instantiate(MetalPollPrefab);

                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot

                if (letter == 'x')
                {

                    testObj.transform.position = new Vector3(column + 1, row + (float)0.55, 0f);

                }
                if (letter == 'b')
                {
                    brickObj.transform.position = new Vector3(column + 1, row + (float)0.55, 0f);
                }

                if (letter == '?')
                {
                    questionBoxPrefab.transform.position = new Vector3(column + 1, row + (float)0.55, 0f);
                }

                if (letter == 's')
                {
                    rockObj.transform.position = new Vector3(column + 1, row + (float)0.55, 0f);
                }


                // new prefabs

                if (letter == 'w')
                {
                    waterObj.transform.position = new Vector3(column + 1, row + (float)0.55, 0f);
                }

                if (letter == 'g')
                {
                    metalpollObj.transform.position = new Vector3(column + 1, row + (float)0.55, 0f);
                }






                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
