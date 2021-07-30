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

    [Header("Fast Parrot Speed")]
    [SerializeField] Enemy fastParrot;
    [SerializeField] float fastParrotOriginalSpeed;
    [SerializeField] float fastParrotNewSpeed;
    [SerializeField] int fastParrotScoreRequiredToChangeSpeed;

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

    [Header("Armor Parrot Limit")]
    [SerializeField] Enemy armorParrot;
    [SerializeField] int armorParrotOriginalSpawnLimit;
    [SerializeField] int armorParrotLateGameSpawnLimit;
    [SerializeField] int armorLateScoreRequiredToChangeLimit;

    public static EnemyStateChanger instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        fluffCannon.setSpawnLimit(fluffCannonOriginalSpawnLimit);
        normalParrot.setSpawnLimit(normalParrotOriginalSpawnLimit);
        fastParrot.GetComponent<MoveObject>().setSpeed(fastParrotOriginalSpeed);
        bigParrot.setSpawnLimit(bigParrotOriginalSpawnLimit);
        armorParrot.setSpawnLimit(armorParrotOriginalSpawnLimit);
    }

    public void changeDifficulty()
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

        if (ScoreManager.currentScore >= fastParrotScoreRequiredToChangeSpeed)
            fastParrot.GetComponent<MoveObject>().setSpeed(fastParrotNewSpeed);

        if (ScoreManager.currentScore >= armorLateScoreRequiredToChangeLimit)
            armorParrot.setSpawnLimit(armorParrotLateGameSpawnLimit);
    }
}
