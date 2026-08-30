using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private NightTransition nightTransition;
    [SerializeField] private ChargeManager chargeManager;
    [SerializeField] private float wrapUpSeconds = 8f;
    [SerializeField] private TMP_Text timerText;

    private List<MonsterData> selectedDates;
    private MonsterData imposter;
    private int index;
    private int day;
    private float timer;
    private bool roundActive;

    public void StartRound(List<MonsterData> picks)
    {
        selectedDates = picks;
        imposter = selectedDates[Random.Range(0, selectedDates.Count)];
        day = 0;
        StartCoroutine(BeginNight());
    }

    private IEnumerator BeginNight()
    {
        roundActive = false;
        yield return StartCoroutine(nightTransition.ShowNight(day + 1, 3));
        chargeManager.ResetCharges();
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
        monsterVisual.transform.position = monsterSpots[index].position;
        monsterVisual.SetMonster(monster);
        phoneCheck.CurrentDate = monster;
        DialogueManager.Instance.StartDate(monster, isImposter, day);
    }

    public void OnConversationEnded()
    {
        if (timer > wrapUpSeconds)
        {
            timer = wrapUpSeconds;
        }
    }

    private void Update()
    {
        if (!roundActive) return;

        timer -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(Mathf.Max(0f, timer)).ToString();

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
            NextDay();
        }
    }

    private void NextDay()
    {
        day++;
        if (day < 3)
        {
            StartCoroutine(BeginNight());
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