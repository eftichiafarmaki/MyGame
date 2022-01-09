// AUTO EINAI TO SCRIPT GIA THN MPALA STO EPIPEDO 1. EXW DHMIOURGHSEI 4 SCRIPTS SUNOLIKA, ENA GIA KATHE EPIPEDO. TA SCRIPTS AUTA EINAI IDIA ME MONI DIAFORA TIN ALLAGI TAXUTHTAS THS MPALAS
//GIA NA AUKSISW THN DUSKOLIA SE KAPOIA LEVEL. OPOTE EXEI SXOLIASTEI TO ENA APO TA 4 SCRIPTS.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball1 : MonoBehaviour
{
    //thelw gia na emploutisw tin kinish ths mpalas mou kai na mporoun na tis dinoun oi raketes mia "wthisi" pros ta panw. Gia auto dinw se auto to script arxika prosvasi stis raketes mou
    public GameObject PaddleLeft;
    public GameObject PaddleRight;

    private AudioSource snd; 

    private Rigidbody2D rb; //prosvasi sto Rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();

        snd = GetComponent<AudioSource>();


       
        PaddleLeft = GameObject.Find("PaddleLeft");
        PaddleRight = GameObject.Find("PaddRight");

        Count_Score.canAddScore = true;
        StartCoroutine (Pause ()); //xekinaei tin parakatw function (IEnumerator Pause();), perimenei duo deuterolepta meta tin ekkinisi tou game ki epeite xekinaei h kinhsh ths mpalas
    }

    // Update is called once per frame
    void Update()
    {

        //thelw na thesw ena orio mexri to opoio mporei na ftasei h mpala kai h opoia molis tha ftanei se auto tha auksanei to score kata 1 gia ton antistoixo paikti.
        //Ousiastika thelw ena "terma" sto opoio tha prepei na skorarei kathe paiktis
        //Sti sunexeia tha prepei na epistrefei sto kentro, diladi stin arxiki ths thesi

        if (Mathf.Abs(this.transform.position.x) >= 23f) //Vriskw se poia thesi vriksetai h mpala ektos kameras deksia kai aristera ston aksona tou x (thesi 23) kai me tin if tou lew oti an to kseperasei 
                                                         // to score tha prepei na auxanetai kata 1. Me to Mathf.Abs pairnw mono tin apoluti timh gia na min grafw kwdika dipli ora gia to x kai -x. 
        {

            Count_Score.canAddScore = true; //(tsekarete to Count_Score script)

            this.transform.position = new Vector3 (0f, 0f, 0f); //me auton tropo an h mpala kseperasei to parapanw orio, tote tha epistrefei sto kentro (reset)
            StartCoroutine(Pause ()); //ektos apo tin pausi stin ekkinisi tis mpalas theloume na kanei kai tin pausi epeita apo kathe scorarisma
        }

    }

    IEnumerator Pause()    //gia na ginei ligotero provlepsimo to paixnidi kai ligo pio endiaferon ithela h mpala mou na xekanaei apo tuxaia kateuthinsi kathe fora kai prin ksekinisei na kanei mia 
                           // polu mikri pausi twn 2-3 deuteroleptwn wste na proetoimastoun oi paiktes
    {                      //gia na mporei h mpala na kinithei me mia tuxaia kateuthinsi kathe fora pou xekinaei (diagwnia, dexia, aristera, katw diagwnia, k.l.p)

        int directionX = Random.Range(-1, 2); //dhlwnoume tuxaiothta (random) gia to x me euros estw apo to -1 mexri to 2 xwris na theloume omws to 0
        int directionY = Random.Range(-1, 2); //antistoixa gia to y

        if (directionX == 0)
        {
            directionX = 1;
        }

        rb.velocity = new Vector2(0f, 0f); //otan mpainoume stin Pause() h arxiki taxuthta tha prepei na einai 0

        yield return new WaitForSeconds(2);  //etsi h mpala stamataei kathe fora, otan erxetai stin kentriki ths thesi kai prin xekinisei to game, gia duo deuterolepta 

        rb.velocity = new Vector2(16f * directionX , 11f * directionY);

    }

    //edw tha allaxw to velocity ths mpalas mou kathe fora pou "xtupaei" (sugkroush) ena antikeimeno
    void OnCollisionEnter2D (Collision2D hit)
    {

        if (hit.gameObject.name == "PaddleLeft") { 

            snd.Play ();

            //prepei na tsekarw prwta to pws kineitai h raketa. An kineitai pros ta panw (gia na dwsei wthisi stin mpala pros ta panw), an kineitai pros ta katw (gia na dwsei pros ta katw) h an
            //den kineitai katholou wste na paei eutheia ousiastika

         if (PaddleLeft.GetComponent<Rigidbody2D> ().velocity.y > 0.5f) //tsekarw an kineitai thetika (pros ta panw)
            {
                rb.velocity = new Vector2(11f, 11f);

            } 
            else if (PaddleLeft.GetComponent<Rigidbody2D>().velocity.y < -0.5f) //an kineitai arnitika (pros ta katw)
            {
                rb.velocity = new Vector2(11f, -11f);
            }
            else  //an den kineitai
            {
                rb.velocity = new Vector2(16f, 0f); //orizw ligo megaluterh thn taxuthta edw

            }
         }
          

        if (hit.gameObject.name == "PaddleRight")
        {
            snd.Play();

            //antistoixa gia tin deksia raketa
            if (PaddleRight.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(-11f, 11f);

            }
            else if (PaddleRight.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(-11f, -11f);
            }
            else
            {
                rb.velocity = new Vector2(-16f, 0f);

            }
        }


    }
    
}
