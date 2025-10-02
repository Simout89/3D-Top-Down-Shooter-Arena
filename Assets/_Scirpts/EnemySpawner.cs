using UnityEngine;
using UnityEngine.Serialization;

namespace _Scirpts
{
    public class EnemySpawner: MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float cameraOffset = -3f;
        [SerializeField] private float heightPlaneOffset = 3f;
        [SerializeField] private Transform plane;
        
        public Enemy SpawnRandomEnemy(Enemy enemy, Transform playerTranform)
        {
            Enemy newEnemy = Instantiate(enemy, GetRandomPointOutside(), Quaternion.identity, transform);

            newEnemy.SetPlayerTransform(playerTranform);
            
            return newEnemy;
        }
        
        private Vector3 GetRandomPointOutside()
        {
            float distance = plane.position.y + heightPlaneOffset - camera.transform.position.y;

            Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, distance));
            Vector3 topRight   = camera.ViewportToWorldPoint(new Vector3(1, 1, distance));

            int side = Random.Range(0, 4);

            float x = (side == 0) ? bottomLeft.x - cameraOffset :
                (side == 1) ? topRight.x + cameraOffset :
                Random.Range(bottomLeft.x, topRight.x);

            float z = (side == 2) ? bottomLeft.z - cameraOffset :
                (side == 3) ? topRight.z + cameraOffset :
                Random.Range(bottomLeft.z, topRight.z);

            return new Vector3(x, plane.position.y + heightPlaneOffset, z);
        }

    }
}