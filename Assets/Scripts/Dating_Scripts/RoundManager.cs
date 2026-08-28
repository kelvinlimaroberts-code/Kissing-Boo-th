using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private SeatedCameraRig cameraRig;
    [SerializeField] private PhoneCheck phoneCheck;
    [SerializeField] private Transform[] seatPositions;
    [SerializeField] private Transform[] monsterSpots;
    [SerializeField] private MonsterVisualDisplay monsterVisual;
    [SerializeField] private VoteScreen voteScreen;

    private List<MonsterData> selectedDates;
    private MonsterData imposter;
    private int index;
    private int day;
    private float timer;
    private bool roundActive;


    private void BeginDate()
    {
        timer = settings.dateTimerSeconds;
        MonsterData monster = selectedDates[index];
        bool isImposter = monster == imposter;
        cameraRig.MoveToSeat(seatPositions[index]);
        monsterVisual.transform.position = monsterSpots[index].position;
        monsterVisual.SetMonster(monster);
        phoneCheck.CurrentDate = monster;
        DialogueManager.Instance.StartDate(monster, isImposter);
    }
    public void StartRound(List<MonsterData> picks)
    {
        selectedDates = picks;
        imposter = selectedDates[Random.Range(0, selectedDates.Count)];
        index = 0;
        day = 0;
        roundActive = true;
        BeginDate();
    }

    // BeginDate() stays exactly as it is

    private void NextDate()
    {
        index++;
        if (index < selectedDates.Count)
        {
            BeginDate();
        }
        else
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        day++;
        if (day < 3)
        {
            index = 0;
            BeginDate();
        }
        else
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        roundActive = false;
        voteScreen.Show(selectedDates, imposter);
    }
}

