
    using UnityEngine;

    public class HPBar : MonoBehaviour
    {
        [SerializeField] private GameObject maxHPBar;
        [SerializeField] private GameObject currHPBar;

        public void UpdateHPBar(float currentPercentHP)
        {
            Vector3 scale = currHPBar.transform.localScale;
            scale.x = currentPercentHP;
            currHPBar.transform.localScale = scale;
        }
    }
