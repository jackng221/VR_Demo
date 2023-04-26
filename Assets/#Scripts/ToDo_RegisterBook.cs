using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToDo_RegisterBook : MonoBehaviour
{
    [SerializeField] TrainingGuide trainingGuide;
    UnityEvent TriggerEvent;

    private void Awake()
    {
        if (TriggerEvent == null)
        {
            TriggerEvent = new UnityEvent();
        }
    }
    private void OnEnable()
    {
        TriggerEvent.AddListener(trainingGuide.NextStep);
    }
    private void OnDisable()
    {
        TriggerEvent.RemoveListener(trainingGuide.NextStep);
    }

    public void Trigger()
    {
        TriggerEvent?.Invoke();
    }
}
