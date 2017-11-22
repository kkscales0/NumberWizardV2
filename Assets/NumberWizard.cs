using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;

    public int maxGuessesAllowed = 5;
    public Text text;

	// Use this for initialization
	void Start () 
    {
        StartGame();
	}

    void StartGame () 
    {
        max = 1000;
        min = 1;
        guess = Random.Range(min, max); 
        text.text = guess.ToString();
    }
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
			GuessHigher();
		} 
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            GuessLower();
		}
	}

    public void GuessHigher ()
    {
        //print("up arrow pressed");
        min = guess;
        NextGuess();
    }

    public void GuessLower ()
    {
        //print("down arrow pressed");
        max = guess;
        NextGuess();
    }

    void NextGuess () 
    {
        guess = Random.Range(min, max);
        text.text = guess.ToString();
        maxGuessesAllowed = maxGuessesAllowed - 1;

        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
