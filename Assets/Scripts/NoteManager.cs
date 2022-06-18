using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;
    public GameObject[] NotePrefab;

    [SerializeField] Transform tfNoteAppear = null;

    BossStatus bossStatus;

    private void Start()
    {
        bossStatus = FindObjectOfType<BossStatus>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            if (bossStatus.BossHP > 0)
            {
                int NoteIndex = Random.Range(0, NotePrefab.Length);
                GameObject t_note = Instantiate(NotePrefab[NoteIndex], tfNoteAppear.position, Quaternion.identity);
                t_note.transform.SetParent(this.transform);

                currentTime -= 90d / bpm;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Note_JumpX") || collision.CompareTag("Note_Blue") || collision.CompareTag("Note_Red") || collision.CompareTag("Note_Green")) 
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
