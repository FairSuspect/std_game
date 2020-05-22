using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
	
	public GameObject coin;
	//public GameObject brick;
    
    void Awake()
    {
		
		
		//coin = new GameObject("Coin");
		//BoxCollider2D bc;
		
		
		/*coin.transform.position = new Vector2 (0, 0);
		bc = coin.AddComponent<BoxCollider2D>() as BoxCollider2D;
		bc.size = new Vector2 (0.25f, 0.25f);
		bc.isTrigger = true;
		
		
		
		SpriteRenderer sprRend;
        sprRend = coin.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sprRend.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);
		sprRend.sprite= */

       // BoxCollider2D bc;
        //bc = coin.AddComponent<BoxCollider2D>() as BoxCollider2D;
        //bc.size = new Vector2(1.3f, 1.3f);
        //bc.isTrigger = true;
		
		
        
    }
    // Start is called before the first frame update
    void Start()
    { 
		
		
		/*for (int y = -7; y < 7; y++) {
			for (int x = -13; x < 13; x++) {
				Instantiate(brick, new Vector3(x, y, 0), Quaternion.identity);
        } 
    
} */
		
    }

	/*void OnTriggerEnter2D(Collider2D col)
    {
		Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

	}
    // private void OnCollisionExit(Collision other) {
    //     objects[0].GetComponent<SpriteRenderer>().color = Color.red;
    // }
    // Update is called once per frame*/
    void Update()
    {
		/*coin.transform.Translate(spriteMove, 0.0f, 0.0f);

        if (coin.transform.position.x < -4.0f)
        {
            // move GameObject2 to the right
            spriteMove = 0.1f;
        }*/

      //  float translation = Input.GetAxis("Vertical") * speed;
		
      //  float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
       // Debug.Log(translation);
	   
        
    }
    // IEnumerator inst (){
    //     yield return new WaitForSeconds (1);
    //     Instantiate(objects[0], objects[0].transform.position, objects[0].transform.rotation);
    // }
    // IEnumerator instDown (){
    //     yield return new WaitForSeconds (1);
    //     Instantiate(objects[2], objects[2].transform.position, objects[0].transform.rotation);
    // }
}
