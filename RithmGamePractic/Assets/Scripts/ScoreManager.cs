using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;
    public int combo;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterResult(JudgeResult result)
    {
        if (result == JudgeResult.Perfect)
        {
            score += 1000;
            combo++;
        }
        else if (result == JudgeResult.Good)
        {
            score += 500;
            combo++;
        }
        else
        {
            combo = 0;
        }
    }
}