using Timer = System.Windows.Forms.Timer;

namespace Proiect_MIP
{
    internal class Running_button : Button
    {
        private int Direction = 1;
        private Timer Timer;
        public bool CanBeClicked = false;
        private int Speed = 10;
        public Running_button()
        {
            Timer = new Timer();
            Timer.Interval = 10; // move every 10 milliseconds
            Timer.Tick += new EventHandler(Move);

            this.MouseEnter += new EventHandler(MovingButton_MouseEnter);
            this.MouseLeave += new EventHandler(MovingButton_MouseLeave);

        }
        private void MovingButton_MouseEnter(object sender, EventArgs e)
        {
            //start moving if them mouse is hovering over and if it can't be clicked
            if (this.CanBeClicked) return;
            Timer.Start();
        }

        private void MovingButton_MouseLeave(object sender, EventArgs e)
        {
            //stop moving when the mouse leaves the button
            if (this.CanBeClicked) return;
            Timer.Stop();
        }

        private new void Move(object sender, EventArgs e)
        {
            //move left to right 
            Left += Direction * Speed;

            if (Left > Parent.Width - Width - Speed)
            {
                Direction = -1;
            }
            else if (Left < Speed)
            {
                Direction = 1;
            }
        }
    }
}
