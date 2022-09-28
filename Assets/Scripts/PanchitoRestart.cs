using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanchitoRestart : MonoBehaviour
{
    public string screneOrder;

    public void RestartGame()
    {
        SceneManager.LoadScene(screneOrder);
        // SceneTransition.instance.StartTransition(0);
    }

    
}
