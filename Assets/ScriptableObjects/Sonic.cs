using UnityEngine;

[CreateAssetMenu(fileName = "Sonic", menuName = "Sonic", order = 1)]
public class Sonic : ScriptableObject
{
    [SerializeField]
    float maxSpeed; //Velocità massima che sonic può raggiungere.
    [SerializeField]
    float midSpeed; //Velocità media, usato principalmente per le animazioni. Non viene mai utilizzato, per ora...
    [SerializeField]
    float slowSpeed; //Velocità lenta, non ho idea a cosa possa servire.

    [SerializeField]
    float jumpMaxHeight; //Altezza massima del salto raggiungibile con una lunga pressione del tasto di salto.

    [SerializeField]
    float jumpMinHeight; //Altezza minima del salto raggiungibile con un leggero tocco del tasto di salto.

    [SerializeField]
    float jumpPower; //Quanta forza sprigionano le gambe di sonic per iniziare il salto. UN VALORE > 80 TRASFORMA SONIC IN UN ASTRO-MISSILE.

    [SerializeField]
    AudioClip jumpSoundEffect; //Boing boing.

    [SerializeField]
    AudioClip shoeBreak; //Crr crr

    [SerializeField]
    AudioClip getLifeEffect; //Pa parapa pa pa ra papa

    [SerializeField]
    int rings = 0; //Numero di ring collezionati.

    [SerializeField]
    int lives = 0; //Numero di vite.

    public bool UpdateRing { get; set; } //Serve a R_Displayer per aggiornare il contatore di ring. True aggiorna, False non aggiorna (obv).
    public float SlowSpeed
    {
        get
        {
            return slowSpeed;
        }
    } 

    public float MidSpeed
    {
        get
        {
            return midSpeed;
        }
    }

    public AudioClip ShoeBreak
    {
        get
        {
            return shoeBreak;
        }
    }

    public AudioClip JumpSoundEffect
    {
        get
        {
            return jumpSoundEffect;
        }
    }

    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }
    }

    public float JumpMaxHeight
    {
        get
        {
            return jumpMaxHeight;
        }
    }

    public float JumpPower
    {
        get
        {
            return jumpPower;
        }
    }

    public float JumpMinHeight
    {
        get
        {
            return jumpMinHeight;
        }
    }

    public bool IsJumping { get; set; } = false; //Sonic sta saltando?

    public Vector3 Velocity { get; set; } //Vettore velocità,  ti dice la direzione in cui sonic si sta muovendo

    public float Acceleration { get; set; } // Muovendosi accumula accelerazione che lo fa andare ancora più forte

    public bool LifeUp { get; set; } //Serve a L_Displayer per aggiornare il numero delle vite.

    public AudioClip GetLifeEffect
    {
        get
        {
            return getLifeEffect;
        }
    } 

    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }

    public int Rings
    {
        get
        {
            return rings;
        }
        set
        {
            UpdateRing = true;
            rings = value;
            if (rings % 100 == 0)
            {
                Lives++;
                LifeUp = true;
            }
        }
    }

    public bool IsGrounded { get; set; } //Sonic è a terra?

    public bool StartFalling { get; set; } //Inizia la caduta in salto.
}
