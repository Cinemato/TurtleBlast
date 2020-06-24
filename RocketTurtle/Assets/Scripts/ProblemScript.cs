using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProblemScript : MonoBehaviour
{
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody2D rb;
        Vector2 velocity;
        Animator anime;

        [SerializeField] float speed;
        [SerializeField] Joystick js;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anime = GetComponent<Animator>();
        }


        void Update()
        {
            //Getting Player Input From Joystick
            Vector2 playerInput = new Vector2(js.Horizontal, js.Vertical);
            velocity = playerInput.normalized * speed;

            //Checking If Player Is Going Forward Or Not
            if (js.Horizontal <= 0)
            {
                anime.SetBool("isGoingForward", false);
            }
            else
            {
                anime.SetBool("isGoingForward", true);
            }

        }

        private void FixedUpdate()
        {
            //Movement Using Rigidbody
            rb.MovePosition(rb.position + (velocity * Time.deltaTime));
        }
    }

    public class MoveObject : MonoBehaviour
    {
        [SerializeField] float speed = 5f;

        Rigidbody2D rb;

        void Start()
        {
            //Moving Object To The Left Direction Using Rigidbody
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-speed, 0);
        }

    }

    public class CloudSpawner : MonoBehaviour
    {

        [SerializeField] GameObject[] clouds;

        //Index To Check Which Cloud To Spawn
        int index;

        private void Start()
        {
            StartCoroutine(spawnCloudCor());
        }

        IEnumerator spawnCloudCor()
        {
            //Non-Stop Coroutine To Spawn Clouds
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 3));
                spawnCloud();
            }
        }

        void spawnCloud()
        {
            index = Random.Range(0, clouds.Length);
            GameObject cloud = Instantiate(clouds[index], transform.position, Quaternion.identity);

            //Spawn Cloud At Random Y Axis Position
            cloud.transform.position = new Vector2(transform.position.x, Random.Range(-3, 3.5f));
        }
    }

    public class PlayerFire : MonoBehaviour
    {
        [SerializeField] GameObject cannonTip;
        [SerializeField] TextMeshProUGUI fireButtonText;

        BulletManager bm;

        private void Start()
        {
            bm = FindObjectOfType<BulletManager>();
        }

        private void Update()
        {
            if (bm.getCurrentProjectileTime() > 0)  //Checking If Shooting Timer Is Finished Or Not
            {
                fireButtonText.SetText(bm.getCurrentProjectileTime().ToString().Substring(0, 3)); //Changing Text
            }

            else
            {
                fireButtonText.SetText("FIRE");
            }

        }


        public void fire()
        {
            if (bm.getCurrentProjectileTime() <= 0)
            {
                Projectile bullet = Instantiate(bm.getCurrentProjectile(), cannonTip.transform.position, Quaternion.identity);  //Spawning Bullet Depending On The Position Of Cannon Tip
                bm.restartCurrentProjectileTime();  //Restating The Shooting Timer Of The Current Projectile
            }
        }
    }

    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rb;
        BulletManager bm;

        //Will Get Input From Bullet Manager
        float speed;
        float timeTilNext;
        int damage;
        GameObject hitVFX;

        void Start()
        {
            //Defining Bullet Manager
            bm = FindObjectOfType<BulletManager>();

            //Getting Different Results From BM Depending On Ammo Used
            switch (tag)
            {
                case "CannonBall":
                    speed = bm.getCannonBallSpeed();
                    timeTilNext = bm.getCannonBallTime();
                    damage = bm.getCannonBallDamage();
                    hitVFX = bm.getCannonVFX();
                    break;

                case "Laser":
                    speed = bm.getLaserSpeed();
                    timeTilNext = bm.getLaserTime();
                    damage = bm.getLaserDamage();
                    hitVFX = bm.getLaserVFX();
                    break;

                case "Ray":
                    speed = bm.getRaySpeed();
                    timeTilNext = bm.getRayTime();
                    damage = bm.getRayDamage();
                    hitVFX = bm.getRayVFX();
                    break;
            }
        }

        void Update()
        {
            //Moving Projectile To The Right Using Rigidbody
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(speed, 0);
        }

        public float getTime()
        {
            //To Be Used In BM Class
            return timeTilNext;
        }

        public int getDamage()
        {
            return damage;
        }

        public GameObject getHitVFX()
        {
            return hitVFX;
        }
    }

    public class BulletManager : MonoBehaviour
    {
        [Header("Cannon Ball")]
        [SerializeField] float cannonBallSpeed = 8f;
        [SerializeField] float timeInSecondsTilNextCannon = 2f;
        [SerializeField] int cannonBallDamage = 5;
        [SerializeField] Projectile cannonBallPrefab;
        [SerializeField] GameObject hitCannonVFX;

        [Header("Laser")]
        [SerializeField] float laserSpeed = 10f;
        [SerializeField] float timeInSecondsTilNextLaser = 0;
        [SerializeField] int laserDamage = 2;
        [SerializeField] Projectile laserPrefab;
        [SerializeField] GameObject hitLaserVFX;

        [Header("Ray Gun")]
        [SerializeField] float raySpeed = 8f;
        [SerializeField] float timeInSecondsTilNextRay = 0.5f;
        [SerializeField] int rayDamage = 2;
        [SerializeField] Projectile rayPrefab;
        [SerializeField] GameObject hitRayVFX;

        [Header("Bullet Icons")]
        [SerializeField] GameObject[] icons;

        //Current Bullet
        Projectile currentProjectile;
        float currentProjectileTime;


        void Start()
        {
            currentProjectile = cannonBallPrefab;

            //Setting Timer To 0 For Start
            currentProjectileTime = 0;

            showIcon();
        }

        void Update()
        {
            currentProjectileTime -= Time.deltaTime;
        }

        public void restartCurrentProjectileTime()
        {
            //Setting Current Projectile Timer Depending On Ammo Type
            switch (currentProjectile.tag)
            {
                case "CannonBall":
                    currentProjectileTime = timeInSecondsTilNextCannon;
                    break;

                case "Laser":
                    currentProjectileTime = timeInSecondsTilNextLaser;
                    break;

                case "Ray":
                    currentProjectileTime = timeInSecondsTilNextRay;
                    break;
            }
        }

        public void showIcon()
        {
            //Showing Icon Of Ammo Type Using Foreach Loop And Tags
            foreach (GameObject icon in icons)
            {
                if (icon.tag.Equals(currentProjectile.tag))
                {
                    icon.SetActive(true);
                }

                else
                {
                    icon.SetActive(false);
                }
            }
        }

        //Current Projectile Getters/Setters
        public void setCurrentProjectile(Projectile projectile)
        {
            //Sets The Current Projectile With Its Shooting Time Using .getTime()
            currentProjectile = projectile;
            currentProjectileTime = projectile.getTime();
        }

        public Projectile getCurrentProjectile()
        {
            return currentProjectile;
        }

        public float getCurrentProjectileTime()
        {
            return currentProjectileTime;
        }

        //Cannon Ball Getters
        public Projectile getCannonBallPrefab()
        {
            return cannonBallPrefab;
        }

        public GameObject getCannonVFX()
        {
            return hitCannonVFX;
        }

        public float getCannonBallSpeed()
        {
            return cannonBallSpeed;
        }

        public int getCannonBallDamage()
        {
            return cannonBallDamage;
        }

        public float getCannonBallTime()
        {
            return timeInSecondsTilNextCannon;
        }


        //Laser Getters
        public Projectile getLaserPrefab()
        {
            return laserPrefab;
        }

        public GameObject getLaserVFX()
        {
            return hitLaserVFX;
        }

        public float getLaserSpeed()
        {
            return laserSpeed;
        }

        public int getLaserDamage()
        {
            return laserDamage;
        }

        public float getLaserTime()
        {
            return timeInSecondsTilNextLaser;
        }

        //Ray Getters
        public Projectile getRayPrefab()
        {
            return rayPrefab;
        }

        public GameObject getRayVFX()
        {
            return hitRayVFX;
        }

        public float getRaySpeed()
        {
            return raySpeed;
        }

        public int getRayDamage()
        {
            return rayDamage;
        }

        public float getRayTime()
        {
            return timeInSecondsTilNextRay;
        }

    }

    public class Cannon : MonoBehaviour
    {
        [SerializeField] GameObject cannon;
        [SerializeField] GameObject cannonTip;
        [SerializeField] GameObject cannonChangeVFX;

        [SerializeField] Sprite normalCannon;
        [SerializeField] Sprite laserCannon;
        [SerializeField] Sprite rayCannon;

        BulletManager bm;
        SpriteRenderer sr;

        private void Start()
        {
            bm = FindObjectOfType<BulletManager>();
            sr = cannon.GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<BulletChange>())
            {
                switch (bm.getCurrentProjectile().tag)
                {
                    case "CannonBall":
                        sr.sprite = normalCannon;
                        break;

                    case "Laser":
                        sr.sprite = laserCannon;
                        break;
                    case "Ray":
                        sr.sprite = rayCannon;
                        break;
                }

                Vector2 vfxPosition = new Vector2(cannonTip.transform.position.x - 0.2f, cannonTip.transform.position.y);
                GameObject vfx = Instantiate(cannonChangeVFX, vfxPosition, Quaternion.identity);
                vfx.transform.parent = cannonTip.transform;

                Destroy(vfx, 2f);
            }
        }
    }

    public class BulletChange : MonoBehaviour
    {
        BulletManager bm;

        private void Start()
        {
            bm = FindObjectOfType<BulletManager>();

            //Destroying Egg After 4 Seconds
            Destroy(gameObject, 4f);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Setting Current Projectile Depending On The Taken Egg

            if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                switch (tag)
                {
                    case "CannonBall":
                        bm.setCurrentProjectile(bm.getCannonBallPrefab());
                        break;

                    case "Laser":
                        bm.setCurrentProjectile(bm.getLaserPrefab());
                        break;

                    case "Ray":
                        bm.setCurrentProjectile(bm.getRayPrefab());
                        break;
                }

                bm.showIcon(); //Showing Icon Of New Ammo
                Destroy(gameObject);  //Destroying Egg After Collision With Player
            }
        }
    }

    public class EggSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] eggs;
        [SerializeField] float timeTilNextEgg = 30f;

        BulletManager bm;

        private void Start()
        {
            bm = FindObjectOfType<BulletManager>();

            StartCoroutine(spawnEgg());
        }

        IEnumerator spawnEgg()
        {
            //Coroutine That Spawns Eggs Forever
            while (true)
            {
                yield return new WaitForSeconds(timeTilNextEgg);
                spawnNextEgg();
            }
        }

        void spawnNextEgg()
        {
            GameObject eggIndex = eggs[Random.Range(0, eggs.Length)];  //Setting Index To A Random Egg From Array
            while (eggIndex.tag == bm.getCurrentProjectile().tag)  //Checking If The Chosen Egg Is The Same As The Current Ammo
            {
                eggIndex = eggs[Random.Range(0, eggs.Length)];  //If So Then Chaning It To Another Random Egg From Array
            }

            GameObject egg = Instantiate(eggIndex, transform.position, Quaternion.identity);
            egg.transform.position = new Vector2(Random.Range(-8f, 8f), transform.position.y);  //Spawning Chosen Egg To Random X Axis Position Using Egg Index
        }
    }

    public class DayNight : MonoBehaviour
    {
        [SerializeField] float timeTilNextCycle = 180f; //Seconds

        public static Animator anime;
        void Start()
        {
            anime = GetComponent<Animator>();

            StartCoroutine(DayCycle());
        }


        IEnumerator DayCycle()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeTilNextCycle);
                cycle();
            }
        }

        void cycle()
        {
            if (anime.GetBool("isDay"))
            {
                anime.SetBool("isDay", false);
            }

            else
            {
                anime.SetBool("isDay", true);
            }
        }
    }

    public class ObjectRemover : MonoBehaviour
    {
        [SerializeField] bool removeBullets;
        [SerializeField] bool removeEnemies;
        [SerializeField] bool removeClouds;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Destroying Objects Depending On Boolean Input
            if (removeBullets)
            {
                if (collision.gameObject.GetComponent<Projectile>())
                {
                    Destroy(collision.gameObject);
                }
            }

            if (removeClouds)
            {
                if (collision.gameObject.CompareTag("Cloud"))
                {
                    Destroy(collision.gameObject);
                }
            }

            if (removeEnemies)
            {
                if (collision.gameObject.GetComponent<Enemy>())
                {
                    EnemySpawner.count--;
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    public class FireFlySpawner : MonoBehaviour
    {
        [SerializeField] GameObject fireFlyPrefab;
        [SerializeField] float timeTilNextFireFly = 5f;

        void Start()
        {
            StartCoroutine(spawnFireFliesCor());
        }

        void spawnFireFlies()
        {
            GameObject fireFly = Instantiate(fireFlyPrefab, transform.position, Quaternion.identity);
            fireFly.transform.position = new Vector2(transform.position.x, Random.Range(3.7f, -3.7f));
        }

        IEnumerator spawnFireFliesCor()
        {
            while (true)
            {
                if (!DayNight.anime.GetBool("isDay"))
                {
                    yield return new WaitForSeconds(timeTilNextFireFly);
                    spawnFireFlies();
                }

                else
                {
                    yield return null;
                }
            }
        }
    }

    public class Enemy : MonoBehaviour
    {
        [SerializeField] int hp = 5;
        [SerializeField] int damage;
        [SerializeField] GameObject deathVFX;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Projectile>())
            {
                Projectile projectile = collision.gameObject.GetComponent<Projectile>();
                GameObject hitVFX = Instantiate(projectile.getHitVFX(), collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(hitVFX, 2f);

                recieveDamage(projectile.getDamage());
            }

            else if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                GameObject explodeVFX = Instantiate(deathVFX, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                explode();
            }
        }

        void recieveDamage(int damage)
        {
            hp -= damage;

            if (hp <= 0)
            {
                explode();
            }
        }

        void explode()
        {
            GameObject explodeVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(explodeVFX, 2f);
            EnemySpawner.count--;
            Destroy(gameObject);
        }
    }

    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] Enemy enemyPrefab;
        [SerializeField] float timeTilEachSpawn = 3;
        [SerializeField] int maxEnemyCount = 10;

        public static int count = 0;

        private void Start()
        {
            StartCoroutine(spawnEnemies());
        }

        IEnumerator spawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeTilEachSpawn);
                spawnEnemy();
            }
        }

        void spawnEnemy()
        {
            if (count < maxEnemyCount)
            {
                Vector2 enemyPosition = new Vector2(transform.position.x, Random.Range(-4, 4));
                Enemy enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);

                count++;
            }
        }
    }
}