using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class decsta : MonoBehaviour
{
    int first = 0, second = 0;
    private static int[,] matrixAdjacency = { {0,3,0,0,0,2},
                                              {3,0,8,4,0,6},
                                              {0,8,0,2,4,0},
                                              {0,4,2,0,7,9},
                                              {0,0,4,7,0,1},
                                              {0,6,0,9,1,0}};

    private int[] dict = { 100, 100, 100, 100, 100, 100 };
    public Text[] text = new Text[3];

    public void decstaResult()
    {

        int a = first - 1, b = second - 1;

        if (first < 0 || second < 0) 
            return;

        int[] pased = { 0, 0, 0, 0, 0, 0 };

        dict[a] = 0;

        for (int i = 0; i < dict.Length; i++)
        {
            for (int j = 0; j < dict.Length; j++)
            {
                if (matrixAdjacency[a, j] != 0)
                {
                    dict[j] = matrixAdjacency[a, j] + dict[a] < dict[j] ? matrixAdjacency[a, j] + dict[a] : dict[j];
                }
            }
            pased[a] = 1;
            int minEl = dict.Max();
            for (int j = 0; j < pased.Length; j++)
            {
                if (pased[j] != 1)
                {
                    minEl = minEl > dict[j] ? dict[j] : minEl;
                }
            }
            a = Array.IndexOf(dict, minEl);

        }

        text[2].text = dict[b].ToString();

            Debug.Log(tracer(b));

    }
    // поиск пути
    //что то еще
    private string tracer(int b)
    {
        string mass = "";
        int tras = 100;
        for (int f = 0; f < dict.Length; f++)
        {
            mass += b.ToString();
            for (int i = 0; i < dict.Length; i++)
            {
                if (matrixAdjacency[b, i] != 0)
                {
                    tras = dict[i] < tras ? dict[i] : tras;
                }
            }
            b = Array.IndexOf(dict, tras);
            tras = 100;
        }
        return mass.ToString();
    }

    public void x1(Button button)
    {
        if (first == 0)
        {
            first = Convert.ToInt32(button.name);
            text[0].text += first;
        }
        else if (second == 0)
        {
            second = Convert.ToInt32(button.name);
            text[1].text += second;
        }
    }
    
    public void restart()
    {
        first = 0;
        second = 0;
        text[0].text = "Первая точка: ";
        text[1].text = "Вторая точка: ";
        text[2].text = " ";
    }
}
