using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Time Settings")]
    [SerializeField] float dayLengthInSeconds = 300f; // 5 minutes
    [SerializeField, Range(0, 24)] float currentTime = 12f;  // current time of day 

    bool isNight;

    void Update()
    {
        // converts real seconds to game hours
        currentTime += (24f / dayLengthInSeconds) * Time.deltaTime;

        //back to 0
        if (currentTime >= 24f)
            currentTime = 0f;

        CheckPhase();
    }

    /// <summary>
    /// PHASE TRANSITION DETECTION
    /// </summary>
    void CheckPhase()
    {
        // determine if it should be night (6 PM to 6 AM)
        bool shouldBeNight = currentTime >= 18 || currentTime <= 6;

        if (shouldBeNight && !isNight)
        {
            isNight = true;  
            NightManager.Instance.StartNight(); // Start The Night
        }


        if (!shouldBeNight && isNight)
        {
            NightManager.Instance.RequestMorning();  // Request Day (waits for all enemies dead)
            // isNight = false;
        }
    }

    
    /// <summary>
    /// returns the current time (0-24)
    /// </summary>
    public float GetTime()
    {
        return currentTime;
    }

    /// <summary>
    /// returns it's currently night or not
    /// </summary>
    public bool IsNight()
    {
        return isNight;
    }
}