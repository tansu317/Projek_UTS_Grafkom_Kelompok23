using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace PROJEK_GRAFKOM
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        Asset3D[] _object3d = new Asset3D[40];
        
        double _time5, _time6 = 0, _time7 = 1.5, _time8 = 1, _time9, _time10;
        
        //nicho
        double _time, _time2, _time3, _time4;

        //Nicho
        float degr = 0;
        int turn = 0, turn2 = 0;
        float degr1, degr2 = 0;

        //Nicho
        Matrix4 temp = Matrix4.Identity;
        Matrix4 temp2 = Matrix4.Identity;
        Matrix4 temp3 = Matrix4.Identity;
        Matrix4 temp4 = Matrix4.Identity;
        Matrix4 temp5 = Matrix4.Identity;
        Matrix4 temp6 = Matrix4.Identity;
        Matrix4 temp7 = Matrix4.Identity;
        Matrix4 temp8 = Matrix4.Identity;

        //SUTAN
        Matrix4 temp9 = Matrix4.Identity;
        Matrix4 temp10 = Matrix4.Identity;
        Matrix4 temp11 = Matrix4.Identity;
        Matrix4 temp12 = Matrix4.Identity;
        Matrix4 temp13 = Matrix4.Identity;
        Matrix4 temp14 = Matrix4.Identity;
        Matrix4 temp15 = Matrix4.Identity;

        //Kenneth
        Matrix4 temp16 = Matrix4.Identity;
        Matrix4 temp17 = Matrix4.Identity;
        Matrix4 temp18 = Matrix4.Identity;


        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 20f;
        //mulut
        Asset2D mouth = new Asset2D(new float[1080], new uint[]
        {

        },
            new float[]
            {
                1.0f, 0, 0
            });
        Asset2D mouth2 = new Asset2D(new float[]
        {

        }, new uint[]
        {

        },
            new float[]
            {
                1.0f, 0, 0
            });
        //alis
        Asset2D eyebrow = new Asset2D(new float[1080], new uint[]
        {

        },
            new float[]
            {
                0, 0, 0
            });
        Asset2D eyebrow2 = new Asset2D(new float[1080], new uint[]
        {

        },
            new float[]
            {
                0, 0, 0
            });
        Asset2D eyebrowBezier = new Asset2D(new float[]
       {

       }, new uint[]
       {

       },
           new float[]
           {
                0, 0, 0
           });
        Asset2D eyebrowBezier2 = new Asset2D(new float[]
       {

       }, new uint[]
       {

       },
           new float[]
           {
                0, 0, 0
           });
        
        
    //SUTAN
        //les1
        Asset2D moon = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 0, 0, 1.0f});

        Asset2D moonBeazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 1.0f, 1.0f, 0f});

        //les2
        Asset2D les = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });

        Asset2D lesBeazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });

     //KENNETH
        Asset2D kurva = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });

        Asset2D kurvaBeazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });

        Asset2D kurva2 = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });

        Asset2D kurva2Beazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });



        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            //GL.Enable(EnableCap.DepthTest);
            //Ganti background warna
            GL.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            //NICHO

            
            //badan
            _object3d[0] = new Asset3D(new Vector3(0, 0, 1.0f));
            _object3d[0].createBoxVertices(0f, 0, 0, 0.5f, 0.5f, 0.5f);
            //muka
            _object3d[1] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3d[1].createEllipsoid(0.25f, 0.25f, 0.25f, 0, 0.5f, 0);
            //tangan kiri
            _object3d[2] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3d[2].createEllipsoid(0.05f, 0.3f, 0.25f, -0.3f, -0.15f, 0);
            //tangan kanan
            _object3d[3] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3d[3].createEllipsoid(0.05f, 0.3f, 0.25f, 0.3f, -0.15f, 0);
            //kaki kanan
            _object3d[4] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3d[4].createEllipsoid(0.05f, 0.3f, 0.25f, 0.1f, -0.5f, 0);
            //kaki kiri
            _object3d[5] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3d[5].createEllipsoid(0.05f, 0.3f, 0.25f, -0.1f, -0.5f, 0);
            //object hyperboloid
            _object3d[6] = new Asset3D(new Vector3(0f, 1.0f, 1.0f));
            _object3d[6].createHyperBolloid2Sheet(0.025f, 0.025f, 0.025f, 1.75f, 0.1f, 0.5f);

            //road
            _object3d[7] = new Asset3D(new Vector3(0, 0, 0));
            _object3d[7].createBoxVertices(0, -2f, 0, 2.0f, 1.0f, 200.0f);
            //mata kiri
            _object3d[8] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3d[8].createEllipsoid(0.05f, 0.05f, 0.05f, -0.1f, 0.6f, 0);
            //mata kanan
            _object3d[9] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3d[9].createEllipsoid(0.05f, 0.05f, 0.05f, 0.1f, 0.6f, 0);
            //bola mata kiri
            _object3d[10] = new Asset3D(new Vector3(0f, 0f, 0f));
            _object3d[10].createEllipsoid(0.01f, 0.01f, 0.01f, -0.1f, 0.6f, 0);
            //bola mata kanan
            _object3d[11] = new Asset3D(new Vector3(0f, 0f, 0f));
            _object3d[11].createEllipsoid(0.01f, 0.01f, 0.01f, 0.1f, 0.6f, 0);

            ///kotak hammer
            _object3d[12] = new Asset3D(new Vector3(0.5f, 0.0f, 0.5f));
            _object3d[12].createBoxVertices(1.5f, 0.025f, 0.01f, 0.5f, 0.5f, 0.5f);
            //hammer luar
            _object3d[13] = new Asset3D(new Vector3(0.5f, 1.0f, 0.5f));
            _object3d[13].createElipticCone(0.125f, 0.125f, 0.125f, 1.5f, 0.025f, 0.2f, -1);
            //hammer dalam
            _object3d[14] = new Asset3D(new Vector3(0.5f, 1.0f, 0.5f));
            _object3d[14].createElipticCone(0.125f, 0.125f, 0.125f, 1.5f, 0.025f, 0.2f, 1);
            //UFO
            _object3d[15] = new Asset3D(new Vector3(1f, 1f, 1f));
            _object3d[15].createEllipticParaboloid(0.125f, 0.125f, 0.125f, -2f, 0.15f, -0.25f);
            //scaling object
            _object3d[16] = new Asset3D(new Vector3(0.5f, 0.25f, 0.75f));
            _object3d[16].createEllipsoid(0.125f, 0.125f, 0.125f, 1.5f, 0.1f, -0.25f);
            //banner
            _object3d[17] = new Asset3D(new Vector3(0.5f, 1.0f, 0.0f));
            _object3d[17].createHyperboloidParaboloid(0.125f, 0.125f, 0.125f, -1.5f, 0.1f, -0.25f);
            //hidung
            _object3d[18] = new Asset3D(new Vector3(1.0f, 0.5f, 0.4f));
            _object3d[18].createEllipsoid(0.025f, 0.0375f, 0.025f, 0f, 0.5f, 0);


        //KENPO
            // roket

            //tengah roket
            _object3d[19] = new Asset3D(new Vector3(1.0f, 0.0f, 0.0f));
            _object3d[19].createEllipsoid(0.5f, 0.9f, 0.5f, 5.0f, 1.0f, 0.0f);

            //bawah roket
            _object3d[20] = new Asset3D(new Vector3(1.0f, 1.0f, 0.0f));
            _object3d[20].createBoxVertices(5.0f, 0.3f, 0.0f, 0.9f, 0.5f, 0.5f);

            //jendela bulat
            _object3d[21] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3d[21].createEllipsoid(0.2f, 0.2f, 0.2f, 5.0f, 1.5f, 0.0f);

            //yang berubah
            //sirip depan 
            degr1 = MathHelper.DegreesToRadians(180f);
            _object3d[29] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3d[29].createElipticCone(0.125f, 0.125f, 0.25f, 5.0f, 0.5f, -0.6f, 1);

            //sirip belakang
            _object3d[30] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3d[30].createElipticCone(0.125f, 0.125f, 0.25f, 5.0f, -0.5f, -0.6f, 1);


            //SUTAN
            //kincir1
            _object3d[22] = new Asset3D(new Vector3(0.1f, 1.0f, 0.0f));
            _object3d[22].createEllipticParaboloid(0.2f, 0.1f, 0.1f, 0.0f, 6.0f, 0.0f);

            //kincir2
            _object3d[23] = new Asset3D(new Vector3(0.1f, 1.0f, 0.0f));
            _object3d[23].createEllipticParaboloid(0.2f, 0.1f, 0.1f, 0.0f, 6.0f, 0.0f);

            //kincir3
            _object3d[24] = new Asset3D(new Vector3(0.0f, 1.0f, 0.0f));
            _object3d[24].createEllipticParaboloid(0.2f, 0.1f, 0.1f, 0.0f, 6.0f, 0.0f);


            //baling" belakang
            _object3d[25] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3d[25].createBoxVertices(-3.0f, 5.0f, 0.0f, 0.1f, 2.0f, 0.2f);

            //badan pesawat
            _object3d[26] = new Asset3D(new Vector3(1.0f, 0.411f, 0.705f));
            _object3d[26].createEllipsoid(3.5f, 0.8f, 0.9f, 0.3f, 5.2f, -0.5f);

            //kabin pilot
            _object3d[27] = new Asset3D(new Vector3(1.0f, 1.0f, 0.0f));
            _object3d[27].createBoxVertices(0.8f, 4.0f, -0.3f, 1.0f, 0.8f, 0.5f);

            //pemancar jaringan
            _object3d[28] = new Asset3D(new Vector3(0.0f, 1.0f, 0.0f));
            _object3d[28].createElipticCone(0.5f, 0.5f, 1.5f, 0.1f, 5.2f, 0.0f, 1);

            //scope
            _object3d[31] = new Asset3D(new Vector3(0.58f, 0.29411f, 0.0f));
            _object3d[31].createEllipticParaboloid(0.1f, 0.1f, -0.1f, 1.0f, 4.5f, 0.0f);

            temp = temp * Matrix4.CreateScale(0.95f);

            //Kenneth
            temp16 = temp16 * Matrix4.CreateRotationX(degr1);


            _camera = new Camera(new Vector3(0, 3, 5), Size.X / Size.Y);

            for (int i = 0; i < 32; i++)
            {
                _object3d[i].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            }

         //NICHO
            mouth.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            mouth2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");

            mouth.createCurve(-0.15f, 0.45f);
            mouth.createCurve(-0.1f, 0.4f);
            mouth.createCurve(0.1f, 0.4f);
            mouth.createCurve(0.15f, 0.45f);
            eyebrow.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrowBezier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrow.createCurve(-0.175f, 0.7f);
            eyebrow.createCurve(-0.125f, 0.75f);
            eyebrow.createCurve(-0.075f, 0.75f);
            eyebrow.createCurve(-0.025f, 0.7f);
            eyebrow2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrowBezier2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrow2.createCurve(0.025f, 0.7f);
            eyebrow2.createCurve(0.075f, 0.75f);
            eyebrow2.createCurve(0.125f, 0.75f);
            eyebrow2.createCurve(0.175f, 0.7f);

        //KENNETH
            kurva.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurvaBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurva.createCurve(5.5f, 0.4f);
            kurva.createCurve(5.3f, 0.8f);
            kurva.createCurve(5.1f, 0.0f);
            kurva.createCurve(4.9f, 1.5f);

            kurva2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurva2Beazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurva2.createCurve(4.9f, 0.4f);
            kurva2.createCurve(5.1f, 1.5f);
            kurva2.createCurve(5.3f, 1.5f);
            kurva2.createCurve(5.5f, 1.5f);

            //SUTAN
            moon.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            moonBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");

            moon.createCurve(-2.5f, 4.8f);
            moon.createCurve(-2.5f, 5.5f);
            moon.createCurve(2.5f, 4.0f);
            moon.createCurve(2.5f, 5.5f);

            les.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            lesBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            les.createCurve(-2.5f, 4.8f);
            les.createCurve(-2.5f, 5.4f);
            les.createCurve(2.5f, 5.4f);
            les.createCurve(2.5f, 5.4f);

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

        //NICHO
            _time = 0;
            _time2 = 18f;
            temp3 = Matrix4.Identity;
            degr += MathHelper.DegreesToRadians(1f);
            temp3 = temp3 * Matrix4.CreateRotationY(degr);
            temp3 = temp3 * Matrix4.CreateRotationZ(degr);
            temp3 = temp3 * Matrix4.CreateRotationX(degr);

            _time3 += 20f;
            temp7 = Matrix4.Identity;
            temp8 = Matrix4.Identity;
            temp7 = temp7 * Matrix4.CreateRotationX(degr);
            temp8 = temp8 * Matrix4.CreateRotationY(degr);

            _object3d[15].render(3, _time3, temp3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[17].render(3, _time3, temp7, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[7].render(3, _time2, temp2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[1].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[2].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[3].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[4].render(3, _time, temp6, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[5].render(3, _time, temp5, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            _object3d[6].render(3, _time2, temp8, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[0].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[8].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[9].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[10].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[11].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[12].render(3, _time3, temp3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            _object3d[14].render(3, _time3, temp3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[13].render(3, _time3, temp3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[18].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[16].render(3, _time4, temp4, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (mouth.getVertices())
            {

                List<float> _verticesTemp = mouth.createCurveBezier();
                mouth2.setVertices(_verticesTemp.ToArray());
                mouth2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                mouth2.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            mouth.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            if (eyebrow.getVertices())
            {

                List<float> _verticesTemp = eyebrow.createCurveBezier();
                eyebrowBezier.setVertices(_verticesTemp.ToArray());
                eyebrowBezier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                eyebrowBezier.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            eyebrow.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            if (eyebrow2.getVertices())
            {

                List<float> _verticesTemp = eyebrow2.createCurveBezier();
                eyebrowBezier2.setVertices(_verticesTemp.ToArray());
                eyebrowBezier2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                eyebrowBezier2.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            eyebrow2.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            //KENNETH
            _time4 += 100f * args.Time;
            temp18 = temp18 * Matrix4.CreateTranslation(-5.0f, 0.0f, 0.0f);
            temp18 = temp18 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time4));
            temp18 = temp18 * Matrix4.CreateTranslation(5.0f, 0.0f, 0.0f);

            _object3d[29].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[30].render(3, _time, temp16, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[20].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[19].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[21].render(3, _time, temp18, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            

            if (kurva.getVertices())
            {

                List<float> _verticesTemp = kurva.createCurveBezier();
                kurvaBeazier.setVertices(_verticesTemp.ToArray());
                kurvaBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                kurvaBeazier.render(_time, temp17, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            kurva.render(_time, temp17, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (kurva2.getVertices())
            {

                List<float> _verticesTemp = kurva2.createCurveBezier();
                kurva2Beazier.setVertices(_verticesTemp.ToArray());
                kurva2Beazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                kurva2Beazier.render(_time, temp18, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            kurva2.render(_time, temp18, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());



            //SUTAN
            _time7 = 1.5;
            _time6 = 0;
            _time8 = 1;
            _time10 += 1500f * args.Time;

            _time5 += 1500f * args.Time;
            _time6 += 15000f * args.Time;
            _time7 += 15000f * args.Time;
            _time8 += 15000f * args.Time;
           

            //Rotasi kincir belakang
            temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, -5.0f, 0.0f));
            temp9 = temp9 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)_time10));
            temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, 5.0f, 0.0f));


            //kincir atas
            temp10 = temp10 * Matrix4.CreateTranslation(new Vector3(0.0f, -6.0f, 0.0f));
            temp10 = temp10 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time6));
            temp10 = temp10 * Matrix4.CreateTranslation(new Vector3(0.0f, 6.0f, 0.0f));

            temp11 = temp11 * Matrix4.CreateTranslation(new Vector3(0.0f, -6.0f, 0.0f));
            temp11 = temp11 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time7));
            temp11 = temp11 * Matrix4.CreateTranslation(new Vector3(0.0f, 6.0f, 0.0f));

            temp12 = temp12 * Matrix4.CreateTranslation(new Vector3(0.0f, -6.0f, 0.0f));
            temp12 = temp12 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time8));
            temp12 = temp12 * Matrix4.CreateTranslation(new Vector3(0.0f, 6.0f, 0.0f));


            //pemancar radio
            temp13 = temp13 * Matrix4.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));


            //_object3d[22].render(3, _time, temp10, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[25].render(3, _time, temp9, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[23].render(3, _time, temp11, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[26].render(1, _time, temp15, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[27].render(1, _time, temp14, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //baling" belakang
            _object3d[28].render(1, _time, temp14, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3d[31].render(1, _time, temp14, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //_object3d[24].render(3, _time, temp12, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //CursorGrabbed = true;



            if (moon.getVertices())
            {

                List<float> _verticesTemp = moon.createCurveBezier();
                moonBeazier.setVertices(_verticesTemp.ToArray());
                moonBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                moonBeazier.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            moon.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (les.getVertices())
            {

                List<float> _verticesTemp = les.createCurveBezier();
                lesBeazier.setVertices(_verticesTemp.ToArray());
                lesBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                lesBeazier.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            les.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            for (int i = 0; i < 31; i++)
            {
                _object3d[i].resetEuler();
            }

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {//bakal jalan stiap ada perubahan ukuran layar
            base.OnResize(e);
            Console.WriteLine("ini Resize");
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {//bakal jalan per beberapa FPS frame
            base.OnUpdateFrame(args);

            var input = KeyboardState;
            var mouse_input = MouseState;

            var key = KeyboardState;
            var mouse = MouseState;

            //SUTAN
            if (KeyboardState.IsKeyDown(Keys.F2))
            {
                _time += 20f * args.Time;
                _time10 += 1000f * args.Time; 
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, -5.0f, 0.0f));
                temp9 = temp9 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)_time));
                temp9 = temp9 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, 5.0f, 0.0f));
                temp14 = temp14 * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
                temp15 = temp15 * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
                temp13 = temp13 * Matrix4.CreateTranslation(new Vector3(0.05f, 0, 0.0f));

            
            }


            if (KeyboardState.IsKeyDown(Keys.F1))
            {
                _time += 20f * args.Time;
                _time10 += 10000f * args.Time;
                temp12 = temp12 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp14 = temp14 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp15 = temp15 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, -5.0f, 0.0f));
                temp9 = temp9 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)_time));
                temp9 = temp9 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, 5.0f, 0.0f));

                temp13 = temp13 * Matrix4.CreateTranslation(new Vector3(-0.05f, 0, 0.0f));
            }

            //KENNETH
            if (KeyboardState.IsKeyDown(Keys.PageUp))
            {

                _time += 20f * args.Time;
                temp16 = temp16 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);
                temp17 = temp17 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);
                temp18 = temp18 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);


            }
            if (KeyboardState.IsKeyDown(Keys.PageDown))
            {

                _time += 20f * args.Time;
                temp16 = temp16 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);
                temp17 = temp17 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);
                temp18 = temp18 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);

            }

            //NICHO
            if (KeyboardState.IsKeyDown(Keys.Down))
            {

                _time += 20f * args.Time;
                temp5 = temp5 * Matrix4.CreateTranslation(0.0f, 0f, -0.05f);
                temp6 = temp6 * Matrix4.CreateTranslation(0.0f, 0f, -0.05f);
                temp = temp * Matrix4.CreateTranslation(0.0f, 0, -0.05f);
                walkingBackwards();


            }

            if (KeyboardState.IsKeyDown(Keys.Up))
            {

                _time += 20f * args.Time;
                temp5 = temp5 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp6 = temp6 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp = temp * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                walking();
            }

            if (KeyboardState.IsKeyReleased(Keys.Left))
            {
                _time += 20f * args.Time;
                temp5 = temp5 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp6 = temp6 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp = temp * Matrix4.CreateTranslation(-0.05f, 0, 0.0f);

            }

            if (KeyboardState.IsKeyReleased(Keys.Right))
            {
                _time += 20f * args.Time;
                temp5 = temp5 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp6 = temp6 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp = temp * Matrix4.CreateTranslation(0.05f, 0, 0.0f);

            }

            if (key.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            float cameraSpeed = 0.5f;

            if (key.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.Enter))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyReleased(Keys.D1))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = Matrix4.CreateScale(1.0f) * temp4;
                temp15 = Matrix4.Identity;
                temp15 = temp15 * Matrix4.CreateScale(1.0f);

            }
            if (KeyboardState.IsKeyReleased(Keys.D2))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = Matrix4.CreateScale(2.0f) * temp4;

                
            }
            if (KeyboardState.IsKeyReleased(Keys.D3))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(3.0f);

      
            }
            if (KeyboardState.IsKeyReleased(Keys.D4))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(4.0f);

             
            }
            if (KeyboardState.IsKeyReleased(Keys.D5))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(5.0f);

                temp15 = Matrix4.Identity;
                temp15 = temp15 * Matrix4.CreateScale(2.0f);
            }
            if (KeyboardState.IsKeyReleased(Keys.D6))
            {
                _time4 += 18f;

                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(6.0f);
            }
            if (KeyboardState.IsKeyReleased(Keys.D7))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(7.0f);
            }
            if (KeyboardState.IsKeyReleased(Keys.D8))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(8.0f);
            }
            if (KeyboardState.IsKeyReleased(Keys.D9))
            {
                _time4 += 18f;
                temp4 = Matrix4.Identity;
                temp4 = temp4 * Matrix4.CreateScale(9.0f);
            }

            var sensitivity = 0.1f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse_input.X, mouse_input.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse_input.X - _lastPos.X;
                var deltaY = mouse_input.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse_input.X, mouse_input.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
        }

        public async void walking()
        {
            turn++;
            if (turn % 2 == 0)
            {
                degr2 = MathHelper.DegreesToRadians(0.5f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(degr);
                await Task.Delay(100);
                temp5 = temporary;
                temp6 = temp6 * Matrix4.CreateRotationX(-degr);
                await Task.Delay(100);

                temp6 = temporary2;
            }
            else
            {
                degr2 = MathHelper.DegreesToRadians(0.5f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(-degr);
                await Task.Delay(100);
                temp5 = temporary;
                temp6 = temp6 * Matrix4.CreateRotationX(degr);
                await Task.Delay(100);

                temp6 = temporary2;
            }
        }
        public async void walkingBackwards()
        {
            turn2++;
            if (turn2 % 2 == 0)
            {
                degr2 = MathHelper.DegreesToRadians(0.05f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(degr);
                await Task.Delay(100);
                temp5 = temporary;
                temp6 = temp6 * Matrix4.CreateRotationX(-degr);
                await Task.Delay(100);

                temp6 = temporary2;
            }
            else
            {
                degr2 = MathHelper.DegreesToRadians(0.05f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(-degr);
                await Task.Delay(100);
                temp5 = temporary;
                temp6 = temp6 * Matrix4.CreateRotationX(degr);
                await Task.Delay(100);

                temp6 = temporary2;
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }


    }
}
