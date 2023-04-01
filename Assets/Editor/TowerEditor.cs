using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(TowerShoot))]
public class TowerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        serializedObject.Update();

        Projectile projectile = target.GetComponentInChildren<Projectile>();

        EditorGUILayout.LabelField("Projectile Variables", EditorStyles.boldLabel);
        EditorGUI.indentLevel++;

        projectile.damage = EditorGUILayout.FloatField("Projectile Damage", projectile.damage);
        projectile.followSpeed = EditorGUILayout.FloatField("Follow Speed", projectile.followSpeed);

        EditorGUI.indentLevel--;
        serializedObject.ApplyModifiedProperties();

    }
}
