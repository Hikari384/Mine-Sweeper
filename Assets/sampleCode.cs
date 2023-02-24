using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // # 2次元(多次元)配列
        // 複数の次元からなる配列で、要素の指定が複数インデックスで要素を指定する
        // 平面マップなどの管理では、縦と横の軸があるので
        // マス目上に並べたデータの管理に二次元配列が適している

        // ## 2次元配列の変数宣言
        // 配列宣言の[]内を次元ごとにカンマ , で区切る
        // '要素型[,] 変数名;
        int[,] ary;

        // ## 2次元配列のインスタンス化
        // 'new 要素型[要素数,　要素数]'
        ary = new int[2, 3];

        // ## 2次元配列の要素へのアクセス
        // 先頭を0世する番号で、次元ごとにインデックス指定する

        ary[0, 0] = 10; ary[0, 1] = 20; ary[0, 2] = 30;
        ary[1, 0] = 100; ary[1, 1] = 200; ary[1, 2] = 300;

        Debug.Log($"[0, 0] = {ary[0, 0]}, [0, 1] = {ary[0, 1]},[0, 2] = {ary[0, 2]}");
        Debug.Log($"[1, 0] = {ary[1, 0]}, [1, 1] = {ary[1, 1]},[1, 2] = {ary[1, 2]}");


        // ## 2次元配列の変数宣言と初期化
        // 要素型[,]変数名 = new 要素型[要素数,要素数];
        // int[,] iAry = new int[2,3];

        //多次元配列の他か推論は有効
        // var iAry = new int[2,3] でもOK

        // #多次元配列の初期化子
        // 配列初期化子は次元ごとに{}を入れ子にして多重化できる
        // 'new 要素型[要素数, 要素数] {[要素1, 要素2]}, {[..., ...], ・・・}
        // 上の初期化の場合
        // iary[0, 0] = 10; iary[0, 1] = 20; iary[0, 2] = 30;
        // iary[1, 0] = 100; iary[1, 1] = 200; iary[1, 2] = 300;
        // と同義
        var iAry = new int[2, 3]
        {
            { 10, 20, 30 },
            { 100, 200, 300 }
        };
        Debug.Log($"[0, 0] = {iAry[0, 0]}, [0, 1] = {iAry[0, 1]},[0, 2] = {iAry[0, 2]}");
        Debug.Log($"[1, 0] = {iAry[1, 0]}, [1, 1] = {iAry[1, 1]},[1, 2] = {iAry[1, 2]}");


        // ## 空配列
        // 要素数が0の配列は有効
        // var IAry = new int[]{}; 要素は省略した場合、空配列
        // var IAry = new int[0]; 上と同義。要素数0の配列
        // var IARy = new int[,]{{}};  空の2次元配列も同様
        var IAry = new int[] { };

        for (var i = 0; i < IAry.Length; i++)
        {
            //実行されない
            Debug.Log(IAry[i]);
        }

        // ## 2次元配列の要素数の取得
        // Length プロパティの値は、配列全体の要素数
        var IARY = new int[2, 3]
        {
            {10, 20, 30 },
            {100, 200, 300 }

        };
        Debug.Log($"IARY.Length={IARY.Length}");
        //配列の次元数の取得
        Debug.Log($"IARY.Length={IARY.Rank}");
        
        // 次元ごとの要素数をとるにはGetLength()メソッドを使う
        // GetLength()メソッドのパラメータに次元番号を指定する

        for (var i = 0; i < IARY.Rank; i++)
        {
            Debug.Log($"IARY.GetLength({i})={IARY.GetLength(i)}"); 
        }

        for (var i = 0; i < IARY.GetLength(0); i++)
        {
            for (var k = 0; k < IARY.GetLength(1); k++) {
                Debug.Log(IARY[i, k]);
            } 
        }

        //多次元配列でも foreach はそのまま使える
        foreach(var i in IARY)
        {
            Debug.Log(i);
        }

        //for (var i = 0; i < IARY.Length; i++)
        //{
        //    Debug.Log(IARY[i]); //1次元じゃないのでエラー
        //}
    }



}
