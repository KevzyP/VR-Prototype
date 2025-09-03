using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompletion : MonoBehaviour
{
    private List<PuzzleCube> CubeList;
    private AudioSource audioSource;

    public GameObject correctScreen;
    public GameObject incorrectScreen;
    public AudioClip correctAudio;
    public AudioClip incorrectAudio;

    private enum CorrectState { None, Correct, Incorrect  };
    private CorrectState correctState;

    private void Start()
    {
        correctState = CorrectState.None;
        CubeList = new List<PuzzleCube>(FindObjectsOfType<PuzzleCube>());
        audioSource = GetComponent<AudioSource>();
    }

    public void CheckForCompletion()
    {
        int totalCubes = CubeList.Count;
        int correctCubes = 0;

        foreach (PuzzleCube cube in CubeList)
        {
            if (cube.IsCorrectColor)
            {
                correctCubes++;
            }    
        }

        if (correctCubes == totalCubes)
        {
            if (correctState == CorrectState.Correct)
                return;

            correctState = CorrectState.Correct;

            VictoryScreen();
        }
        else
        {
            if (correctState == CorrectState.Incorrect)
                return;

            correctState = CorrectState.Incorrect;

            IncorrectScreen();
        }
    }

    private void VictoryScreen()
    {   
        if (incorrectScreen.activeSelf)
            incorrectScreen.SetActive(false);

        correctScreen.SetActive(true);

        audioSource.clip = correctAudio;
        audioSource.Play();
    }

    private void IncorrectScreen()
    {
        if (correctScreen.activeSelf)
            correctScreen.SetActive(false);

        incorrectScreen.SetActive(true);

        audioSource.clip = incorrectAudio;
        audioSource.Play();
    }
}
