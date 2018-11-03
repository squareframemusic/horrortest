using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class CrazyStuffCollider : MonoBehaviour {

    public GameObject FPSPlayer;
 //   private GlitchEffect glitchyCameraEffect;

    public GameObject monsterPreb;
    public Vector3 monsterSpawnPoint01 = new Vector3(-11.777f, 0.789f, 0.07f);
    public bool canSpawn = true;


	// Use this for initialization
	void Start () {
//        glitchyCameraEffect = GetComponent<GlitchEffect>();
	}

	void OnTriggerEnter()
	{
        if (canSpawn == true)
        {
            canSpawn = false;

            GameObject.Find("FirstPersonCharacter").GetComponent<GlitchEffect>().enabled = true;
            //        glitchyCameraEffect.enabled = !glitchyCameraEffect.enabled;

            MonsterSpawn(monsterSpawnPoint01, 180);

            GameObject.Find("FirstPersonCharacter").GetComponent<PostProcessingBehaviour>().enabled = true;

            Debug.Log("collision");
        }
        
	}

	private void OnTriggerExit(Collider other)
	{
        canSpawn = true;
        GameObject.DestroyObject(GameObject.FindGameObjectWithTag("enemy"));

        GameObject.Find("FirstPersonCharacter").GetComponent<GlitchEffect>().enabled = false;
        GameObject.Find("FirstPersonCharacter").GetComponent<PostProcessingBehaviour>().enabled = false;
	}
	

    // Update is called once per frame
	void Update()
    {
//        if (Input.GetKeyDown("g"))
//        {
            //the ! is a toggle. It means "make it whatever it isn't right now."
//            glitchyCameraEffect.enabled = !glitchyCameraEffect.enabled;
//        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("wait is over");
    }

    void MonsterSpawn (Vector3 place, float rot)
    {
        Debug.Log("Monster Spawn Called");
        GameObject monsterClone = (GameObject)Instantiate(monsterPreb, place, Quaternion.identity * Quaternion.Euler(0, rot, 0));
        StartCoroutine(Test());
//        DestroyObject(monsterClone);

    }
}
