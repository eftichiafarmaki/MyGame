using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AI_Level_Control : MonoBehaviour
{

    public Button Level1_Button;
    public Button Level2_Button;
    public Button Level3_Button;
    public Button Level4_Button;
    public Button Back_Button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(7);

    }


    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }


}
