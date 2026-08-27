using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private SeatedCameraRig cameraRig;
    [SerializeField] private PhoneCheck phoneCheck;
    [SerializeField] private Transform[] seatPositions;

    private List<MonsterData> selectedDates;
    private MonsterData imposter;
    private int index;
    private float timer;
    private bool roundActive;


    public void StartRound(List<MonsterData> picks)
    {
        selectedDates = picks;
        imposter = selectedDates[Random.Range(0, selectedDates.Count)];
        index = 0;
        roundActive = true;
        BeginDate();
    }

    private void BeginDate()
    {
        timer = settings.dateTimerSeconds;
        MonsterData monster = selectedDates[index];
        bool isImposter = monster == imposter;
        cameraRig.MoveToSeat(seatPositions[index]);
        phoneCheck.CurrentDate = monster;
        DialogueManager.Instance.StartDate(monster, isImposter);
    }

    private void Update()
    {
        if (!roundActive) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            NextDate();
        }
    }

    private void NextDate()
    {
        index++;
        if (index < selectedDates.Count)
        {
            BeginDate();
        }
        else
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        // Reveal goes here (good or bad ending)
    }
}

