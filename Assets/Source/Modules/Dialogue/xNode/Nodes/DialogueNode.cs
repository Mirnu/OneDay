using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : Node {

    [Output(dynamicPortList = true)] public List<string> childrens;

    [SerializeField] private string _name;
    [SerializeField][TextArea] private string _text;
    public string Name => _name;
    public string Text => _text;
}