using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public Note[] notes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < 5; i++)
        {
            if (i == Globals.currentDay-1){
                notes[i].gameObject.SetActive(true);
                notes[i].audio.GetComponent<AudioSource>().mute = false;
            } else {
                notes[i].text.SetActive(false);
                notes[i].paper.SetActive(false);
                notes[i].audio.GetComponent<AudioSource>().mute = true;
            }

        }
    }
}
