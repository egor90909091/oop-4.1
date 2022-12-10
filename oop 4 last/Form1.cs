using storage;
using System.CodeDom.Compiler;


namespace oop_4_last
    
{
    public partial class Form1 : Form
    {
     MyStorage<CCircle> ccircles = new MyStorage<CCircle> { };

        public class CCircle
        {   
            public bool selected=false;
            public Point center;
            private const int r = 120;
            public CCircle()
            {
                center = new Point(0, 0);
            }
            public CCircle(int x, int y)
            {
                center = new Point(x, y);
            }
            public void SetCord(int _x, int _y)
            {
                center.X = _x;
                center.Y = _y;
            }

           
            public void draw(Graphics g)
            {
                SolidBrush redBrush = new SolidBrush(Color.Red);
                SolidBrush blueBrush = new SolidBrush(Color.Blue);
                Pen pen = new Pen(Color.Black);
                g.DrawEllipse(pen, center.X - r/2, center.Y-r/2 , r, r);
                if (selected == true)
                    g.FillEllipse(redBrush, center.X - r / 2, center.Y - r / 2, r, r);
                else
                    g.FillEllipse(blueBrush, center.X - r / 2, center.Y - r / 2, r, r);

            }
            
            public bool containe(Point superpoint)
            {

                return ((Math.Pow(center.X - superpoint.X, 2)) + (Math.Pow(center.Y - superpoint.Y, 2)) <= Math.Pow(r, 2));
             
            }

        }
        







        public Form1()
        {
            InitializeComponent();
            
        }




        public void isSelected(int x, int y)
        {
            for (int i = 0; i < ccircles.count(); i++)
            {
                if (ccircles[i] is CCircle)
                {
                    ccircles[i].selected = false;
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
        }

      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) {
                for (int i = ccircles.count() - 1; i >= 0; i--)
                    if (ccircles[i] is CCircle)
                    {
                        if (ccircles[i].selected)
                        {
                            ccircles.removeAtIndex(i);
                        }
                    }
            }
            pictureBox2.Invalidate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {

            int x = e.X;
            int y = e.Y;
            bool isOnScreen = false;


            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                for (int i = 0; i < ccircles.count(); i++)
                {
                    if (ccircles[i] is CCircle)
                    {
                        if (ccircles[i].containe(new Point(x, y)))
                        {
                            ccircles[i].selected = true;


                        }
                    }

                }



            }
            else
            {
                isSelected(x, y);
                for (int i = 0; i < ccircles.count(); i++)
                {
                    if (ccircles[i] is CCircle)
                    {
                        if (ccircles[i].containe(new Point(x, y)))
                        {
                            ccircles[i].selected = true;
                            isOnScreen = true;
                            break;
                        }
                    }

                }
                if (!isOnScreen)
                {
                    var tmp = new CCircle(x, y);
                    tmp.selected = true;
                    ccircles.add(tmp);
                }

            }


            pictureBox2.Invalidate();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < ccircles.count(); i++)
            {

                if (ccircles[i] is CCircle)
                {

                    ccircles[i].draw(e.Graphics);
                }

            }
        }

        private void pictureBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }

}