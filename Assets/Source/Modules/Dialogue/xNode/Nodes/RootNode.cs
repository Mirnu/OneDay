using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class RootNode : BaseNode {
    [SerializeField] public int Id { get; private set; }
    [Output] public DialogueNode dialogueNode;
}