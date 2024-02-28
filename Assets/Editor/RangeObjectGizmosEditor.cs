using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RangeObjectGizmosEditor
{

    private static readonly int TRIANGLE_COUNT = 12;
    private static readonly Color MESH_COLOR = new Color(1.0f, 1.0f, 0.0f, 0.7f);

    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
    private static void DrawPointGizmo(RangeObject i_object, GizmoType i_gizmoType)
    {
        if (i_object.Length <= 0.0f)
        {
            return;
        }

        Gizmos.color = MESH_COLOR;

        Transform transform = i_object.transform;
        Vector3 pos = transform.position + Vector3.up * 0.01f;
        Quaternion rot = transform.rotation;
        Vector3 scale = Vector3.one * i_object.Length;

        Mesh fanmesh = CreateFanMesh(i_object.WidthAngle, TRIANGLE_COUNT);
        Gizmos.DrawMesh(fanmesh, pos, rot, scale);
    }

    //メッシュ作成
    private static Mesh CreateFanMesh(float i_angle, int i_triangleCount)
    {

        var mesh = new Mesh();

        //頂点
        var vertices = CreateFanVertices(i_angle, i_triangleCount);

        //三角形インデックス
        var triangleIndexs = new List<int>(i_triangleCount * 3);

        for (int i = 0; i < i_triangleCount; ++i)
        {
            triangleIndexs.Add(0);
            triangleIndexs.Add(i + 1);
            triangleIndexs.Add(i + 2);
        }

        mesh.vertices = vertices;
        mesh.triangles = triangleIndexs.ToArray();

        mesh.RecalculateNormals();

        return mesh;
    }

    private static Vector3[] CreateFanVertices(float i_angle, int i_triangleCount)
    {
        if (i_angle <= 0.0f)
        {
            throw new System.ArgumentException(string.Format("角度がおかしい! i_angle={0}", i_angle));
        }

        if (i_triangleCount <= 0)
        {
            throw new System.ArgumentException(string.Format("数値がおかしい! i_triangle={0}", i_triangleCount));
        }

        i_angle = Mathf.Min(i_angle, 360.0f);

        var vertices = new List<Vector3>(i_triangleCount + 2);

        //始点
        vertices.Add(Vector3.zero);

        //Mathf.Sin()とMathf.Cos()で使用するのは角度ではなくラジアンなので変換しておく。
        float radian = i_angle * Mathf.Deg2Rad;
        float startRad = -radian / 2;
        float incRad = radian / i_triangleCount;

        for (int i = 0; i < i_triangleCount + 1; ++i)
        {
            float currentRad = startRad + (incRad * i);

            Vector3 vertex = new Vector3(Mathf.Sin(currentRad), 0.0f, Mathf.Cos(currentRad));
            vertices.Add(vertex);
        }

        return vertices.ToArray();
    }
}
