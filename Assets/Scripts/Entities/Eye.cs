using Scripts.Behaviours;
using UnityEngine;

namespace Scripts.Entities
{
    public class Eye : MonoBehaviour , ILook
    {
        private Bounds irisBounds;
        private Vector2 pupilMovementBounds;//holds shape of the oval where pupil can move in
        private Transform pupil;
        void Start()
        {
            pupil = transform.Find("Pupil");
            irisBounds= transform.Find("Iris").gameObject.GetComponent<SpriteRenderer>().bounds;
            var pupilSize = pupil.GetComponent<SpriteRenderer>().bounds.size;
            pupilMovementBounds.x = (irisBounds.size.x-pupilSize.x) / 2;
            pupilMovementBounds.y = (irisBounds.size.y-pupilSize.y) / 2;
        }

        public void LookAtPosition(Vector2 position)
        {
            var direction = position - (Vector2)irisBounds.center;
            var normalDirection = direction.normalized;
            //oval spacial formula is x^2/a^2 + y^2/b^2 =1 
            //check if position is inside the oval
            if ((Mathf.Pow(direction.x, 2) / Mathf.Pow(pupilMovementBounds.x, 2)) +
                (Mathf.Pow(direction.y, 2) / Mathf.Pow(pupilMovementBounds.y, 2)) > 1)
            {
                position.x = (normalDirection.x * pupilMovementBounds.x ) + irisBounds.center.x;
                position.y = (normalDirection.y * pupilMovementBounds.y ) + irisBounds.center.y;
            }
            pupil.transform.position = position;
        }
    }
}
