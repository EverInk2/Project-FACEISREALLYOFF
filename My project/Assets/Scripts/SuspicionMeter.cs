using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections;


public class SuspicionMeter : MonoBehaviour
{
    internal UnityEngine.UI.Image SuspicionBar;

    internal int suspicion; // 100 = game over. Effectively X/100 percent.
    private float timeSpent; //How much time the player has spent in the mask.
    private float suspicionInterval = 30f; //Takes 30 second intervals
    EnemyDetection enemyDetection;

    //publicly accessible property
    public int Suspicion
    {
        get { return suspicion; } set { suspicion = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Suspicion is empty, no bar fill, no time spent 
        SuspicionBar.fillAmount = 0;
        timeSpent = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime; //Constantly updates our time every frame
        while (timeSpent >= suspicionInterval) //once it hits or surpasses 30
        {
            //Every thirty seconds in the same mask increases the suspicion by 10
            //In effect: the player can spend a maximum of 5 minutes in one mask.
            IncreaseSuspicion(10);
            timeSpent -= suspicionInterval;
        }
    }

    /// <summary>
    /// Increases the suspicion by a set amount
    /// </summary>
    /// <param name="amount"></param>
    internal void IncreaseSuspicion(int amount)
    {
        //Suspicion is, effectively, a percentage. 
        SuspicionBar.fillAmount += (float)amount / 100;
        suspicion += amount;
    } 

    /// <summary>
    /// Changing the mask resets the time interval and suspicion
    /// </summary>
    internal void ChangedMask()
    {
        //Add 30 suspicion if mask changed in front of an enemy
        if(enemyDetection.playerDetected)
        {
            suspicion += 30;
        }
        else //Otherwise, reset it back to 0. 
        {
            timeSpent = 0f;
            suspicion = 0;
        }
    }
    /// <summary>
    /// Destroys an enemy and takes their mask
    /// </summary>
    /// <param name="enemy"></param>
    internal void EnemyEliminated(UnityEngine.Object enemy)
    {
        if (enemyDetection.playerDetected) //This seems low but I don't want it to be too punishing.
        {
            suspicion += 15;
        }
        else //The dead guy makes people about 5% suspicious. 
        {
            suspicion = 5;
        }
        Destroy(enemy);
        //Add the mask obtaining methods here when we have them
    }

    internal void GameOver()
    {
        if (suspicion >= 100)
        {
            //Add game over state.
        }
    }
}
