using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    //public SkillCollection _ownedSkills = 
    public SkillCollection OwnedSkills { get; } = new SkillCollection();

    public void Init()
    {
        OwnedSkills.ad
        //_ownedSkills.Add(new FireRate());
    }
}
