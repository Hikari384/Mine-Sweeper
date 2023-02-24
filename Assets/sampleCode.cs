using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // # 2����(������)�z��
        // �����̎�������Ȃ�z��ŁA�v�f�̎w�肪�����C���f�b�N�X�ŗv�f���w�肷��
        // ���ʃ}�b�v�Ȃǂ̊Ǘ��ł́A�c�Ɖ��̎�������̂�
        // �}�X�ڏ�ɕ��ׂ��f�[�^�̊Ǘ��ɓ񎟌��z�񂪓K���Ă���

        // ## 2�����z��̕ϐ��錾
        // �z��錾��[]�����������ƂɃJ���} , �ŋ�؂�
        // '�v�f�^[,] �ϐ���;
        int[,] ary;

        // ## 2�����z��̃C���X�^���X��
        // 'new �v�f�^[�v�f��,�@�v�f��]'
        ary = new int[2, 3];

        // ## 2�����z��̗v�f�ւ̃A�N�Z�X
        // �擪��0������ԍ��ŁA�������ƂɃC���f�b�N�X�w�肷��

        ary[0, 0] = 10; ary[0, 1] = 20; ary[0, 2] = 30;
        ary[1, 0] = 100; ary[1, 1] = 200; ary[1, 2] = 300;

        Debug.Log($"[0, 0] = {ary[0, 0]}, [0, 1] = {ary[0, 1]},[0, 2] = {ary[0, 2]}");
        Debug.Log($"[1, 0] = {ary[1, 0]}, [1, 1] = {ary[1, 1]},[1, 2] = {ary[1, 2]}");


        // ## 2�����z��̕ϐ��錾�Ə�����
        // �v�f�^[,]�ϐ��� = new �v�f�^[�v�f��,�v�f��];
        // int[,] iAry = new int[2,3];

        //�������z��̑������_�͗L��
        // var iAry = new int[2,3] �ł�OK

        // #�������z��̏������q
        // �z�񏉊����q�͎������Ƃ�{}�����q�ɂ��đ��d���ł���
        // 'new �v�f�^[�v�f��, �v�f��] {[�v�f1, �v�f2]}, {[..., ...], �E�E�E}
        // ��̏������̏ꍇ
        // iary[0, 0] = 10; iary[0, 1] = 20; iary[0, 2] = 30;
        // iary[1, 0] = 100; iary[1, 1] = 200; iary[1, 2] = 300;
        // �Ɠ��`
        var iAry = new int[2, 3]
        {
            { 10, 20, 30 },
            { 100, 200, 300 }
        };
        Debug.Log($"[0, 0] = {iAry[0, 0]}, [0, 1] = {iAry[0, 1]},[0, 2] = {iAry[0, 2]}");
        Debug.Log($"[1, 0] = {iAry[1, 0]}, [1, 1] = {iAry[1, 1]},[1, 2] = {iAry[1, 2]}");


        // ## ��z��
        // �v�f����0�̔z��͗L��
        // var IAry = new int[]{}; �v�f�͏ȗ������ꍇ�A��z��
        // var IAry = new int[0]; ��Ɠ��`�B�v�f��0�̔z��
        // var IARy = new int[,]{{}};  ���2�����z������l
        var IAry = new int[] { };

        for (var i = 0; i < IAry.Length; i++)
        {
            //���s����Ȃ�
            Debug.Log(IAry[i]);
        }

        // ## 2�����z��̗v�f���̎擾
        // Length �v���p�e�B�̒l�́A�z��S�̗̂v�f��
        var IARY = new int[2, 3]
        {
            {10, 20, 30 },
            {100, 200, 300 }

        };
        Debug.Log($"IARY.Length={IARY.Length}");
        //�z��̎������̎擾
        Debug.Log($"IARY.Length={IARY.Rank}");
        
        // �������Ƃ̗v�f�����Ƃ�ɂ�GetLength()���\�b�h���g��
        // GetLength()���\�b�h�̃p�����[�^�Ɏ����ԍ����w�肷��

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

        //�������z��ł� foreach �͂��̂܂܎g����
        foreach(var i in IARY)
        {
            Debug.Log(i);
        }

        //for (var i = 0; i < IARY.Length; i++)
        //{
        //    Debug.Log(IARY[i]); //1��������Ȃ��̂ŃG���[
        //}
    }



}
