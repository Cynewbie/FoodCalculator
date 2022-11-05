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
    //InputField������ϐ�
    public TMP_InputField productName;
    public TMP_InputField price;
    public TMP_InputField kcal;
    public TMP_InputField gram;

    //TextMeshPro������ϐ�
    public TextMeshProUGUI calcPriceText;
    public TextMeshProUGUI calcGramText;
    public TextMeshProUGUI calcKcalText;

    //�e�L�X�g�o�͗p�̏��i��������z��
    private string[] productNameArray = new string[256];
    private string[] calcPriceArray = new string[256];
    private string[] calcGramArray = new string[256];
    private string[] calcKcalArray = new string[256];
    private int productCount = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    //�v�Z�{�^���������ꂽ�Ƃ��ɍs������
    public void Calc()
    {
        //double�^�̕ϐ������A���[�U�[���e�L�X�g�{�b�N�X�ɓ��ꂽ������double�^�ɕϊ����ē����
        double priceNum = double.Parse(price.text);
        double kcalNum = double.Parse(kcal.text);
        double gramNum = double.Parse(gram.text);

        //�v�Z���ďo�����l������ϐ����쐬
        double calcPriceNum;
        double calcKcalNum;
        double calcKcalPerGramNum;

        //�v�Z
        calcPriceNum = priceNum / gramNum;
        calcKcalNum = kcalNum / 7.2;
        calcKcalPerGramNum = kcalNum / gramNum;

        //�v�Z���ďo�����l����ʂɕ\���B�\������l�͏����_��1�ʂ܂�
        calcPriceText.text = "1g������̒l�i��"+calcPriceNum.ToString("F1")+"�~";
        calcGramText.text = kcalNum + "kcal�͐l�Ԃ̃V�{�E�Ŗ�" + calcKcalNum.ToString("F1") + "g";
        calcKcalText.text = "1g�������kcal��" + calcKcalPerGramNum.ToString("F1") + "kcal";

        //���i����z��ɓ����
        productNameArray[productCount] = productName.text;
        calcPriceArray[productCount] = calcPriceNum.ToString("F1");
        calcGramArray[productCount] = calcKcalNum.ToString("F1");
        calcKcalArray[productCount] = calcKcalPerGramNum.ToString("F1");

        productCount++;
    }

    //�o�͋@�\�͔p�~���ꂽ
/*
    //�o�̓{�^�����������Ƃ��̏���
    public void Output() 
    {
        string path= "C:/Users/"+ Environment.UserName + "/Desktop/Result.txt";
        int countNam = 1;
        using (StreamWriter sw = new StreamWriter("",false, Encoding.UTF8))
        {
            
            while (productNameArray[countNam] !=null)
            {
                Debug.Log(path);
                sw.WriteLine("���i#"+ countNam);
                sw.WriteLine("���i��"+productNameArray[countNam]);
                sw.WriteLine("�~/g: "+calcPriceArray[countNam]+"�~");
                sw.WriteLine("���b��: "+calcGramArray[countNam]+"g");
                sw.WriteLine("kcal/g: "+calcKcalArray[countNam]+"kcal");
                //���s
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
