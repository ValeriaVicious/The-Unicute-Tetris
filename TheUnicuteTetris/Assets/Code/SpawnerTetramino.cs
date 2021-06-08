using UnityEngine;


namespace TheUnicuteTetris
{
    internal sealed class SpawnerTetramino : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject[] _groupsOfTetramino;

        #endregion


        #region UnityMethods

        private void Start()
        {
            SpawnNextGroup();
        }

        #endregion


        #region Methods

        public void SpawnNextGroup()
        {
            int i = Random.Range(0, _groupsOfTetramino.Length);
            Instantiate(_groupsOfTetramino[i],
                transform.position, Quaternion.identity);
        }

        #endregion
    }
}

