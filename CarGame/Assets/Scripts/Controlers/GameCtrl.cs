using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;   // For working with files
using System.Runtime.Serialization.Formatters.Binary;    // RSFB helps serialization
using UnityEngine.UI;

/// <summary>
/// Script to manage all the imp gameplay features like score,restrting levels, saving, loading data
/// </summary>
public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;
    public float restartDelay;


    public GameData data;  // to work with game data in inspector
    public Text txt_Coin_Count; // tracks the no. of coins collected
    public Text txtScore; // tracks the score
    public int coinValue;
    public float maxTime; // maximum time to finish level
    public UI ui;
    public GameObject instruction;

    string dataFilePath;   // path to store Data files
    BinaryFormatter bf;    // helps in saving/loading binary files
    float timeLeft;   // Time left before the timer goes off
     bool timerOn;   // checks if timer should be on or off
    bool isPaused;   // to pause unpause the game


   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        bf = new BinaryFormatter();

        dataFilePath = Application.persistentDataPath + "/game.dat";

        Debug.Log(dataFilePath);
    }


    // Start is called before the first frame update
    void Start()
    {
        // DataCtrl.instance.RefreshData();
        // data = DataCtrl.instance.data;
        data = GameDataSO.instance.gameData;
        RefreshUI();

        // LevelComplete();
        if(data.lives == 3)
        {
            instruction.SetActive(true);
        }
        


        timerOn = true;
        isPaused = false;

        timeLeft = maxTime;

        HandleFirstBoot();

        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        

        if(timeLeft>0 && timerOn)
        {
            updateTimer();
        }
    }

   

    public void RefreshUI()
    {
        // txt_Coin_Count.text = " x " + data.coinCount;
          data.coinCount = 0;
        // txtScore.text = "Score:" + data.score;    // NEW


       

    }

    private void OnEnable()
    {
        Debug.Log("Data Loaded");
        RefreshUI();
    }

    private void OnDisable()
    {
        Debug.Log("Data Saved");
      //  DataCtrl.instance.SaveData(data);

        Time.timeScale = 1;

        
    }



   





    public void SetStarsAwarded(int levelNumber, int numOfStars)
    {
        data.levelData[levelNumber].starsAwarded = numOfStars;

        // for testing
        Debug.Log("Number of stars awarded = " + data.levelData[levelNumber].starsAwarded);

    }

    /// <summary>
    /// unlocks the specified level
    /// </summary>
    /// <param name="levelNumber"></param>
    public void UnlockLevel(int levelNumber)
    {   
        if((levelNumber+1) <= data.levelData.Length-1)
        {
            data.levelData[levelNumber+1].isUnlocked = true;
          //  DataCtrl.instance.SaveData(data);
        }
        //data.levelData[levelNumber].isUnlocked = true;
    }



    /// <summary>
    /// Get the current score for level complete menu
    /// </summary>
    /// <returns></returns>
 /*   public int GetScore()
    {
        return data.score;
    }
 */
    /// <summary>
    /// Restarts the level when player died
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        
        CheckLives();
       // Invoke("RestartLevel", restartDelay);
    }

    public void LevelComplete()
    {
        

        if (timerOn)
        {
            timerOn = false;
        }

     

        ui.panelMobileUI.SetActive(false);
        ui.levelCompleteMenu.SetActive(true);
        AdsManager.instance.DisplayVideoAds();

        
    }

    void RestartLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void UpdateCoinCount()
    {
        data.coinCount += 1;

        txt_Coin_Count.text = " x " + data.coinCount;

        // UpdateScore(coinValue);                       // NEW
    }


    /*  public void UpdateScore(int value)
      {
          data.score += value;                            // NEW

          txtScore.text = "SCORE:" + data.score;
      }*/

    void updateTimer()
    {
        timeLeft -= Time.deltaTime;

        ui.txtTimer.text = "TIMER:" + (int)timeLeft;

        if(timeLeft<=0)
        {
            ui.txtTimer.text = "TIMER:0";

            // inform the gamectrl to do needful
            GameObject player = GameObject.FindGameObjectWithTag("Player") as GameObject;
            PlayerDied(player);
        }
    }

    void HandleFirstBoot()
    {
       if(data.isFirstBoot)
        {
            // set lives to 3
            data.lives = 3;

            // set no. of coins to 0
            data.coinCount = 0;

            // set score to 0
          //  data.score = 0;

            // set isFirstBoot to false
            data.isFirstBoot = false;
        }
    }

    void UpdateHearts()
    {
        if(data.lives == 3)
        {
            ui.heart1.sprite = ui.fullHeart;
            ui.heart2.sprite = ui.fullHeart;
            ui.heart3.sprite = ui.fullHeart;
        }

        if (data.lives == 2)
        {
            ui.heart1.sprite = ui.emptyheart;
            
        }

        if (data.lives == 1)
        {
            ui.heart1.sprite = ui.emptyheart;
            ui.heart2.sprite = ui.emptyheart;
        }  
    }

    void CheckLives()
    {
        int updatedLives = data.lives;
        updatedLives -= 1;
        data.lives = updatedLives;

        if(data.lives == 0)
        {
            data.lives = 3;
          //  DataCtrl.instance.SaveData(data);
            Invoke("GameOver", restartDelay);
        }
        else
        {
          

           // DataCtrl.instance.SaveData(data);
            Invoke("RestartLevel", restartDelay);
        }
       
    }

    void GameOver()
    {

        

        if (timerOn)
        {
            timerOn = false;
        }

        ui.panelGameOver.SetActive(true);
        AdsManager.instance.DisplayVideoAds();

      

       

    }

    /// <summary>
    /// shows pause panel
    /// </summary>
    public void ShowPausePanel()
    {
        if(ui.panelMobileUI.activeInHierarchy)
        {
            ui.panelMobileUI.SetActive(false);
        }
        ui.panelPause.SetActive(true);

       

        isPaused = true;
    }

    /// <summary>
    /// Hides pause panel
    /// </summary>
    public void HidePausePanel()
    {
        if (!ui.panelMobileUI.activeInHierarchy)
        {
            ui.panelMobileUI.SetActive(true);
        }
        ui.panelPause.SetActive(false);

        isPaused = false;

       
    }

 
}
