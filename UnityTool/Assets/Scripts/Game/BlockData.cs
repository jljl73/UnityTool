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
            // 편집할 데이터 표시
            EditorGUILayout.LabelField("2차원 데이터 편집");
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

            // 데이터 크기 조정 버튼
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("데이터 크기 조정");
            blockData.Size = EditorGUILayout.Vector2IntField("데이터 크기", blockData.Size);
            if (GUILayout.Button("데이터 초기화"))
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

            if (GUILayout.Button("데이터 저장"))
            {
                EditorUtility.SetDirty(blockData);
                AssetDatabase.SaveAssets();
            }
        }
    }
#endif
}
