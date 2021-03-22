using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStatus : MonoBehaviour
{
    [Range(0f,4f)][SerializeField] private float gameSpeed = 1f;// from 0 to 4 (range)

    [SerializeField] int pointsPerBlockDestroyed = 10;

    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText ;
    public TextMeshProUGUI highScore;
    
    private void Awake()
    {
        int countOfGameStatus = FindObjectsOfType<GameStatus>().Length;// How many objects does gamestatus have
        if (countOfGameStatus>1)//If the number of scenes is more than 1
        {
            gameObject.SetActive(false);//must be done before destroying the object ,the object disappears completely
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);//Destroying the object while the scene is loading
        }
        
    }
    private void Start()
    {
        
        scoreText.text = currentScore.ToString();

        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();

       

    }
    void Update()
    {
        Time.timeScale = gameSpeed;

    }
    public void AddToScore()
    {
        
        currentScore += pointsPerBlockDestroyed ;
       

        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("HighScore",currentScore);

    }
    public void ResetGame()
    {
        Destroy(gameObject);//destroy protected
    }
}
