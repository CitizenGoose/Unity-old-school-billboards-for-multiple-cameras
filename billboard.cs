 /*
 Attach this to all billboard objects
 */
 using UnityEngine;
 using System.Collections;
 
 public class billboard : MonoBehaviour {
     public Sprite fr, bc, lf, ri;
      public SpriteRenderer theSR;
     void OnEnable() {
         CameraPreRender.onPreCull += MyPreCull;
     }
 
     void OnDisable() {
         CameraPreRender.onPreCull -= MyPreCull;
     }
 
     void MyPreCull() {
         //we want to look back
         Vector3 difference = Camera.current.transform.position - transform.position;
         difference.y = 0;
         transform.LookAt(transform.position - difference, Camera.current.transform.up);

         var dir = Camera.current.transform.position - transform.position;
          var enemyAngle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
          if (enemyAngle < 0.0f){
              enemyAngle += 360;
              }
          
          
          // you can mess about with this last lines. You can add more angles, chnage them, etc.
          if (enemyAngle >= 315f || enemyAngle < 45f){theSR.sprite = ri;}
              
          else if (enemyAngle >= 45f && enemyAngle < 135f){theSR.sprite = fr;}
              
          else if (enemyAngle >= 135f && enemyAngle < 225f){theSR.sprite = lf;}
              
          else if (enemyAngle >= 225f && enemyAngle < 315f){theSR.sprite = bc;} 
          
     }
 }
