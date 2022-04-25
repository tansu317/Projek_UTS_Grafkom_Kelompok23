using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace PROJEK_GRAFKOM
{
    internal class Asset2D
    {
        float[] vertices =
        {
            ////x   //y   //z
            //-0.5f,-0.5f,0.0f, //vertex1
            //0.5f,-0.5f,0.0f, //vertex2
            //0.0f,0.5f,0.0f //vertex3
        };

        uint[] indices =
        {
            //0,1,3,//segitiga pertama
            //1,2,3//segitiga kedua
        };

        float[] rgba =
        {

        };

        int vertexBufferObject;
        int elementBufferObject;
        int vertexArrayObject;
        Shader shader;
        int index;
        int[] _pascal;
        Matrix4 _model;
        float x = -0.15f, y = 0.3f;

        public Asset2D(float[] vertices, uint[] indices, float[] color)
        {
            this.vertices = vertices;
            this.indices = indices;
            index = 0;
            this.rgba = color;
        }
        public void load(string shadervert, string shaderfrag)
        {
            //inisialisasi
            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer,
                vertices.Length * sizeof(float), vertices,
                BufferUsageHint.StaticDraw);

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);
            //Parameter 1 --> variable vetices nya disimpan di shader index keberapa?
            //parameter 2 --> dalam variable vertices ada berapa vertex?
            //parameter 3 --> jenis vertex yang dikrim typenya apa?
            //parameter 4 --> datanya perlu dinormalisasi ga?
            //parameter 5 --> dalam satu vertex itu mengandung berapa banyak titik (x,y,z) jadi ada 3 dikali size of float?
            //parameter 6 --> data yang mau diolah mulai dari vertex ke berapa?
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            // 0 --> referensi dari parameter 1 di atas
            GL.EnableVertexAttribArray(0);

            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
            //       false, 6 * sizeof(float), 0);
            //// 0 --> referensi dari parameter 1 di atas
            //GL.EnableVertexAttribArray(0);
            //GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float,
            //    false, 6 * sizeof(float), 3 * sizeof(float));
            //GL.EnableVertexAttribArray(1);



            if (indices.Length != 0)
            {
                elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length
                    * sizeof(uint), indices, BufferUsageHint.StaticDraw);

                //GL.GetInteger(GetPName.MaxVertexAttribs, out int maxAttributeCount);
                //Console.WriteLine($"Maximum number of " +
                    //$"vertex attributes supported: {maxAttributeCount}");
            }


            shader = new Shader(shadervert, shaderfrag);

            shader.Use();
        }

        public void render(double _time, Matrix4 temp, int pilihan, Matrix4 camera_view, Matrix4 camera_projection)
        {

            int vertexColorLocation = GL.GetUniformLocation(shader.Handle, "color");
            GL.Uniform3(vertexColorLocation, rgba[0], rgba[1], rgba[2]);
            _model = temp;

            shader.SetMatrix4("model", _model);
            shader.SetMatrix4("view", camera_view);
            shader.SetMatrix4("projection", camera_projection);
            GL.BindVertexArray(vertexArrayObject);

            shader.Use();


            if (indices.Length != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (pilihan == 0)
                {
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                }
                else if (pilihan == 1)
                {
                    GL.DrawArrays(PrimitiveType.TriangleFan, 0, (vertices.Length + 1) / 3);
                }
                else if (pilihan == 2)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, index);
                }
                else if (pilihan == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, (vertices.Length + 1) / 3);
                }
            }
        }

            public void createCircle(float center_x, float center_y, float radius_x, float radius_y)
        {
            vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                //x
                vertices[i * 3] = radius_x * (float)Math.Cos(degInRad) + center_x;
                //y
                vertices[i * 3 + 1] = radius_y * (float)Math.Sin(degInRad) + center_y;
                //z
                vertices[i * 3 + 2] = 0;
            }
        }

        public void updateMousePosition(float x, float y)
        {

            //x
            vertices[index * 3] = x;
            //y
            vertices[index * 3 + 1] = y;
            //z
            vertices[index * 3 + 2] = 0;
            index++;

            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        }


        public List<int> getRow(int rowIndex)
        {
            List<int> currow = new List<int>();
            //------
            currow.Add(1);
            if (rowIndex == 0)
            {
                return currow;
            }
            //-----
            List<int> prev = getRow(rowIndex - 1);
            for (int i = 1; i < prev.Count; i++)
            {
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);
            return currow;
        }

        public void createCurve(float x, float y)
        {

            vertices[index * 3] = x;
            vertices[index * 3 + 1] = y;
            vertices[(index * 3 + 2)] = 0;
            index++;



            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        }
        public List<float> createCurveBezier()
        {
            List<float> _vertices_bezier = new List<float>();
            List<int> pascal = getRow(index - 1);
            _pascal = pascal.ToArray();
            for (float t = 0; t <= 1.0f; t += 0.01f)
            {
                Vector2 p = getP(index, t);
                _vertices_bezier.Add(p.X);
                _vertices_bezier.Add(p.Y);
                _vertices_bezier.Add(0);

            }
            return _vertices_bezier;
        }

        public Vector2 getP(int n, float t)
        {
            Vector2 p = new Vector2(0, 0);
            float k;
            for (int i = 0; i < n; i++)
            {
                k = (float)Math.Pow((1 - t), n - 1 - i)
                    * (float)Math.Pow(t, i) * _pascal[i];
                p.X += k * vertices[i * 3];
                p.Y += k * vertices[i * 3 + 1];
            }
            return p;

        }

        public bool getVertices()
        {
            if (vertices[0] == 0)
            {
                return false;
            }
            if ((vertices.Length + 1) / 3 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setVertices(float[] _temp)
        {
            vertices = _temp;
        }

    }
}
