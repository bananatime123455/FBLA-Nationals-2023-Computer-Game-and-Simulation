using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    
    // Creates an list of chars which we can set the text on the block to
    public static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[] { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, 
        KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, 
        KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };

    //variable for it you win or lose
    bool wL = false;


    //keeps track of how many points you get 

    private int scorePerLevel = 250;
    private int numberOfGuesses = 0;
    private int currentScore;
    [SerializeField]public TextMeshProUGUI currentScoreText;

    //Types of states a tile can have
    [Header("States")]
    public Tile.State emptyState;
    public Tile.State occupiedState;
    public Tile.State correctState;
    public Tile.State wrongPosState;
    public Tile.State incorrectState;

    //references to UI
    [Header("UI")]
    public TextMeshProUGUI invalidWordText;
    public GameObject tryAgainButton;
    public GameObject nextLevelButton;
    public TextMeshProUGUI goodOutcome;
    public TextMeshProUGUI badOutcome;

    [Header("Audio")]
    public AudioSource failAudio;
    public AudioSource successAudio;
    public AudioSource delete;
    public AudioSource input;
    public AudioSource submission;

    //tells the location of the block which is having its text changes
    private int rowIndex;
    private int columnIndex;
    private Row[] rows;

    //stores solutions and valid words
    private string[] solutions;
    private string[] validWords;

    //word which user is trying to find
    private string word;
    [SerializeField] private int wordWant;
    private void Start()
    {
        //loads data into solutions and validwords arrays
        LoadData();
        setWord();
        enabled = true;
    }

    //if the user has to try the level again the board will clear and the level will restart
    public void tryAgain() 
    {
        ClearBoard();
        enabled = true; 
    }
    
    //sends the user to the home scene and adds up score
    public void returnToMainLevel() 
    {
        gameManager.score += currentScore;
        Debug.Log(gameManager.score);
        SceneManager.LoadScene("Story End");
    }
    //sends the user to the Tolevel2 scene and adds up score
    public void returnTo2()
    {
        gameManager.score += currentScore;
        Debug.Log(gameManager.score);
        SceneManager.LoadScene("ToLevel2");
    }
    //sends the user to the Tolevel3 scene and adds up score
    public void returnTo3()
    {
        gameManager.score += currentScore;
        Debug.Log(gameManager.score);
        SceneManager.LoadScene("ToLevel3");
    }
    //sends the user to the Tolevel4 scene and adds up score
    public void returnTo4()
    {
        gameManager.score += currentScore;
        Debug.Log(gameManager.score);
        SceneManager.LoadScene("ToLevel4");
    }

    private void LoadData()
    {
        //sets textasset to contain valid words list from file
        TextAsset textFile = Resources.Load("official_wordle_all") as TextAsset;
        //puts each word in the validWords array
        validWords = textFile.text.Split('\n');
        //sets textasset to contain solutions list from file
        textFile = Resources.Load("official_wordle_common") as TextAsset;
        //puts each word in the solutions array
        solutions = textFile.text.Split('\n');

    }
    //sets the word which is the correct
    private void setWord()
    {
        //sets what word is and formats it
        word = solutions[wordWant];
        word = word.ToLower().Trim();
        print(word);
    }

    private void Awake()
    {
        //Fills the rows array with the rows in the board object
        rows = GetComponentsInChildren<Row>();
    }

    private void Update()
    {
        //sets a variable depecting which row the user is on
        Row currentRow = rows[rowIndex];

        //if the user wants to delete a char
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //plays delete sound
            delete.Play();
            //prevents index from going out of bounds
            columnIndex = Mathf.Max(columnIndex - 1, 0);
            //clears the tile
            currentRow.tiles[columnIndex].SetLetter('\0');
            //sets state to an empty tile
            currentRow.tiles[columnIndex].setState(emptyState);
            //gets rid of text that says that the word is invalid
            invalidWordText.gameObject.SetActive(false);

        }
        //if the user wants to submit a guess
        else if (columnIndex >= currentRow.tiles.Length)
        {
            //if user presses return
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //plays submission sound
                submission.Play();
                //submit row 
                   submitRow(currentRow);
                //updates points
                currentScoreText.text = ("Score on the level: " + currentScore.ToString());
            }
        }
        else
        {
            //Checks if user input is in the list of chars which the text on a block can be changed to 
            for (int i = 0; i < SUPPORTED_KEYS.Length; i++)
            {
                //if it is in the list, then change the text on the block at the location
                if (Input.GetKeyDown(SUPPORTED_KEYS[i]))
                {
                    //plays input sound
                    input.Play();
                    currentRow.tiles[columnIndex].SetLetter((char)(SUPPORTED_KEYS[i]));
                    //sets state to an occupied tile
                    currentRow.tiles[columnIndex].setState(occupiedState);

                    //moves to next block after a chac is entered into a block
                    columnIndex++;
                }
            }
        }
        //updates score
        currentScore = scorePerLevel - numberOfGuesses;
        //prevents score from becoming negative
        if (currentScore < 0) 
        {
            currentScore = 0;
        }
        //updates the displayed score in the text
        currentScoreText.text = ("Score on the level: " + currentScore.ToString());
    }
    //checks if guess is correct
    private void submitRow(Row row)
    {   
        //if the guess is not a real word
        if (!isValidWord(row.word)) 
        {
            //shows text that says that the word is invalid
            invalidWordText.gameObject.SetActive(true);
            return;
        }

        string remaining = word;
        for (int i = 0; i < row.tiles.Length; i++) 
        {
            Tile tile = row.tiles[i];
            //if letter is at the right place and right letter
            if (tile.letter == word[i])
            {
                //sets tile to correct state
                tile.setState(correctState);

                //removes already correct letters and replaces them with blank spaces to prevent them from being counted twice
                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");
            }

            //if letter is not in the word at all
            else if (!word.Contains(tile.letter.ToString()))
            {
                //sets tile to inncorrect state
                tile.setState(incorrectState);
                numberOfGuesses++;
                //updates the displayed score
                currentScoreText.text = ("Score on the level: " + currentScore.ToString());
            }
        }

        for (int i = 0; i < row.tiles.Length; i++) 
        {
            Tile tile = row.tiles[i];
            //if tile isn't already considered correct or incorrect 
            if (tile.state != correctState && tile.state != incorrectState) 
            {

                // if remaining letters contain the letter
                if (remaining.Contains(tile.letter.ToString()))
                {
                    
                    //sets tile to wrongPos State
                    tile.setState(wrongPosState);

                    //removes already used letters and replaces them with blank spaces to prevent them from being counted twice
                    int index = remaining.IndexOf(tile.letter);
                    remaining = remaining.Remove(index, 1);
                    remaining = remaining.Insert(index, " ");
                }
                //if letter is not in the remaining letter
                else 
                {
                    //sets tile to inncorrect state
                    tile.setState(incorrectState);
                }
                
            }
        }
    //move to next row and start at the beginning
    rowIndex++;
        columnIndex = 0;

        //if user has won
        if (hasWon(row)) 
        {

            //tells program player won
            wL = true;
            //shows the move to next level button
            enabled = false;
            //play winning sound
            successAudio.Play();

        }
        //if the user uses all the guesses
        if (rowIndex >= rows.Length)
        {

            //tells program player lost
            wL = false;
            //shows the try again button
            enabled = false;
            //plays losing sound
            failAudio.Play();
        }
    }
    //determines if user guess is a real word
    private bool isValidWord(string word) 
    {   
        for (int i = 0; i < validWords.Length; i++) 
        {
            //if the word is a real word
            if (validWords[i] == word) 
            {
                return true;
            }
        }
        //if the word is not a real word
        return false;
    }
    //checks if user has won
    private bool hasWon(Row row) 
    {
        //for all the tiles in the row
        for (int i = 0; i < row.tiles.Length; i++) 
        {
            //checks if any of the tiles are not correct
            if (row.tiles[i].state != correctState) {
                //if so return false
                return false;
            }
        }
        //if they are all correct return true
        return true;
    }
    //clears the board
    private void ClearBoard()
    {
        //for all the rows in the board
        for (int row = 0; row < rows.Length; row++)
        {
            //for all the tiles in the row
            for (int col = 0; col < rows[row].tiles.Length; col++)
            {
                //clears each tile's letter and state
                rows[row].tiles[col].SetLetter('\0');
                rows[row].tiles[col].setState(emptyState);
            }
        }
        //sets column and row index to 0
        rowIndex = 0;
        columnIndex = 0;
    }
    private void OnEnable()
    {
        //hides all the UI at the start of a new game
        tryAgainButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        invalidWordText.gameObject.SetActive(false);
        goodOutcome.gameObject.SetActive(false);
        badOutcome.gameObject.SetActive(false);
        
    }
    private void OnDisable()
    {
        
        //if user wins
        if (wL)
        {
            //next level button appears along with celebratory message
            goodOutcome.gameObject.SetActive(true);
            nextLevelButton.gameObject.SetActive(true);
        }
        //user has to play again
        else 
        {
            //try again button anbd try again message appear
            badOutcome.gameObject.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
        }
        
    }
    
}
