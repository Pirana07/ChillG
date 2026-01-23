using UnityEngine;

[System.Serializable]
public class CooldownTimer
{
    float timer;

    public void Tick(float deltaTime)
    {
        if (timer > 0f)
            timer -= deltaTime;
    }

    public bool IsReady(float lastSec)
    {
        return timer <= lastSec;
    }

    public void Reset(float cooldown)
    {
        timer = cooldown;
    }

    public void ForceReady()
    {
        timer = 0f;
    }
}
