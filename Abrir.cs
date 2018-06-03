using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Abrir : MonoBehaviour {

	// Use this for initialization
	void Start () {

        DirectoryInfo dir = new DirectoryInfo(@"Assets/Proyectos");
        var index = 0;
        foreach(FileInfo file in dir.GetFiles())
        {
            if (file.Extension != ".meta")
            {

                index = index + 1;
                Vector3 v = new Vector3(0, index * 30, 0);
                var button = Instantiate(Resources.Load<GameObject>("Abrir"), v, Quaternion.identity);

                button.GetComponentInChildren<Text>().text = Path.GetFileNameWithoutExtension(file.Name);


                button.transform.SetParent(GameObject.Find("Canvas").transform, false);
                button.GetComponent<Button>().onClick.AddListener(delegate { open(Path.GetFileNameWithoutExtension(file.Name)); });

            }

        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void open(string a) {
        SceneManager.LoadScene("ARNewscene");
        GameObject Name = GameObject.Find("Name");
        Nombre nombre = Name.GetComponent<Nombre>();
        Nombre.proyecto = a;
    }
}
