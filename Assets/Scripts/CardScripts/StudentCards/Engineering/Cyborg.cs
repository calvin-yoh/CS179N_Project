using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyborg : CardEffect
{
    protected override void Start()
    {
        targetType = Card.Type.Student;
        targetTeam = TargetTeam.Enemy;
        numTargets = 1;
    }
    //Human Augmentation: Reduce an opposing student's duration by 1.
    public override int PerformEffect(GameData data)
    {
        
        StudentCardDisplay target;
        int effectValue = 1 + data.self.GetComponent<CardDisplay>().GetEffectValueModifier();
        if (data.target[0].gameObject.TryGetComponent(out target))
        {
            target.ChangeDurationBy(-1 * effectValue);
            Debug.Log("Cyborg Worked");
        }
        else{
            Debug.Log("Cyborg Error");
        }
        return 0;
    }
}