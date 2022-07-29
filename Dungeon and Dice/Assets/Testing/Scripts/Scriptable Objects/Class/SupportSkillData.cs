using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SupportSkillData : SkillData
{
    [Header("Support Skill Data")]
    [Tooltip("Is this skill only able to target the caster?")]
    public bool targetSelfOnly = false;
}
