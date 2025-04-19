using System.Collections;
using UnityEngine;

public class Chords : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    float duration1 = 10.3f;     // 9.5 iyi
    float duration2 = 1.98f;    // 1.96 fena değil
    [SerializeField] GameObject[] chords;

    /*
        chords[0] --> B
        chords[1] --> C#m
        chords[2] --> G#m
        chords[3] --> E
        chords[4] --> F#
        chords[5] --> D#
        chords[6] --> A
    */

    private void Awake()
    {
        audioSource.Play();
    }
    void Start()
    {
        StartCoroutine(PlayStarlight());
    }
    IEnumerator PlayStarlight()
    {
        // audioSource.Play();
        chords[0].SetActive(true);  // B
        yield return new WaitForSeconds(duration1);

        chords[0].SetActive(false); // B
        chords[1].SetActive(true);  // C#m
        yield return new WaitForSeconds(duration2);

        chords[1].SetActive(false); // C#m
        chords[2].SetActive(true);  // G#m
        yield return new WaitForSeconds(duration2);

        chords[2].SetActive(false); // G#m
        chords[3].SetActive(true);  // E
        yield return new WaitForSeconds(duration2);

        // --------------------------------------

        for (int i = 0; i < 9; i++)
        {
            chords[3].SetActive(false); // E
            chords[0].SetActive(true);  // B
            yield return new WaitForSeconds(duration2);

            chords[0].SetActive(false); // B
            chords[1].SetActive(true);  // C#m
            yield return new WaitForSeconds(duration2);

            chords[1].SetActive(false); // C#m
            chords[2].SetActive(true);  // G#m
            yield return new WaitForSeconds(duration2  - 0.01f);

            chords[2].SetActive(false); // G#m
            chords[3].SetActive(true);  // E
            yield return new WaitForSeconds(duration2);
        }

        // --------------------------------------

        chords[3].SetActive(false); // E
        chords[1].SetActive(true);  // C#m
        yield return new WaitForSeconds(duration2);

        chords[1].SetActive(false); // C#m
        chords[4].SetActive(true);  // F#
        yield return new WaitForSeconds(duration2);

        chords[4].SetActive(false); // F#
        chords[5].SetActive(true);  // D#
        yield return new WaitForSeconds(duration2);

        chords[5].SetActive(false); // D#
        chords[2].SetActive(true);  // G#m
        yield return new WaitForSeconds(duration2 - 0.12f);

        chords[2].SetActive(false); // G#m
        chords[6].SetActive(true);  // A
        yield return new WaitForSeconds(duration2);

        chords[6].SetActive(false); // A
        chords[3].SetActive(true);  // E
        yield return new WaitForSeconds(duration2);

        chords[3].SetActive(false); // E
        chords[6].SetActive(true);  // A
        yield return new WaitForSeconds(duration2);

        chords[6].SetActive(false); // A
        chords[5].SetActive(true);  // D#
        yield return new WaitForSeconds(duration2);

        // --------------------------------------

        chords[5].SetActive(false); // D#
        chords[2].SetActive(true);  // G#m
        yield return new WaitForSeconds(duration2);

        chords[2].SetActive(false); // G#m
        chords[5].SetActive(true);  // D#
        yield return new WaitForSeconds(duration2);

        chords[5].SetActive(false); // D#
        chords[3].SetActive(true);  // E
        yield return new WaitForSeconds(duration2);

        chords[3].SetActive(false); // E
        chords[0].SetActive(true);  // B
        yield return new WaitForSeconds(duration2);

        for (int i = 0; i < 2; i++)
        {
            chords[0].SetActive(false); // B
            chords[2].SetActive(true);  // G#m
            yield return new WaitForSeconds(duration2);

            chords[2].SetActive(false); // G#m
            chords[5].SetActive(true);  // D#
            yield return new WaitForSeconds(duration2);

            chords[5].SetActive(false); // D#
            chords[3].SetActive(true);  // E
            yield return new WaitForSeconds(duration2);

            chords[3].SetActive(false); // E
            chords[0].SetActive(true);  // B
            yield return new WaitForSeconds(duration2);
        }

        chords[0].SetActive(false); // B
        chords[2].SetActive(true);  // G#m
        yield return new WaitForSeconds(duration2);

        chords[2].SetActive(false); // G#m
        chords[5].SetActive(true);  // D#
        yield return new WaitForSeconds(duration2);

        chords[5].SetActive(false); // D#
        chords[3].SetActive(true);  // E
        yield return new WaitForSeconds(duration2);

        chords[3].SetActive(false); // E
        chords[4].SetActive(true);  // F#
        yield return new WaitForSeconds(duration2);
        
        // --------------------------------------

        chords[4].SetActive(false);  // F#
        chords[0].SetActive(true); // B
        yield return new WaitForSeconds(duration2);

        chords[0].SetActive(false); // B

    }
}
