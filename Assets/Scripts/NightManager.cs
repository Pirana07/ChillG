using UnityEngine;
using System;

public class NightManager : MonoBehaviour
{
    public static NightManager Instance; //SINGLETON
    
    public int currentDay = 1;  // proggresion
    
    int nightEnemyCount = 0;  
    
    bool morningRequested = false;  // when daynightcycle says it should be morning 
    
    //first time? NO, ITs mY lAsT

    public static event Action<int> OnDayStarted;    // when day starts pass day number
    public static event Action<int> OnNightStarted;  // when night starts pass day number
    

    void Awake()
    {
        Instance = this;  
    }
    
    /// <summary>
    /// START NIGHT PHASE 
    /// </summary>
    public void StartNight()
    {
        Debug.Log($" NIGHT {currentDay} STARTED");  
        OnNightStarted?.Invoke(currentDay);  
    }
    
  

    /// <summary>
    /// Called When each enemy spawns during the night
    /// </summary>
    public void RegisterNightEnemy(EnemyBehaviour enemy)
    {
        nightEnemyCount++;  
        
        // Subscribe to enemy's death event with anonymous function
        enemy.OnEnemyDied += () =>
        {
            nightEnemyCount--;  
            CheckMorningCondition();  
        };
    }
    
 
    /// <summary>
    /// called by DayNightCycle when time reaches to Morning
    /// </summary>
    public void RequestMorning()
    {
        morningRequested = true;  
        CheckMorningCondition();  
    }
    

    /// <summary>
    ///Only allows morning to start if Both conditions are met
    /// </summary>
    void CheckMorningCondition()
    {
        
        if (morningRequested && nightEnemyCount <= 0)
        {
            StartDay();  // transition to day
        }
    }
    
    void StartDay()
    {
        morningRequested = false;  
        Debug.Log($"DAY {currentDay} CLEARED"); 
        OnDayStarted?.Invoke(currentDay);  // Notify all subscribers
        currentDay++;  
    }
    
   
    /// <summary>
    /// Allows other scripts to check how many enemies are still alive
    /// </summary>
    /// <returns></returns>
    public int GetAliveEnemies()
    {
        return nightEnemyCount;
    }
}