using System;

public interface IMinigame {

    public int ProgressProcentage { get; set; }

    public void StartMinigame();
    public void EndMinigame();

    public void ChangeProgressProcentage();
    
    

}