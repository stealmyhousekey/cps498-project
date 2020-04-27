
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckScript : MonoBehaviour
{
    [Header("Goal Object")]
    public GameObject correctLabel;
    public GameObject secondObject;
    public GameObject wordstart;
    public GameObject correctObject;
    public GameObject currentObject;
    public int correctAttempt;
    public Text countText;
    


    [Header("Win/Lose Text")]
    public Text textWrong;
    public Text textRight;
    public Text victoryText;

    //global score variable
    public static int count;
    public static int correctcount;
    

    void Start()
    {
        count = 0;
        correctcount = 0;
        
        countText.text = "Correct: " + count.ToString();
        
    }
    void Update()
    {
        
      

        //win state on all solved
        if (correctcount == 8)
        {
            textRight.enabled = false;
            textRight.gameObject.SetActive(false);
            countText.enabled = false;
            countText.gameObject.SetActive(false);
            victoryText.text = "You win! Your score was: " + count.ToString();
            victoryText.enabled = true;
            victoryText.gameObject.SetActive(true);
            StartCoroutine(textTimer(10));
            //Debug.Log("game should quit");
            //SceneManager.LoadScene(0);// loads scene 0 back to the menu
            //Application.Quit();
            correctcount += 1; //stops print spam when debugging
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        //print("Another object has entered the trigger: " + other.gameObject.name);


        if (other.gameObject == correctLabel)
        {
            correctObject = other.gameObject;
            currentObject = GameObject.Find(gameObject.name);
            Debug.Log(gameObject.name);
            textWrong.enabled = false;
            textWrong.gameObject.SetActive(false);
            textRight.enabled = true;
            textRight.gameObject.SetActive(true);

            //increment score up and display
            count = count + 1;
            correctcount += 1;
            countText.text = "Correct: " + count.ToString();

            correctObject.SetActive(false);
            currentObject.transform.position = new Vector3(100, 100, 100);

        }

        else
        {
            textRight.enabled = false;
            textRight.gameObject.SetActive(false);
            textWrong.enabled = true;
            textWrong.gameObject.SetActive(true);

            //decrement score down and display
            count = count - 1;
            countText.text = "Correct: " + count.ToString();
            secondObject = other.gameObject;
            wordstart = GameObject.Find(secondObject.name + "start");
            wordstart = GameObject.Find(secondObject.name + "start");
            secondObject.transform.position = wordstart.transform.position;
            
        }

        StartCoroutine(textTimer(3/2));

    }

    IEnumerator textTimer(int x)
    {
        //yield on a new YieldInstruction that waits for 1.5 seconds.
        yield return new WaitForSeconds(x);
        textRight.enabled = false;
        textWrong.enabled = false;
    }


   
}