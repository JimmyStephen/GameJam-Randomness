using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float MovementSpeed = 25;
    [SerializeField, Range(0, 100)] float JumpForce = 50;
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] public Resource Health;
    [SerializeField] public Resource Mana;
    [SerializeField] CharacterController Controller;
    [SerializeField] List<GameObject> Spells;
    [SerializeField] List<GameObject> SpellLocations;


    [HideInInspector] public float animationTimer = 0;
    private Dictionary<string, float> SpellCooldowns = new();
    private List<string> keys = new();
    private Vector3 Velocity;

    private void Start()
    {
        Spells.ForEach(s => {
            SpellCooldowns.Add(s.GetComponent<Spell>().name, 0);
            keys.Add(s.GetComponent<Spell>().name);
        });
    }
    // Update is called once per frame
    void Update()
    {
        DecrementTimers();
        //CastSpell();
        Movement();
    }

    void Movement()
    {
        if(animationTimer > 0)
        {
            Controller.Move(new(0, Gravity * Time.deltaTime, 0));
            return;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Controller.Move(MovementSpeed * Time.deltaTime * move);

        //Rotate
        //if (move != Vector3.zero)
        //    gameObject.transform.forward = move;

        bool tempGrounded = Controller.isGrounded;
        Debug.Log("Grounded?: " + tempGrounded);
        Debug.Log("Jump?: " + Input.GetButtonDown("Jump"));

        if (tempGrounded)
            Velocity.y = 0.5f;

        if (Input.GetButtonDown("Jump") && tempGrounded)
            Velocity.y += Mathf.Sqrt(JumpForce * Mathf.Abs(Gravity));

        Velocity.y += Gravity * Time.deltaTime;
        Controller.Move(Velocity * Time.deltaTime);
    }

    void DecrementTimers()
    {
        keys.ForEach(key => { SpellCooldowns[key] -= Time.deltaTime; });
        animationTimer -= Time.deltaTime;
    }


    //void CastSpell()
    //{
    //    Spells.ForEach(spell => {
    //        if(spell.TryGetComponent(out Spell s))
    //        {
    //            if (Input.GetKey(s.CastSpellKey))
    //            {
    //                if(s.CheckCanCast(Mana.GetCurrent(), SpellCooldowns[s.name], animationTimer))
    //                {
    //                    s.CastSpell(SpellLocations.First(sl => sl.name == s.name), Mana, SpellCooldowns[s.name], animationTimer);
    //                }
    //            }
    //        }
    //    });
    //}

    /// <summary>
    /// Create the spell after a delay
    /// </summary>
    /// <param name="owner">Who created the object</param>
    /// <param name="location">Where to create the object</param>
    /// <param name="spawnObject">What to spawn</param>
    /// <param name="delay">How long the delay is</param>
    /// <returns></returns>
    public IEnumerator SpawnAfterDelay(GameObject owner, GameObject location, GameObject spawnObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        bool right = owner.transform.localScale.x > 0;
        float angle = (right) ? 0 : 180;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject temp = Instantiate(spawnObject, location.transform.position, rotation);
        temp.GetComponent<Spell>().Owner = owner;
    }
}
