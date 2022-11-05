using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using TMPro;
using System;


public class Gamemanager : MonoBehaviour
{
    public string[] title= new string[256];
    //InputFieldを入れる変数
    public TMP_InputField productName;
    public TMP_InputField price;
    public TMP_InputField kcal;
    public TMP_InputField gram;

    //TextMeshProを入れる変数
    public TextMeshProUGUI calcPriceText;
    public TextMeshProUGUI calcGramText;
    public TextMeshProUGUI calcKcalText;

    //テキスト出力用の商品名を入れる配列
    private string[] productNameArray = new string[256];
    private string[] calcPriceArray = new string[256];
    private string[] calcGramArray = new string[256];
    private string[] calcKcalArray = new string[256];
    private int productCount = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    //計算ボタンが押されたときに行う処理
    public void Calc()
    {
        //double型の変数を作り、ユーザーがテキストボックスに入れた数字をdouble型に変換して入れる
        double priceNum = double.Parse(price.text);
        double kcalNum = double.Parse(kcal.text);
        double gramNum = double.Parse(gram.text);

        //計算して出した値を入れる変数を作成
        double calcPriceNum;
        double calcKcalNum;
        double calcKcalPerGramNum;

        //計算
        calcPriceNum = priceNum / gramNum;
        calcKcalNum = kcalNum / 7.2;
        calcKcalPerGramNum = kcalNum / gramNum;

        //計算して出した値を画面に表示。表示する値は小数点第1位まで
        calcPriceText.text = "1gあたりの値段は"+calcPriceNum.ToString("F1")+"円";
        calcGramText.text = kcalNum + "kcalは人間のシボウで約" + calcKcalNum.ToString("F1") + "g";
        calcKcalText.text = "1gあたりのkcalは" + calcKcalPerGramNum.ToString("F1") + "kcal";

        //商品名を配列に入れる
        productNameArray[productCount] = productName.text;
        calcPriceArray[productCount] = calcPriceNum.ToString("F1");
        calcGramArray[productCount] = calcKcalNum.ToString("F1");
        calcKcalArray[productCount] = calcKcalPerGramNum.ToString("F1");

        productCount++;
    }

    //出力機能は廃止された
/*
    //出力ボタンを押したときの処理
    public void Output() 
    {
        string path= "C:/Users/"+ Environment.UserName + "/Desktop/Result.txt";
        int countNam = 1;
        using (StreamWriter sw = new StreamWriter("",false, Encoding.UTF8))
        {
            
            while (productNameArray[countNam] !=null)
            {
                Debug.Log(path);
                sw.WriteLine("商品#"+ countNam);
                sw.WriteLine("商品名"+productNameArray[countNam]);
                sw.WriteLine("円/g: "+calcPriceArray[countNam]+"円");
                sw.WriteLine("脂肪約: "+calcGramArray[countNam]+"g");
                sw.WriteLine("kcal/g: "+calcKcalArray[countNam]+"kcal");
                //改行
                sw.WriteLine();
                countNam++;
            }
        }
    }
*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
