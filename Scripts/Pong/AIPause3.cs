//EXW FTIAKSEI 4 SCRIPTS GIA TO PAUSE ai, ENA DIAFORETIKO GIA KATHE LEVEL. AUTO GIATI KATHE FORA THELW TO BUTTON "BACK TO GAME" NA METAVAINEI SE DIAFORETIKH SCENE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIPause3 : MonoBehaviour
{

    public Button Back_Button;  //dhlwnw ta buttons
    public Button Quit_Button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToGame()
    {
        SceneManager.LoadScene(1);  //dhlwnw thn metavasi stin skhnh pou epithimw na metavei to paixnidi afou pathsw to button back to game
    }

    public void QuitGame()
    {
        Application.Quit(); //exodos apo tin efarmogi an pathsw to button quit

    }
}

