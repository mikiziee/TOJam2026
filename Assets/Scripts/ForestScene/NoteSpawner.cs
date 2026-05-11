using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public Note[] notes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Globals.currentDay; i++)
        {
            notes[i].gameObject.SetActive(true);

            if (i + 1 != Globals.currentDay)
            {
                notes[i].text.SetActive(false);
                notes[i].paper.SetActive(false);
            }
        }
    }
}
