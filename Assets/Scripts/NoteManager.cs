using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;
    public GameObject[] NotePrefab;

    [SerializeField] Transform tfNoteAppear = null;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            int NoteIndex = Random.Range(0, NotePrefab.Length);
            GameObject t_note = Instantiate(NotePrefab[NoteIndex], tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
           
            currentTime -= 90d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Note")) 
        {
            Destroy(collision.gameObject);
        }
       
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Hit");
        }
    }
    */
}
