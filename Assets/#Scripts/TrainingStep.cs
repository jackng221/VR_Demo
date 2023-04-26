using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingStep
{
    public string Instruction {
        get { return instruction; }
    }
    [SerializeField] string instruction;

    public List<GameObject> OutlineObjs
    {
        get { return outlineObjs; }
    }
    [SerializeField] List<GameObject> outlineObjs;

    public enum ThingsToDo
    {
        PressOK = 0,
        RegisterBook = 1
    }
    public ThingsToDo ToDo {
        get { return toDo; }
    }
    [SerializeField] ThingsToDo toDo;
}
