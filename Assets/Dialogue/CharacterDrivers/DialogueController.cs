using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DialogueController : MonoBehaviour {

    public float letterPause;
    public AudioClip[] typeSound;
    public string message;
    public SkinnedMeshRenderer FaceRef;
    public Material[] FaceArray;
    Text textComp;
    AudioSource Audio;
    public int pauseTime;

    public TextAsset textFile;
    public string[] textLines;
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));

        }
        Audio = GetComponent<AudioSource>();
        textComp = GetComponent<Text>();
       
        Debug.Log(message);
        textComp.text = "";
        StartCoroutine(TypeText(message));

    }
    void ContinueDiag(string NextSet){

    }  
    private IEnumerator TypeText(string lineOfText)
    {
        int count = 0;
        //Each new line of dialogue
        foreach (string Lines in textLines)
        {
            textComp.text = "";
            message = Lines;
           
            //if (count == 2)
            //{

            //    textComp.text = "";
            //    count = 0;
            //}
            //else
            //{
                foreach (char letter in message.ToCharArray())
                {
                    int temp = Random.Range(0, 5);
                    textComp.text += letter;
                    Audio.clip = typeSound[temp];
                    FaceRef.material = FaceArray[temp];
                    Audio.Play();

                    yield return new WaitForSeconds(letterPause);
                }
                FaceRef.material = FaceArray[5];
                yield return new WaitForSeconds(1.5f);
            //}
            //if (message.Contains("..."))
            //{
                FaceRef.material = FaceArray[7];
        //    }
        //    count += 1;
        }

        yield return new WaitForSeconds(1.5f);
        }

      
    }



