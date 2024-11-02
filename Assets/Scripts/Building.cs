using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public int hp = 100;
    public int indexScene;
    public float maxDistance = 0.0f;
    public int curIndex = 0;
    public List<GameObject> Cubes = new List<GameObject>();
    public GameObject Prefab = null;
    public GameObject spawner = null;
    public List<Image> Slots = new List<Image>();
    public List<GameObject> selectSlot = new List<GameObject>();

    private Ray p_ray;
    private RaycastHit p_hit;
    private Vector2 p_rayDirection;
    private Camera m_Camera;
    public bool isMobile;

    private void Start()
    {
        m_Camera = Camera.main;
        p_rayDirection = new Vector2(Screen.width / 2, Screen.height / 2);
        Prefab.SetActive(false);

        for (int i = 0; i < Cubes.Count; i++)
        {
            Slots[i].sprite = Cubes[i].GetComponent<Cube>().Avatar;
        }
    }

    private void Update()
    {
        p_ray = m_Camera.ScreenPointToRay(p_rayDirection);

        if (!isMobile)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                OpenScene.OpenSceneVoid(indexScene);
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
            {
                selectSlot[curIndex].SetActive(false);

                int scroll = (Input.GetAxis("Mouse ScrollWheel") > 0) ? 1 : -1;
                curIndex = (curIndex + scroll + Cubes.Count) % Cubes.Count;

                selectSlot[curIndex].SetActive(true);
            }

            if (Physics.Raycast(p_ray, out p_hit) && p_hit.collider != null)
            {
                if (p_hit.collider.tag == "Cube")
                {
                    Prefab.transform.position = p_hit.collider.transform.position;
                    Prefab.SetActive(true);

                    if (Input.GetMouseButtonDown(1))
                    {
                        PlaceCube();
                    }

                    if (Input.GetMouseButtonDown(0) && p_hit.collider.gameObject.layer != 7)
                    {
                        Destroy(p_hit.collider.gameObject);
                    }
                }
                else
                {
                    Prefab.SetActive(false);
                }
            }
        }
        else
        {
            if (Physics.Raycast(p_ray, out p_hit) && p_hit.collider != null)
            {
                if (p_hit.collider.tag == "Cube")
                {
                    Prefab.transform.position = p_hit.collider.transform.position;
                    Prefab.SetActive(true);
                }
            }
        }
    }

    public void SetBlock()
    {
        if (p_hit.collider.transform.position.x - p_hit.point.x >= 0.5f)
        {
            var pos = new Vector3(p_hit.collider.transform.position.x - 1.0f, p_hit.collider.transform.position.y,
                p_hit.collider.transform.position.z);
            Instantiate(Cubes[curIndex], pos, Quaternion.identity);
        }
        else if (p_hit.collider.transform.position.x - p_hit.point.x <= -0.49f)
        {
            var pos = new Vector3(p_hit.collider.transform.position.x + 1.0f, p_hit.collider.transform.position.y,
                p_hit.collider.transform.position.z);
            Instantiate(Cubes[curIndex], pos, Quaternion.identity);
        }
        else if (p_hit.collider.transform.position.y - p_hit.point.y >= 0.5f)
        {
            var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y - 1.0f,
                p_hit.collider.transform.position.z);
            Instantiate(Cubes[curIndex], pos, Quaternion.identity);
        }
        else if (p_hit.collider.transform.position.y - p_hit.point.y <= -0.5f)
        {
            var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y + 1.0f,
                p_hit.collider.transform.position.z);
            Instantiate(Cubes[curIndex], pos, Quaternion.identity);
        }
        else if (p_hit.collider.transform.position.z - p_hit.point.z >= 0.5f)
        {
            var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y,
                p_hit.collider.transform.position.z - 1.0f);
            Instantiate(Cubes[curIndex], pos, Quaternion.identity);
        }
        else if (p_hit.collider.transform.position.z - p_hit.point.z <= -0.5f)
        {
            var pos = new Vector3(p_hit.collider.transform.position.x, p_hit.collider.transform.position.y,
                p_hit.collider.transform.position.z + 1.0f);
            Instantiate(Cubes[curIndex], pos, Quaternion.identity);
        }
    }

    private void PlaceCube()
    {
        Vector3 pos = p_hit.collider.transform.position;

        if (p_hit.collider.transform.position.x - p_hit.point.x >= 0.5f)
            pos.x -= 1.0f;
        else if (p_hit.collider.transform.position.x - p_hit.point.x <= -0.5f)
            pos.x += 1.0f;
        else if (p_hit.collider.transform.position.y - p_hit.point.y >= 0.5f)
            pos.y -= 1.0f;
        else if (p_hit.collider.transform.position.y - p_hit.point.y <= -0.5f)
            pos.y += 1.0f;
        else if (p_hit.collider.transform.position.z - p_hit.point.z >= 0.5f)
            pos.z -= 1.0f;
        else if (p_hit.collider.transform.position.z - p_hit.point.z <= -0.5f)
            pos.z += 1.0f;

        Instantiate(Cubes[curIndex], pos, Quaternion.identity);
    }

    public void SelectCube(int indexInList)
    {
        if ((Cubes.Count - 1) < indexInList)
            return;

        selectSlot[curIndex].SetActive(false);
        curIndex = (indexInList >= Cubes.Count) ? 0 : indexInList;
        selectSlot[curIndex].SetActive(true);
    }

    public void SpawnEntity(GameObject prefab)
    {
        Instantiate(prefab, spawner.transform.position, Quaternion.identity);
    }

    public void BrokeBlock()
    {
        p_ray = m_Camera.ScreenPointToRay(p_rayDirection);
        if (Physics.Raycast(p_ray, out p_hit) && p_hit.collider != null && p_hit.collider.tag == "Cube")
        {
            if (p_hit.collider.gameObject.layer != 7)
            {
                Destroy(p_hit.collider.gameObject);
            }
        }
    }

    public void ExplosionButton()
    {
        foreach (var tnt in GameObject.FindGameObjectsWithTag("Cube"))
        {
            if (tnt.layer == 3)
            {
                Debug.Log("Explosion triggered");
                tnt.GetComponent<TntExp>().ExplosionButton();
            }
        }
    }
}
