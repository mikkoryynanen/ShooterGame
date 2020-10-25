using UnityEngine;

public abstract class BaseSkill 
{
    public string Name { get; set; }
    public Sprite Icon { get; set; }
    public float PowerCoefficient { get; protected set; }
}
