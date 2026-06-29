using UnityEngine;

public class NoteView : MonoBehaviour
{
    public int lane;
    public double hitTime;
    public bool judged;

    public float spawnY = 6f;
    public float hitY = -3f;
    public float noteSpeed = 4.5f;

    public KeyCode keyPress;

    void Update()
    {
        if (judged) return;
        if (SongConductor.Instance == null) return;

        double now = SongConductor.Instance.songTime;
        float distance = spawnY - hitY;
        double spawnTime = hitTime - (distance / noteSpeed);

        if (now < spawnTime) return;

        float t = Mathf.InverseLerp((float)spawnTime, (float)hitTime, (float)now);
        float y = Mathf.Lerp(spawnY, hitY, t);

        Vector3 pos = transform.position;
        pos.y = y;
        transform.position = pos;

        if (Input.GetKeyDown(keyPress))
        {
            float diff = Mathf.Abs((float)(now - hitTime));

            if (diff <= 0.05f)
                Judge("Perfect");
            else if (diff <= 0.12f)
                Judge("Good");
            else if (diff <= 0.20f)
                Judge("Normal");
            else
                Judge("Miss");
        }

        if (now > hitTime + 0.20f)
        {
            Judge("Miss");
        }
    }

    void Judge(string result)
    {
        if (judged) return;
        judged = true;

        if (JudgeTextUI.Instance != null)
        {
            JudgeTextUI.Instance.Show(result);
        }

        Debug.Log(result);

        if (ScoreManager.Instance != null)
        {
            if (result == "Perfect") ScoreManager.Instance.RegisterResult(JudgeResult.Perfect);
            else if (result == "Good") ScoreManager.Instance.RegisterResult(JudgeResult.Good);
            else ScoreManager.Instance.RegisterResult(JudgeResult.Miss);
        }

        Destroy(gameObject);
    }
}