using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputHandler
{
    Action<KeyCode> KeyUp { get; set; }
    Action<KeyCode> KeyDown { get; set; }
    Action<KeyCode> KeyPressed { get; set; }
    Action<float> HorizontalAxis { get; set; }
    Action<float> VerticalAxis { get; set; }
}
