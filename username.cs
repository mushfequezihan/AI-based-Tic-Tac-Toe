//author: mushfeque.zihan@gmail.com
//purpose: username system on application

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_Midterm_
{
    public partial class username : Form





    {
        public username()
        {
            InitializeComponent();
        }






        private void button1_Click(object sender, EventArgs e)
        {
           Form1.setplayerNames(p1.Text, p2.Text); // setteing parameter for usernames on dialogbox 

            // new condition added before starting the game on dialogbox 1
           if ((p1.Text == "") || (p2.Text == ""))
            {
             MessageBox.Show("You must specify the player name before starting the game and type 'computer' for player Two if playing against computer.");      
            }
            else

               this.Close();  // closing 1st dialog box





   
    
        }

        private void p2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r") // condition for keyboard button enter pressing enter instead of mouse click ( \r means CRRIAGE RETURN)
                button1.PerformClick();    // performing button click
        }






        // KeyDown event for textbox 1 to 2 in dialog box 1 by pressing enter
        private void p1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                p2.Focus();


        }






        // closing the whole apllication completley ( FAILED) !! frm the 1st dialog box. 
    }
}
