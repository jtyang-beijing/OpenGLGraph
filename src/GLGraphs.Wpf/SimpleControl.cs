using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Wpf;
using System;
using System.Windows.Controls;

namespace GLGraphs.Wpf
{
    public class SimpleGLControl : UserControl
    {
        private GLWpfControl _control;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            var settings = new GLWpfControlSettings();
            _control = new GLWpfControl();
            _control.Ready += OnReady;
            Content = _control;
            _control.Start(settings);
        }

        private void OnReady()
        {
            _control.Render += OnRender;
        }

        private void OnRender(TimeSpan deltaTime)
        {
            //GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            CheckGLError();
        }

        private void CheckGLError()
        {
            var error = GL.GetError();
            if (error != ErrorCode.NoError)
            {
                Console.WriteLine($"OpenGL Error: {error}");
            }
        }
    }

}
