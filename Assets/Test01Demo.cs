using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Test01Demo : MonoBehaviour
{
    private int score;

    public int Score
    {
        get { return score; }
        set {
            Debug.Log(score);
            score = value+1;
            Debug.Log("�����˸�ֵ����");
            Debug.Log(score);
        }
    }

    IEnumerator ab3()
    {
        yield return Score;
    }

    IEnumerable ab4()
    {
        yield return Score;
    }
    void Start()
    {
        //Student newstu= new Student();
        ////Score = Score + 1;
        //ArrayList arrayList = new ArrayList();
        //arrayList.Add(1);
        //arrayList.Add("1");
        //int a = (int)arrayList[0];
        //Debug.Log(Score+1);
        //ab2 ab = new ab2(); 
        //Type c =ab.GetType();
        //Debug.Log(c.BaseType+ "��ӡ�Ļ�������");//��ӡ�Ļ�������
        //Debug.Log(c.Assembly+ "//��ȡ����");//��ȡ����
        //string a = "22";
        //StringBuilder b = new StringBuilder();
        //b.Append("2132");
        //Debug.Log(GetNumber(7));
        //int[] a = { 1, 2, 3,99,33,11,2,4,6 };
        //int[] b = Sort(a);
        //foreach (int i in b)
        //{
        //    Debug.Log(i+"\t");
        //}
        //EventHandler.CallEvent1();
        //int num = 1;
        //string str = "abc";
        //ChangeNum(ref str);
        //Debug.Log(str);
        //GetNums(5);

        //int[] a = new int[5];
        //for (int i = 0; i < a.Length-1; i++)
        //{
        //    a[i] = i * 2;
        //}
        //a[2] = 99;
        //SortArray(a);
        //foreach (var item in a)
        //{
        //    Debug.Log(item);
        //}
        //EventHandler2.event2 += ab2();
        //int[] a = { 2, 43, 56, 2 };
        //ArrayList a3 = new ArrayList();
        //a3.Add(1);
        //a3.Add(2);
        //a3.Add("222");
        //a3.Add(2.3f);
        //foreach (var item in a3)
        //{
        //    Debug.Log(item);
        //}
        StartCoroutine(ab3());
        int a;
        


    }
    void SortArray(Array arr) 
    { 
        Array.Sort(arr); 
    }
    //����1,1,2,3,5,8,13���� n λ���Ƕ���?�� C#�ݹ��㷨ʵ��
    int i= 1;
    int num = 1;
    int temp1 = 0;
    int temp2 = 0;
    public void GetNums(int n)
    {
        i++;
        if (n < 3)
        {
            num = 1;
            Debug.Log(n + ":" + num);
        }
        else
        {
            temp1 = temp2;
            temp2 = num;
            num = temp1 + temp2;
            if (i < n)
            {
                Debug.Log("��" + i + "�εݹ�");
                GetNums(n);
            }
            else
            {
                Debug.Log(n + ":" + num);
            }
        }
    }



    void ChangeNum(ref string num)
    {
        string a = "erasdsar";
        num = a;
    }
    // ����1,1,2,3,5,8,13���� n λ���Ƕ���?�� C#�ݹ��㷨ʵ��
    public int GetNumber(int n)
    {
        if (n==1||n==2)
        {
            return 1;
        }
        else
        {
            return GetNumber(n-1)+GetNumber(n-2);    //  3  
        }
    }

    public int[] Sort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            for(int j = i; j < array.Length - 1; j++)
            {
                if (array[j] > array[j - 1])
                {
                    var temp = array[j];
                    array[j]= array[j - 1];
                    array[j-1]= temp;
                }
            }
        }
        return array;
    }
    // Update is called once per frame
    void Update()
    {

    }
}

class ClassDemo : IDemo
{
    public int a { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void DS()
    {
        throw new System.NotImplementedException();
    }

   
}


struct Student
{
    public  int age;
}

interface IDemo 
{
    int a { get; set; }
    void DS();
    void SS() 
    {
        int A=2;
    }
}

abstract class ABDemo
{
    int a { get; set; }
     void SD() { }
    public void SB()
    {

    }
}

 class  ab2
{
    static ab2()
    {
        //EventHandler.event1 += OnEvent1;
    }

    private static void OnEvent1()
    {
        
    }

    void ab22(int a)
    {

    }
}

static class EventHandler2
{
    public static Action event1;
    public static void CallEvent1()
    {
        event1?.Invoke();
    }


    public delegate void Event2();
    public static Event2 event2;

    public static void CallEvent2()
    {
        event2?.Invoke();
    }
}


