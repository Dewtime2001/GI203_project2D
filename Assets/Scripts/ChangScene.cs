using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
   public void Play()
   {
      SceneManager.LoadScene("HowtoPlay");
   }
   
   public void Go()
   {
      SceneManager.LoadScene("SampleScene");
   }
   
   public void Credit()
   {
      SceneManager.LoadScene("Credit");
   }
   
   
   public void Mainmenu()
   {
      SceneManager.LoadScene("MainMenu");
   }
}
