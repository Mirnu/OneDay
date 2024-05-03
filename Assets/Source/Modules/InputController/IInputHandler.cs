using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
    Action<KeyCode> KeyUp { get; set; }
    Action<KeyCode> KeyDown { get; set; }
    Action<KeyCode> KeyPressed { get; set; }
    Action<string> HorizontalAxis { get; set; }
    Action<string> VerticalAxis { get; set; }
}
