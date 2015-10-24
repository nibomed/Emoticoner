using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Emoticoner.Hooks
{
    /// <summary>
    /// Hook for moving form with pressed mouseKey.
    /// </summary>
    public class FormMoveHook
    {
        private bool mouseIsDown = false;
        private Point diff;
        private Form form;
        private MouseEventHandler mouseDownHandler;
        private MouseEventHandler mouseUpHandler;
        private MouseEventHandler mouseMoveHandler;

        public  FormMoveHook(Form target)
        {
            form = target;
            mouseDownHandler = new MouseEventHandler(MouseDownHandler);
            mouseUpHandler = new MouseEventHandler(MouseUpHandler);
            mouseMoveHandler = new MouseEventHandler(MouseMovHandlere);
        }

        public void SetupHandlers(Control target)
        {
            target.MouseDown += mouseDownHandler;
            target.MouseUp += mouseUpHandler;
            target.MouseMove += mouseMoveHandler;
        }

        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            diff.X = form.Location.X - Cursor.Position.X;
            diff.Y = form.Location.Y - Cursor.Position.Y;
            mouseIsDown = true;
        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }

        private void MouseMovHandlere(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                // Set the new point
                int x = Cursor.Position.X + diff.X;
                int y = Cursor.Position.Y + diff.Y;
                form.Location = new Point(x, y);
            }
        }
    }
}
