using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChanger : MonoBehaviour
{
    [Header("Normal Parrot Limit")]
    [SerializeField] Enemy normalParrot;
    [SerializeField] int normalParrotOriginalSpawnLimit;
    [SerializeField] int normalParrotMidGameSpawnLimit;
    [SerializeField] int normalScoreRequiredToChangeLimit;

    [Header("Big Parrot Limit")]
    [SerializeField] Enemy bigParrot;
    [SerializeField] int bigParrotOriginalSpawnLimit;
    [SerializeField] int bigParrotMidGameSpawnLimit;
    [SerializeField] int bigParrotLateGameSpawnLimit;
    [SerializeField] int bigMidScoreRequiredToChangeLimit;
    [SerializeField] int bigLateScoreRequiredToChangeLimit;


    [Header("Fluff Cannon Limit")]
    [SerializeField] Enemy fluffCannon;
    [SerializeField] int fluffCannonOriginalSpawnLimit;
    [SerializeField] int fluffCannonMidGameSpawnLimit;
    [SerializeField] int fluffCannonLateGameSpawnLimit;
    [SerializeField] int fluffMidScoreRequiredToChangeLimit;
    [SerializeField] int fluffLateScoreRequiredToChangeLimit;

    private void Start()
    {
        fluffCannon.setSpawnLimit(fluffCannonOriginalSpawnLimit);
        normalParrot.setSpawnLimit(normalParrotOriginalSpawnLimit);
        bigParrot.setSpawnLimit(bigParrotOriginalSpawnLimit);
    }

    private void Update()
    {
        if (ScoreManager.currentScore >= fluffMidScoreRequiredToChangeLimit)
            fluffCannon.setSpawnLimit(fluffCannonMidGameSpawnLimit);

        if (ScoreManager.currentScore >= fluffLateScoreRequiredToChangeLimit)
            fluffCannon.setSpawnLimit(fluffCannonLateGameSpawnLimit);

        if (ScoreManager.currentScore >= normalScoreRequiredToChangeLimit)
            normalParrot.setSpawnLimit(normalParrotMidGameSpawnLimit);

        if (ScoreManager.currentScore >= bigMidScoreRequiredToChangeLimit)
            bigParrot.setSpawnLimit(bigParrotMidGameSpawnLimit);

        if (ScoreManager.currentScore >= bigLateScoreRequiredToChangeLimit)
            bigParrot.setSpawnLimit(bigParrotLateGameSpawnLimit);

    }
}
