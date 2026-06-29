using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SongChart", menuName = "Rhythm/Song Chart")]
public class SongChart : ScriptableObject
{
    public List<NoteData> notes = new List<NoteData>();
}