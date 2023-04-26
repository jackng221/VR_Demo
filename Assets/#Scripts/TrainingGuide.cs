using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrainingGuide : MonoBehaviour
{
    [SerializeField] Canvas dialogueUI;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBtn;

    [SerializeField] List<TrainingStep> steps;
    int currentStep = 0;
    [SerializeField] GameObject doRegisterBookObj;

    UnityEvent ProceedNextStep;
    UnityEvent EndGuide;

    private void Start()
    {
        dialogueText.text = steps[0].Instruction;

        if (ProceedNextStep == null)
        {
            ProceedNextStep = new UnityEvent();
        }
        if (EndGuide == null)
        {
            EndGuide = new UnityEvent();
        }

        ProceedNextStep.AddListener(OutlineObjects);
        ProceedNextStep.AddListener(ChangeDialogue);
        ProceedNextStep.AddListener(ChangeToDo);

        EndGuide.AddListener(CloseGuide);
    }

    public void NextStep() //onClick
    {
        if (currentStep < steps.Count - 1)
        {
            currentStep++;
            ProceedNextStep.Invoke();
        }
        else
        {
            EndGuide.Invoke();
        }
    }
    void CloseGuide()
    {
        dialogueUI.enabled = false;
    }
    void ChangeToDo()
    {
        switch (steps[currentStep].ToDo) {
            case TrainingStep.ThingsToDo.RegisterBook:
                doRegisterBookObj.SetActive(true);
                break;
            default:
                doRegisterBookObj.SetActive(false);
                break;
        }
    }
    void ChangeDialogue()
    {
        dialogueText.text = steps[currentStep].Instruction;
        switch (steps[currentStep].ToDo)
        {
            case TrainingStep.ThingsToDo.PressOK:
                dialogueBtn.SetActive(true);
                break;
            case TrainingStep.ThingsToDo.RegisterBook:
                dialogueBtn.SetActive(false);
                break;
            default:
                dialogueBtn.SetActive(true);
                break;
        }
    }
    void OutlineObjects()
    {
        if (currentStep > 0)
        {
            foreach (GameObject obj in steps[currentStep - 1].OutlineObjs)
            {
                obj.GetComponent<Outline>().enabled = false;
            }
        }
        foreach (GameObject obj in steps[currentStep].OutlineObjs)
        {
            obj.GetComponent<Outline>().enabled = true;
        }
    }
    [ContextMenu("TestNextStep")]
    void TestNextStep()
    {
        NextStep();
    }
}
