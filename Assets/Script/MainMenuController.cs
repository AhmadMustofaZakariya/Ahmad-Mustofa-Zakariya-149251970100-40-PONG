using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void playGame()
   {
       SceneManager.LoadScene("Game");
   }
    public void openAuthor()
   {
       Debug.Log("Created by Ahmad Mustofa Zakariya - 149251970100-40");
   }
   public void MainMenu()
   {
        SceneManager.LoadScene("Main Menu");
   }
   public void openCredit()
   {
        SceneManager.LoadScene("Credit Scene");
   }
}
