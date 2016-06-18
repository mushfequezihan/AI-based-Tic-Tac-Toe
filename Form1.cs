//author: mushfeque.zihan@gmail.com
//purpose: Ai based Tic Tac Toe

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
    public partial class Form1 : Form
    {

        // declaring variables for program
        bool turn = true; // when X turn = true and Y turn = false

        bool against_computer = false; // new variable for against computer

        int turn_count = 0; //turn count not more than 9 times otherwise its draw!!

        static String player1, player2;  // variables for usernames

        



        public Form1()
        {
            InitializeComponent();
        }





        // creating new method for username parameter public

        public static void setplayerNames (String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // MenuStrip Exit Click
        }





        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Presented by *XZ*", "MAC 109"); // MenuStrip About Click
        }





        private void button_Click(object sender, EventArgs e)
        {
           Button b = (Button)sender; // creating a Button parameter

            // turn condiotn for X and O
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn; // switching turn between X and O
            b.Enabled = false; // disabling the Buttons in order to not cheat
            turn_count++;
            
            CheckForWinner(); // calling method 

            // check to see if playing against computer and if it is O's turn
            if ((!turn) && (against_computer))
            {
                computer_make_move(); // calling method performing as a computer
            }
            
        }
       
    





              // creating a method called computer_make_move for conditions
              private void computer_make_move()
               {             
                  // priority 1: get tic tac toe
                  // priority 2: block x tic tac toe
                  // priority 3: go for corner space
                  // priority 4: pick open space
                  
                       Button move = null;

                       // look for tic tac toe opportunities
                       move = look_for_win_or_block("O"); // calling mehtod look for win TIC TAC TOE

                       if (move == null)
                       {
                           move = look_for_win_or_block("X"); // calling mehtod look for block X

                           if (move == null)
                           {
                               move = look_for_corner(); // calling method look for corner space

                               if (move == null)
                               {
                                   move = look_for_open_space(); // calling method look for open space 

                               } // end if
                           } // end if
                       } // end if

                  // using try catch here cas of error exception on move.performclick????????????
                    try
                    {
                       move.PerformClick(); // performing as a computer move 
                   }
                   catch { }
                  
                  } // end conditions





        // method look_for_open_space
        private Button look_for_open_space()
              {
                 Button b = null;
                 foreach (Control c in Controls)
                  {
                      b = c as Button;
                      if (b != null)
                     {
                          if (b.Text == "")
                              return b;
                     }//end if
                 }//end if

                  return null;
              }





        // method look_for_corner
        private Button look_for_corner()
              {
                  if (A1.Text == "O")
                  {
                      if (A3.Text == "")
                          return A3;
                      if (C3.Text == "")
                          return C3;
                      if (C1.Text == "")
                          return C1;
                  }

                  if (A3.Text == "O")
                  {
                      if (A1.Text == "")
                          return A1;
                      if (C3.Text == "")
                          return C3;
                      if (C1.Text == "")
                          return C1;
                  }

                  if (C3.Text == "O")
                  {
                      if (A1.Text == "")
                          return A3;
                      if (A3.Text == "")
                          return A3;
                      if (C1.Text == "")
                          return C1;
                  }

                  if (C1.Text == "O")
                  {
                      if (A1.Text == "")
                          return A3;
                      if (A3.Text == "")
                          return A3;
                      if (C3.Text == "")
                          return C3;
                  }

                  if (A1.Text == "")
                      return A1;
                  if (A3.Text == "")
                      return A3;
                  if (C1.Text == "")
                      return C1;
                  if (C3.Text == "")
                      return C3;

                  return null;
              }






        // new method for playing against computer look_for_win_or_block
        private Button look_for_win_or_block(string mark)
       {
        // Horizontal tests
           if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
               return A3;
           if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
               return A1;
           if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
               return A2;


           if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
               return B3;
           if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
               return B1;
           if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
               return B2;


           if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
               return C3;
           if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
               return C1;
           if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
               return C2;


            //Vertical tests
           if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
               return C1;
           if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
               return A1;
           if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
               return B1;

           if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
               return C2;
           if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
               return A2;
           if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
               return B2;

           if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
               return C3;
           if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
               return A3;
           if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
               return B3;


            // Diagonal tests
           if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
               return C3;
           if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
               return A1;
           if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
               return B2;

           if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
               return C1;
           if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
               return A3;
           if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
               return B2;


           return null;

        } 




        // Creatig a new method for checking a Winner
            private void CheckForWinner()
        {         
            bool there_is_a_winner = false; // BOOLEAN variable 

            //horizontal checks
            if ((A1.Text == A2.Text)&&(A2.Text == A3.Text)&&(!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;


            //vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;


            //diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            
            // Message box conditon set for winner!!
            if (there_is_a_winner)               
            {
                disableButtons(); // calling method

                String winner = ""; //variable
                //condition
                if (turn)
                {
                    winner = player2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString(); //added new condition for o_win_count
                }
                else
                {
                    winner = player1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString(); //added new condition for x_win_count
                }
                MessageBox.Show(winner + " Wins :D ", " YAY!! ");
                
                } // end if
                
            // conditio for a draw!!
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString(); // added new condition for draw_count
                    MessageBox.Show(" Draw :/ ", "Bummer!!");
                }
            } // end draw condition
            
        } // end CheckForWinner





        // Creating another method for disabling the buttons after win!!
                private void disableButtons()
          {

            //  have to have try catch{} in this condition for an error exception
              
                    // condition for disablebuttons
                    foreach (Control c in Controls)
                    {
                      try
                       {
                        Button b = (Button)c;
                        b.Enabled = false;
                       } //end try
                          catch { }
                    }  // end foreach

            }  // end disableButtons 





              // MenuStrip New Game Click
                private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    turn = true; // for new game 
                    turn_count = 0; // new count

                    // loop through each button for reset

                    foreach (Control c in Controls)
                    {
                        try
                        {
                            Button b = (Button)c;
                            b.Enabled = true;
                            b.Text = "";
                        } //end try
                        catch { }
                    }  // end foreach

                }





        // adding new feature with moving mouse to the button by showing which turn it is 
                private void button_enter(object sender, EventArgs e)
                {
                    Button b = (Button)sender; // creating parameter
                    // condition
                    if (b.Enabled)
                    {
                        if (turn)
                            b.Text = "X";
                        else
                            b.Text = "O";
                    } // end if
                }






                private void button_leave(object sender, EventArgs e)
                {
                    Button b = (Button)sender; // parameter
                    // condition
                    if (b.Enabled)
                    {
                        b.Text = ""; 
                     }// end if
                }






             // NEW added feature user can input their name and play
                private void Form1_Load(object sender, EventArgs e)
                {
                    username UN = new username();  // new form loaded 
                    UN.ShowDialog();  // show doesnt need parameter n shows everything BUT showDilaog needs parameter

                    // setting the name into parameter to the main dialog box
                    label1.Text = player1;
                    label3.Text = player2;

                    // if we want to built in play against computer thn we call method here n if necessary thn comment out rest off forrm1_load code
                   // (method) setPlayerDefaultToolStripMenuItem.PerformClick(); // calling method
                } 
        





        // reset win count condition
                private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    o_win_count.Text = "0";
                    x_win_count.Text = "0";
                    draw_count.Text = "0";
                }





        // when 2nd player says computer its gonna play against computer
                private void label3_TextChanged(object sender, EventArgs e)
                {
                    // condition
                  if (label3.Text.ToLower() == "computer" )
                      against_computer = true;
                    else
                      against_computer = false;
                }





        // setting default player against computer form menustrip clik
                private void setPlayerDefaultToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    label1.Text = "player 1";
                    label3.Text = "computer";
                }






                // add rename players menu strip click.
                private void renamePlayersToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Application.Restart();
                }






        // asking permission to close the application.
                private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                {
                    DialogResult dialog = MessageBox.Show("Do You Really Want To Close The TIC TAC TOE?","GOOD BYE", MessageBoxButtons.YesNo); // message box message

                    // condition
                        if (dialog == DialogResult.Yes)
                        {
                            Application.ExitThread();   //  note : application.exit asks two times for permission but application.exitthread directly close the application.
                        }
                        else if (dialog == DialogResult.No)
                        {
                            e.Cancel = true;
                        } 
                }





               // ???????/////////////????????
                private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
                {
                  
                }  
    }
}





/* if we want username on the primary dialog box thn we hav to replace the label 1 and 3 with text box renaming with player 1 and 2 and customize the label.
 * thn we comment out all codes on form1_load cause we dont need that anymore
 * comment out main variables player 1 and 2 on the top
 * comment out setplayerNames method from the form1 source code and username sourcecode
 * in check for winner method for winner condition we replace player 1 and 2 with p1.text and p2.text(based on property name)
 * n its done!!
*/





              
              

