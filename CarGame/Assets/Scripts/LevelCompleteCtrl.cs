using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class LevelCompleteCtrl : MonoBehaviour
{
    public Button btnNext;      // for next level
    public Sprite GoldenStar;   // awarded when score is above certain value
    public Image star1;         // the Ui image for star white star
    public Image star2;         // the Ui image for star white star
    public Image star3;         // the Ui image for star white star
    public Text txtScore;       // for showing the score
    public int levelNumber;     // which level is this
    [HideInInspector]
    public int datascore;           // the current score   changed
    public int scoreForThreeStars; // score for 3 stars
    public int scoreForTwoStars; // score for 2 star
    public int scoreForOneStars; // score for 1 star
    public int scoreForNExtLEvel; // score to unlock next level
    public float animStartDelay;  // brief delay in seconds before stars are awarded
    public float animaDelay;      // animation in each star

    bool showTwoStars, showThreeStars;  // for checking how many stars to show

    public GameData data;

    // Start is called before the first frame update
    void Start()
    {
        data = DataCtrl.instance.data;
        // enable when deploying and beta testing
        // score = GameCtrl.instance.GetScore();
        datascore = data.coinCount;

        

        // update the score text
        txtScore.text = "" + datascore;

        // determine the number of stars to be awarded
        if(datascore >= scoreForThreeStars)
        {
            showThreeStars = true;
            GameCtrl.instance.SetStarsAwarded(levelNumber, 3);
            Invoke("ShowGoldenStars", animStartDelay);
        }

        if(datascore >= scoreForTwoStars && datascore < scoreForThreeStars)
        {
            showTwoStars = true;
            GameCtrl.instance.SetStarsAwarded(levelNumber, 2);
            Invoke("ShowGoldenStars", animStartDelay);
        }
        //score <= scoreForOneStars && score != 0

        if (datascore <= scoreForOneStars && datascore != 0)
        {
            GameCtrl.instance.SetStarsAwarded(levelNumber, 1);
            Invoke("ShowGoldenStars", animStartDelay);
        }




    }

    void ShowGoldenStars()
    {
        StartCoroutine("HandleFirstStarAnim", star1);
    }

    IEnumerator HandleFirstStarAnim(Image starImg)
    {

        DoAnim(starImg);

        // cause a delay before showing a new star
        yield return new WaitForSeconds(animaDelay);

        //called if more than two stars are awarded
        if(showTwoStars || showThreeStars)
        {
            StartCoroutine("HandleSecondStarAnim", star2);
        }
        else
        {
            Invoke("CheckLevelStatus", 1.2f);
        }

    }



    IEnumerator HandleSecondStarAnim(Image starImg)
    {
        DoAnim(starImg);

        // cause a delay before showing a new star
        yield return new WaitForSeconds(animaDelay);

        showTwoStars = false;

        if(showThreeStars)
        {
            StartCoroutine("HandleThirdStarAnim", star3);
        }
        else
        {
            Invoke("CheckLevelStatus", 1.2f);
        }


    }


    IEnumerator HandleThirdStarAnim(Image starImg)
    {
        DoAnim(starImg);

        // cause a delay before showing a new star
        yield return new WaitForSeconds(animaDelay);

        showThreeStars = false;

        Invoke("CheckLevelStatus", 1.2f);


    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckLevelStatus()
    {
        // unlock next level if score is reched
        if(datascore >= scoreForNExtLEvel)
        {
            btnNext.interactable = true;

            //add sparkle effect 

            // unlock the next level
            GameCtrl.instance.UnlockLevel(levelNumber);
        }
        else
        {
            btnNext.interactable = false;
        }
    }


    void DoAnim( Image starImg)
    {
        // Increase the star size
        starImg.rectTransform.sizeDelta = new Vector2(150f, 150f);

        // show the golden star
        starImg.sprite = GoldenStar;

        // reduce the star size to normal using DoTween animation
        RectTransform t = starImg.rectTransform;
        t.DOSizeDelta(new Vector2(100f, 100f), 0.5f, false);

        // play an audio effect


        // show a sparkle effect
        SFXCtrl.instance.ShowCoinSparkle(starImg.gameObject.transform.position);
    }
}
