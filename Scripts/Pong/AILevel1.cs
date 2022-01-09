using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AILevel1 : MonoBehaviour
{

    public Button Pause_Button;
    public Button Quit_Button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        SceneManager.LoadScene(8);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}