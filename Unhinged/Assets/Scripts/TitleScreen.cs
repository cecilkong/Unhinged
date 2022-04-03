using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject quitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void RunCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
