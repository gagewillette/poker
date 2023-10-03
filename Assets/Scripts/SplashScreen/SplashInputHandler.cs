using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashInputHandler : MonoBehaviour
{
   // the player will have to choose a server from the explorer,
   // if the server has a spot for the player, and the player can afford the buying
   // they will be able to connect

   public Button STARTBUTTON;

   public void Start()
   {
      STARTBUTTON.onClick.AddListener(startClick);
   }

   public void startClick()
   {  
      Debug.Log("start butotn clicked");
      SceneManager.LoadScene(1);
   }
}
