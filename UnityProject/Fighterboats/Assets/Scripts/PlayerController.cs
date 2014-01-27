using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		//hook to let us change movement mulpiplier in Unity UI
		public float speed;
		private int collected;
		public GUIText countText;
		public GUIText winText;
		
		void Start ()
		{
				collected = 0;
				
				countText.text = "Count :" + collected.ToString ();
				winText.text = "";
		}

		//check every frame for player input
		//apply movement every frame to player

		//update right before frame draw?
		//fixed update right before phys calcs
		void FixedUpdate ()
		{
				//if (networkView.isMine)
				{
			
						//command ' on symbol for help on that symbol
						//Input for input
						float mHoriz = Input.GetAxis ("Horizontal");
						float mVert = Input.GetAxis ("Vertical");

						//apparently refers to the rigid body of this Player object? check to see if name is same ('rigidbody')
						//rigidbody.AddForce (mHoriz, mVert, 0);
						Vector3 move = new Vector3 (mHoriz, 0, mVert);

						//time.deltaT make this vary 'automatically' depending on time between frame draws
						rigidbody.AddForce (move * speed * Time.deltaTime);
				}
		}

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag == "Pickup") {
						other.gameObject.SetActive (false);
						collected++;
						
						countText.text = "Count :" + collected.ToString ();
						
						if (collected >= 5) {
								winText.text = "Winnar";
						}
				}
		}
}
