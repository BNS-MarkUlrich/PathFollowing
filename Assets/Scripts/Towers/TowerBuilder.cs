using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Opdrachten
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private Tower[] _towers;
        [SerializeField] private LayerMask _floorLayer;

        private GameObject _selectedTower;
        public GameObject[] prefabs;

        public new MeshRenderer renderer;

        public Vector3 worldPositionRaycast;

        // wellicht zijn er nog meer variabelen nodig dan in het script tot nu toe gedefinieerd zijn.

        private void Start()
        {
            _floorLayer = ~_floorLayer;
        }

        void Update()
        {
            // Het eerste gedeelte van de if statement is eigenlijk om deze class makkelijk te kunnen testen
            // uiteindelijk wil je dat de SelectTower functie wordt aangeroepen zodat deze class gaat doen wat ie moet doen.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, 1000, ~_floorLayer))
            {
                worldPositionRaycast = hitData.point;
            }

            
            if (_selectedTower == null)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    //SelectTower(_towers[0]);
                    SelectTower(prefabs[0]);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    //SelectTower(_towers[1]);
                    SelectTower(prefabs[1]);
                }
            }
            else
            {
                UpdateTowerPosition();
                if (Input.GetKeyDown(KeyCode.X))
                {
                    DeselectTower();
                }
                else if (ValidateLocation() && Input.GetMouseButtonDown(0))
                {
                    PlaceTower();
                }
            }
        }
        public void SelectTower(GameObject tower)
        {
            // instantieer een toren, maar zorg dat deze nog niet werkt
            // zet de _selectedTower variable
            GameObject obj = Instantiate<GameObject>(tower);
            //obj.SetActive(false);
            obj.GetComponent<Wrapper>().ToggleComponents();
            //Material mat = renderer.material;
            //mat.color -= new Color(0f, 0f, 0f, 3f);

            _selectedTower = obj;
        }

        private void PlaceTower()
        {
            // update de kleur van de toren terug naar de originele kleur
            // zet de toren 'aan'
            // zet de _selectedTower variabel weer terug naar null (letop: niet 0)!
            // overige mogelijkheden:
            // - ParticleEffect afspelen
            // - geluid afspelen
            // - geld verekenen o.i.d.

            //_selectedTower.SetActive(true);
            _selectedTower.GetComponent<Wrapper>().ToggleComponents();
            //Instantiate<GameObject>(_selectedTower);
            _selectedTower = null;
        }
        private void UpdateTowerPosition()
        {
            // update de positie van de toren naar de muispositie
            if (_selectedTower != null)
            {
                _selectedTower.transform.position = new Vector3(worldPositionRaycast.x, worldPositionRaycast.y, worldPositionRaycast.z);
            }
        }
        private bool ValidateLocation()
        {
            // check of de toren collide met objecten.
            // kan de toren niet geplaatst worden?
            // verander 'm dan van kleur (naar rood bijv)
            // Dit kun je doen door de kleur van het material aan te passen
            // kan die wel geplaatsts worden (maak m dan zijn origene kleur, of groen, of een anere kleur)


            return true;
        }

        public void DeselectTower()
        {
            // verwijder de toren


            Destroy(_selectedTower);
        }
    }
}