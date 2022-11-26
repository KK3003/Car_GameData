using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// locks/ unlocks the level and shows stars for unlocked levels
/// </summary>
public class BtnCtrl : MonoBehaviour
{
    int levelNumber;            // the level to check
    Button btn;                 // the button to which this script is attached
    Image btnImage;             // the image of this button
    Text btnText;               // the text element of this button
    Transform star1, star2, star3; // the 2 stars which are shown in the button

    public Sprite lockedBtn;       // Spritr shown when btn is locked
    public Sprite unlockedBtn;      // sprite shown when btn is unlocked
    public string sceneName;      // the scene which will be loaded

    // Start is called before the first frame update
    void Start()
    {
        // level numbers reprentation
        levelNumber = int.Parse(transform.gameObject.name);

        // getting reference to btn image, text, and button
        btn = transform.gameObject.GetComponent<Button>();
        btnImage = btn.GetComponent<Image>();
        btnText = btn.gameObject.transform.GetChild(0).GetComponent<Text>();

        // getting references to the stars attached to the gameobject
        star1 = btn.gameObject.transform.GetChild(1);
        star2 = btn.gameObject.transform.GetChild(2);
        star3 = btn.gameObject.transform.GetChild(3);

        BtnStatus();

    }

    /// <summary>
    /// locks/unlocks certain button and shows no. of strs awarded
    /// </summary>
    /// 

    void BtnStatus()
    {
        // getting the lock status and no. of stars
        bool unlocked = DataCtrl.instance.isUnlocked(levelNumber);
        int starsAwarded = DataCtrl.instance.getStars(levelNumber);

        if(unlocked)
        {
            // show appropriate no. of stars
            if(starsAwarded == 3)
            {
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(true);
            }
            if (starsAwarded == 2)
            {
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(false);
            }
            if (starsAwarded == 1)
            {
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
            }
            if (starsAwarded == 0)
            {
                star1.gameObject.SetActive(false);
                star2.gameObject.SetActive(false);
                star3.gameObject.SetActive(false);
            }

            btn.onClick.AddListener(LoadScene);
            
        }
        else
        {
            // show the locked btn image
            btnImage.overrideSprite = lockedBtn;

            // dont show any text on the btn
            btnText.text = "";

            // hide the 3 stars
            star1.gameObject.SetActive(false);
            star2.gameObject.SetActive(false);
            star3.gameObject.SetActive(false);
        }
    }

    void LoadScene()
    {
        LoadingCtrl.instance.ShowLoading();
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
