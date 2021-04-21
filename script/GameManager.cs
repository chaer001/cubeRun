using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine.Audio;



public class GameManager : MonoBehaviour
{
    // test ca - app - pub - 3940256099942544 / 1033173712
    // original  ca - app - pub - 1450754742240393 / 6074457483

    PlayerMovement x = new PlayerMovement();
    
    bool gameHasEnded = false;

    
    public GameObject completeLevelUI;

    public GameObject restartMenuUI;
    
    public float restartDelay = 2f;

    private InterstitialAd interstitial;

    bool isMute;

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1450754742240393/6074457483";
#elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-1450754742240393/9822130801";
#else
      string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        
    }

    public void Start()
    {
        

        RequestInterstitial();
    }

    public void EndGame()
    {
        
        
        
        
            if (gameHasEnded == false)
           
        {


            
            
                gameHasEnded = true;

          
                
            Invoke("End", restartDelay);
         

        }
        
       
    }

    public void CompleteLevel()
    {
      
        completeLevelUI.SetActive(true);
    }

    
    void Restart()
    {
       
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
   public void End()
    {
        x.setForwardF(false);
        //if (SceneManager.GetActiveScene().buildIndex - 1 >= 1)
        //{
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
       // }
        restartMenuUI.SetActive(true);
            
    }

   



}
