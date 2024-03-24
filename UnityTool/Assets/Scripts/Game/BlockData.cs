using Mignon.Game;
using Mignon.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Mignon
{
    public class BlockData : ScriptableObject
    {
        public int Grade;
        public List<bool> Data = new List<bool>();
        public Vector2Int Size;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(BlockData))]
    public class TwoDimensionalDataEditor : Editor
    {
        private BlockData blockData;

        private void OnEnable()
        {
            blockData = (BlockData)target;
        }

        public override void OnInspectorGUI()
        {
            // ������ ������ ǥ��
            EditorGUILayout.LabelField("2���� ������ ����");
            if (blockData.Data.Count > 0)
            {
                for (int j = blockData.Size.y - 1; j >= 0; --j)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (int i = 0; i < blockData.Size.x; ++i)
                    {
                        int id = MapUtil.PointToId(i, j, blockData.Size.y);
                        blockData.Data[id] = EditorGUILayout.Toggle(blockData.Data[id]);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }

            // ������ ũ�� ���� ��ư
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("������ ũ�� ����");
            blockData.Size = EditorGUILayout.Vector2IntField("������ ũ��", blockData.Size);
            if (GUILayout.Button("������ �ʱ�ȭ"))
            {
                blockData.Data.Clear();
                for (int i = 0; i < blockData.Size.x; ++i)
                {
                    for (int j = 0; j < blockData.Size.y; ++j)
                        blockData.Data.Add(false);
                }

                EditorUtility.SetDirty(blockData);
                AssetDatabase.SaveAssets();
            }

            if (GUILayout.Button("������ ����"))
            {
                EditorUtility.SetDirty(blockData);
                AssetDatabase.SaveAssets();
            }
        }
    }
#endif
}
