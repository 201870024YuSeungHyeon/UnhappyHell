using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote1 = null;
    [SerializeField] GameObject goNote2 = null;
    [SerializeField] GameObject goNote3 = null;
    [SerializeField] GameObject goNote4 = null;

    void Update()
    {
        int i = 2;
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            GameObject t_note = Instantiate(goNote4, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Note")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
