using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArduinoGUI
{


    public partial class Form1 : Form
    {

        //-------------------------DEFINING VARIABLES----------------------------
        public delegate void d1(string indata);      //bridge between threads 
        public bool toggle;

        private bool H1State = false;
        private bool H2State = false;
        private bool H3State = false;
        private bool H4State = false;
        private bool H5State = false;
        private bool H6State = false;
        private bool H7State = false;
        private bool H8State = false;
        private bool V1State = false;
        private bool V2State = false;
        private bool V3State = false;
        private bool V4State = false;
        private bool V5State = false;
        private bool V6State = false;
        private bool V7State = false;
        private bool V8State = false;

        public Form1()
        {
            InitializeComponent();
            SerialPort1.Open();
            SerialPort1.Write("0");
            MotorButton.Text = "OFF";
            MotorButton.BackColor = Color.Red;




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Defines Info Window
        private void info_Click(object sender, EventArgs e)
        {
            form2 f2 = new form2();
            f2.Show();
        }

        //Motor Button
        private void MotorButton_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            if (toggle)
            {
                MotorButton.Text = "ON";
                MotorButton.BackColor = Color.Green;

                // Turn the motor on
                SerialPort1.Write("1");
            }
            else
            {
                MotorButton.Text = "OFF";
                MotorButton.BackColor = Color.Red;

                // Turn the motor off
                SerialPort1.Write("0"); 
               
            }
        }


        //----------------------ELECTROLYSIS-----------------------------------

        //All On Button, sends "E1", turning all Transistors on
        private void All_On_Click(object sender, EventArgs e)
        {
            SerialPort1.Write("E1");

    }
        //All Off Button, sends "E0", turning all Transistors off
        private void All_Off_Click(object sender, EventArgs e)
        {
            SerialPort1.Write("E0");
        }

        //Horizontal Buttons     Write "Eh" + i
        private void H1_Click(object sender, EventArgs e)
        {
            H1State = !H1State;
            if (H1State)
            {
                SerialPort1.Write("Eh11");
                H1.BackColor = Color.Green;
            }



            else
            {
                H1.BackColor = Color.Red;
                SerialPort1.Write("Eh10");

            }
        }

        private void H2_Click(object sender, EventArgs e)
        {
            H2State = !H2State;
            if (H2State)
            {
                SerialPort1.Write("Eh21");
                H2.BackColor = Color.Green;
            }



            else
            {
                H2.BackColor = Color.Red;
                SerialPort1.Write("Eh20");

            }
        }

        private void H3_Click(object sender, EventArgs e)
        {
            H3State = !H3State;
            if (H3State)
            {
                SerialPort1.Write("Eh31");
                H3.BackColor = Color.Green;
            }



            else
            {
                H3.BackColor = Color.Red;
                SerialPort1.Write("Eh30");

            }
        }

        private void H4_Click(object sender, EventArgs e)
        {
            H4State = !H4State;
            if (H4State)
            {
                SerialPort1.Write("Eh41");
                H4.BackColor = Color.Green;
            }



            else
            {
                H4.BackColor = Color.Red;
                SerialPort1.Write("Eh40");

            }
        }

        private void H5_Click(object sender, EventArgs e)
        {
            H5State = !H5State;
            if (H5State)
            {
                SerialPort1.Write("Eh51");
                H5.BackColor = Color.Green;
            }



            else
            {
                H5.BackColor = Color.Red;
                SerialPort1.Write("Eh50");

            }
        }

        private void H6_Click(object sender, EventArgs e)
        {
            H6State = !H6State;
            if (H6State)
            {
                SerialPort1.Write("Eh61");
                H6.BackColor = Color.Green;
            }



            else
            {
                H6.BackColor = Color.Red;
                SerialPort1.Write("Eh60");

            }
        }

        private void H7_Click(object sender, EventArgs e)
        {
            H7State = !H7State;
            if (H7State)
            {
                SerialPort1.Write("Eh71");
                H7.BackColor = Color.Green;
            }



            else
            {
                H7.BackColor = Color.Red;
                SerialPort1.Write("Eh70");

            }
        }

        private void H8_Click(object sender, EventArgs e)
        {
            H8State = !H8State;
            if (H8State)
            {
                SerialPort1.Write("Eh81");
                H8.BackColor = Color.Green;
            }



            else
            {
                H8.BackColor = Color.Red;
                SerialPort1.Write("Eh80");

            }
        }

        private void V1_Click(object sender, EventArgs e)
        {
            V1State = !V1State;
            if (V1State)
            {
                SerialPort1.Write("Ev11");
                V1.BackColor = Color.Green;
            }



            else
            {
                V1.BackColor = Color.Red;
                SerialPort1.Write("Ev10");

            }

        }

        private void V2_Click(object sender, EventArgs e)
        {
            V2State = !V2State;
            if (V2State)
            {
                SerialPort1.Write("Ev21");
                V2.BackColor = Color.Green;
            }



            else
            {
                V2.BackColor = Color.Red;
                SerialPort1.Write("Ev20");

            }

        }

        private void V3_Click(object sender, EventArgs e)
        {
            V3State = !V3State;
            if (V3State)
            {
                SerialPort1.Write("Ev31");
                V3.BackColor = Color.Green;
            }



            else
            {
                V3.BackColor = Color.Red;
                SerialPort1.Write("Ev30");

            }

        }

        private void V4_Click(object sender, EventArgs e)
        {
            V4State = !V4State;
            SerialPort1.Write("Ev4");
            if (V4State)
                V4.BackColor = Color.Green;
            else
                V4.BackColor = Color.Red;

        }

        private void V5_Click(object sender, EventArgs e)
        {
            V5State = !V5State;
            SerialPort1.Write("Ev5");
            if (V5State)
                V5.BackColor = Color.Green;
            else
                V5.BackColor = Color.Red;

        }

        private void V6_Click(object sender, EventArgs e)
        {
            V6State = !V6State;
            SerialPort1.Write("Ev6");
            if (V6State)
                V6.BackColor = Color.Green;
            else
                V6.BackColor = Color.Red;

        }

        private void V7_Click(object sender, EventArgs e)
        {
            V7State = !V7State;
            SerialPort1.Write("Ev7");
            if (V7State)
                V7.BackColor = Color.Green;
            else
                V7.BackColor = Color.Red;

        }

        private void V8_Click(object sender, EventArgs e)
        {
            V8State = !V8State;
            SerialPort1.Write("Ev8");
            if (V8State)
                V8.BackColor = Color.Green;
            else
                V8.BackColor = Color.Red;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
