using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public SongChart chart;

    public float laneSpacing = 1.5f;
    public float firstLaneX = -3.75f;

    private int nextNoteIndex = 0;

    void Update()
    {
        if (SongConductor.Instance == null) return;
        if (chart == null || notePrefab == null) return;
        if (nextNoteIndex >= chart.notes.Count) return;

        double now = SongConductor.Instance.songTime;
        NoteData data = chart.notes[nextNoteIndex];

        if (now >= data.hitTime - 2.0f)
        {
            SpawnNote(data);
            nextNoteIndex++;
        }
    }

    void SpawnNote(NoteData data)
    {
        GameObject obj = Instantiate(notePrefab);

        NoteView note = obj.GetComponent<NoteView>();
        if (note == null)
        {
            Debug.LogError("NoteView missing on prefab");
            return;
        }

        note.lane = data.lane;
        note.hitTime = data.hitTime;
        note.keyPress = GetKeyForLane(data.lane);

        Vector3 pos = obj.transform.position;
        pos.x = firstLaneX + data.lane * laneSpacing;
        pos.y = note.spawnY;
        obj.transform.position = pos;
    }

    KeyCode GetKeyForLane(int lane)
    {
        if (lane == 0) return KeyCode.A;
        if (lane == 1) return KeyCode.S;
        if (lane == 2) return KeyCode.D;
        if (lane == 3) return KeyCode.J;
        if (lane == 4) return KeyCode.K;
        if (lane == 5) return KeyCode.L;
        return KeyCode.None;
    }
}