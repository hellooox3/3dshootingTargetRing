using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shootTarget : MonoBehaviour
{
    // Start is called before the first frame update
    //get the position of the cursor
    //get the radius 
    //calculate the distance 
    //display decal 
    //display score

    //standard 
    /*
    //经手工测算,此靶标的半径R约为1.2
    //10环至5环共有5个区间,每环之间的区间距离为1.2/5=0.24
    //每个小环内又再细分为8个小区间(10减去2个相邻整数环),得到0.24/8=0.03
    
     * x <= 0.0            10环
     * 0.0 < x <= 0.24     9环
     * 0.24 < x <= 0.48    8环
     * 0.48 < x <= 0.72    7环
     * 0.72 < x <= 0.96    6环
     * 0.96 < x <= 1.2     5环
     */
    
    //算法部分--计算打靶环数
    /*
     * 1.得到靶击的位置(x,y)坐标
     * 2.计算靶击位置到原点的距离R1 R^2 = X^2 + Y^2
     * 3.将R1与上表各环数数据相比较,得到该靶击点的大环数(例,8环? 5环?)
     * 4.用该环数的最大值减去该R1值得到D
     * 5.用此D/0.03得到靶击点小环数R2
     * 6.将R1与R2相加得到具体环数
     */
    
    //public Material bulletHoleMaterial;
    public GameObject bulletHolePrefab;
    //private float r1;//大环-整数环
    //private float r2;//小环-小数环
    private float r; //大环 + 小环数
    private float rTemp1;//暂时保存x^2+y^2的值，以便求取根号值
    private float rTemp2;//暂时保存大环中的最大临界值 - 获得的r值
    private float rTemp3;//暂时保存求取后的根号半径值r
    private float rTemp4;//暂时保存rTemp2数值/0.03后的四舍五入值 
    //private float d2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                //计算环数
                rTemp1 = hit.point.x * hit.point.x + hit.point.y * hit.point.y;
                rTemp3 = Mathf.Sqrt(rTemp1);
                //获取环整数
                //r1 = GetOutterRing(d1);
                //r2 = GetInnerRing(r1);
                r = GetTargetRingNumber(rTemp3);
                GameObject bulletHole = GameObject.Instantiate(bulletHolePrefab, hit.point, transform.rotation) as GameObject;
            }
        }
    }
    
    //求取环数 - 大环数+小环数
    float GetTargetRingNumber(float source)
    {
        if (source <= 0.0)
        {
            Debug.Log(source);
            Debug.Log("环数：" + r);
            //r1 = 0.0f;
            return 10.0f;
            
        }
        else if (source <= 0.24) // 0.0 < source <= 0.24 9环
        {
            Debug.Log(source);
            //r1 = 9.0f;
            rTemp2 = 0.24f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 9.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else if (source <= 0.48) // 0.24 < source <= 0.48 8环
        {
            Debug.Log(source);
            //r1 = 8.0f;
            rTemp2 = 0.48f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 8.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else if (source <= 0.72) //0.48 < source <= 0.72 7环
        {
            Debug.Log(source);
            //r1 = 7.0f;
            rTemp2 = 0.72f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 7.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else if (source <= 0.96) //0.72 < source <= 0.96  6环
        {
            Debug.Log(source);
            //r1 = 6.0f;
            rTemp2 = 0.96f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 6.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else if (source <= 1.2) //0.96 < source <= 1.2   5环
        {
            Debug.Log(source);
            //r1 = 5.0f;
            rTemp2 = 1.2f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 5.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else if (source <= 1.44)        //1.2 < source <= 1.44 4环
        {
            Debug.Log(source);
            //r1 = 5.0f;
            rTemp2 = 1.44f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 4.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else if (source <= 1.68)            //1.44 < source <= 1.68  3环
        {
            Debug.Log(source);
            //r1 = 5.0f;
            rTemp2 = 1.68f - source;
            rTemp4 = Mathf.Round(rTemp2 / 0.03f);
            Debug.Log("Mathf.Round： " + rTemp4);
            r = 3.0f + rTemp4 * 0.1f;
            Debug.Log("环数： " + r);
            return r;
        }
        else                    // > 1.68             脱靶 
        {
            Debug.Log("脱靶");
            return -1.0f;
        }
    }
    
    /*
    //求取整数环
    float GetOutterRing(float outer)
    {
        if (outer <= 0.0)
        {
            Debug.Log(outer);
            r1 = 0.0f;
            return 10.0f;
        }
        else if (outer <= 0.24) // 0.0 < outer <= 0.24 9环
        {
            Debug.Log(outer);
            r1 = 0.0f;
            //rTemp2 = 0.24f - outer;
            //return rTemp2;
            //return 0.24f - outer;
            return 9.0f;
        }
        else if (outer <= 0.48) // 0.24 < outer <= 0.48 8环
        {
            Debug.Log(outer);
            r1 = 8.0f;
            //return 0.48f - outer;
            return 8.0f;
        }
        else if (outer <= 0.72) //0.48 < outer <= 0.72 7环
        {
            Debug.Log(outer);
            r1 = 7.0f;
            return 7.0f;
        }
        else if (outer <= 0.96) //0.72 < outer <= 0.96  6环
        {
            Debug.Log(outer);
            r1 = 6.0f;
            return 6.0f;
        }
        else if (outer <= 1.2) //0.96 < outer <= 1.2   5环
        {
            Debug.Log(outer);
            r1 = 5.0f;
            return 5.0f;
        }
        else                    // > 1.2             脱靶
        {
            Debug.Log("脱靶");
            return -1.0f;
        }
    }

    //求取小数环
    float GetInnerRing(float inner)
    {
        return 0;
    }
    */
}
