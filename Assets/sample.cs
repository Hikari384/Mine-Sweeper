using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sample : MonoBehaviour
{
    [SerializeField] private int _count = 5;

    int a = 0;
    GameObject[] _obj;
    // Start is called before the first frame update
    void Start()
    {
        _obj = new GameObject[_count];
        for ( var i = 0; i < _count; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;
            //objを、このスクリプトを実行しているゲームオブジェクトの子にする

            var image = obj.AddComponent<Image>();
            if(i == 0) { image.color = Color.red; }
            else { image.color = Color.white; }
            _obj[i] = obj;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && a > 0)
        {
            _obj[a].GetComponent<Image>().color = Color.white;
            a--;
            _obj[a].GetComponent<Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && a < _count - 1 )
        {
            _obj[a].GetComponent<Image>().color = Color.white;
            a++;
            _obj[a].GetComponent<Image>().color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(_obj[a]);
         }
    }
}
/* 　赤坂先生サンプル
 * 　
 * private Image[] _images;
 * private int _selectedIndex = 0;
 * 
    void start(){

        _images = new _Image[5];
        for(var i = 0; 0 < images_Length; i++){
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;

            var image = obj.AddComponent<Image>();
            _images[i] = image;
        }
    
    private void Update(){
        
        if(Input.GetKeyDown(KeyCode.LeftArrow){
            _selectedIndex--;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow){
            _selectedIndex++;
        }
        
        if(Input.GetKeyDown(KeyCode.Space){

            if(_images[_selectedIndex]){
                Destroy(_images[_selectedIndex];
            }
        }

        for(var i = 0; i < _images.Length ; i++){
            if(i == _selectedIndex){_images[i].color = Color.red;}
            else{_images[i].color = Color.white;}
        }   


*/