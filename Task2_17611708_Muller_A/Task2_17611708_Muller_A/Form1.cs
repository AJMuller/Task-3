using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_17611708_Muller_A
{
    public partial class Form1 : Form
    {
        Map map = new Map(20, 20, 20,8);
        const int START_X = 20;
        const int START_Y = 20;
        const int SPACING = 20;
        const int SIZE = 20;
        Random r = new Random();
        int turn = 0;
        public Form1()

        {

            InitializeComponent();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            DisplayMap();
        }// calls the displayMap method

        private void DisplayMap()
        {
            mapBox.Controls.Clear();
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Melee_Unit m = (Melee_Unit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }//end else
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }//end if

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }//end if 
                else if (u.GetType() == typeof(Ranged_Unit))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Ranged_Unit m = (Ranged_Unit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }//end else
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }//end if

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }//end else if
                else if (u.GetType() == typeof(Tank))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Tank m = (Tank)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }//end else
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }//end if

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }//end else if
                else if (u.GetType() == typeof(Helicopter))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Helicopter m = (Helicopter)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }//end else
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }//end if

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }//else if
                else if (u.GetType() == typeof(Fighter_Jets))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Fighter_Jets m = (Fighter_Jets)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }//end else
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }//end if

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }//end else if



            }//end for each 

            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    FactoryBuilding fb = (FactoryBuilding)b;
                    Button btn = new Button();
                    btn.Size = new Size(SIZE, SIZE);
                    btn.Location = new Point(start_x + (fb.XPos * SIZE), start_y + (fb.YPos * SIZE));
                    btn.Text = fb.Symbol;
                    if (fb.Faction == 1)
                    {
                        btn.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        btn.ForeColor = Color.Blue;
                    }//end else
                    mapBox.Controls.Add(btn);

                }//end if
                else if (b.GetType() == typeof(ResourceBuilding))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    ResourceBuilding rb = (ResourceBuilding)b;
                    Button btn = new Button();
                    btn.Size = new Size(SIZE, SIZE);
                    btn.Location = new Point(start_x + (rb.XPos * SIZE), start_y + (rb.YPos * SIZE));
                    btn.Text = rb.Symbol;
                    if (rb.Faction == 1)
                    {
                        btn.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        btn.ForeColor = Color.Blue;
                    }//end else

                    mapBox.Controls.Add(btn);
                }//end else if
                else if (b.GetType() == typeof(Field_Hospital))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Field_Hospital fh = (Field_Hospital)b;
                    Button btn = new Button();
                    btn.Size = new Size(SIZE, SIZE);
                    btn.Location = new Point(start_x + (fh.XPos * SIZE), start_y + (fh.YPos * SIZE));
                    btn.Text = fh.Symbol;
                    if (fh.Faction == 1)
                    {
                        btn.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        btn.ForeColor = Color.Blue;
                    }//end else

                    mapBox.Controls.Add(btn);
                }//end else if
                else if (b.GetType() == typeof(Weapon_Upgrade))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Weapon_Upgrade wu = (Weapon_Upgrade)b;
                    Button btn = new Button();
                    btn.Size = new Size(SIZE, SIZE);
                    btn.Location = new Point(start_x + (wu.XPos * SIZE), start_y + (wu.YPos * SIZE));
                    btn.Text = wu.Symbol;
                    if (wu.Faction == 1)
                    {
                        btn.ForeColor = Color.Red;
                    }//end if
                    else
                    {
                        btn.ForeColor = Color.Blue;
                    }//end else

                    mapBox.Controls.Add(btn);
                }//end else if



            }//end foreach
        }// creates new buttons for every unit and building saved in the arrays. each button is made to match the type of unit or building it is by changing colours and letters displayed on it.

        private void UpdateMap()
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    Melee_Unit m = (Melee_Unit)u;
                    if (m.IsDeath())
                    {
                        m.Symbol = "D";
                    }//end if
                    if (m.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: m.MovePos(Direction.North); break;
                            case 1: m.MovePos(Direction.East); break;
                            case 2: m.MovePos(Direction.South); break;
                            case 3: m.MovePos(Direction.West); break;
                        }//end switch
                    }//end if
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (m.WithinRange(e))
                            {
                                m.Fight(e);
                                inCombat = true;
                            }//end if
                        }//end foreach
                        if (!inCombat)
                        {
                            Unit c = m.NearestUnit(map.Units);
                            m.MovePos(m.DirectionTo(c));
                        }//end if
                    }//end else


                }//end if
                else if (u.GetType() == typeof(Ranged_Unit))
                {
                    Ranged_Unit m = (Ranged_Unit)u;
                    if (m.IsDeath())
                    {
                        m.Symbol = "D";

                    }//end if
                    if (m.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: m.MovePos(Direction.North); break;
                            case 1: m.MovePos(Direction.East); break;
                            case 2: m.MovePos(Direction.South); break;
                            case 3: m.MovePos(Direction.West); break;
                        }//end switch
                    }//end if
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (m.WithinRange(e))
                            {
                                m.Fight(e);
                                inCombat = true;
                            }//end if 
                        }//end foreach
                        if (!inCombat)
                        {
                            Unit c = m.NearestUnit(map.Units);
                            m.MovePos(m.DirectionTo(c));
                        }//end if
                    }//end else


                }//end else if 
                else if (u.GetType() == typeof(Tank))
                {
                    Tank m = (Tank)u;
                    if (m.IsDeath())
                    {
                        m.Symbol = "D";

                    }//end if
                    if (m.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: m.MovePos(Direction.North); break;
                            case 1: m.MovePos(Direction.East); break;
                            case 2: m.MovePos(Direction.South); break;
                            case 3: m.MovePos(Direction.West); break;
                        }//end switch
                    }//end if
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (m.WithinRange(e))
                            {
                                m.Fight(e);
                                inCombat = true;
                            }//end if
                        }//end foreach
                        if (!inCombat)
                        {
                            Unit c = m.NearestUnit(map.Units);
                            m.MovePos(m.DirectionTo(c));
                        }//end if
                    }//end else


                }//end else if
                else if (u.GetType() == typeof(Fighter_Jets))
                {
                    Fighter_Jets m = (Fighter_Jets)u;
                    if (m.IsDeath())
                    {
                        m.Symbol = "D";

                    }//end if
                    if (m.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: m.MovePos(Direction.North); break;
                            case 1: m.MovePos(Direction.East); break;
                            case 2: m.MovePos(Direction.South); break;
                            case 3: m.MovePos(Direction.West); break;
                        }//end switch
                    }//end if
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (m.WithinRange(e))
                            {
                                m.Fight(e);
                                inCombat = true;
                            }//end if
                        }//end foreach
                        if (!inCombat)
                        {
                            Unit c = m.NearestUnit(map.Units);
                            m.MovePos(m.DirectionTo(c));
                        }//end if
                    }//end else


                }//end else if
                else if (u.GetType() == typeof(Helicopter))
                {
                    Helicopter m = (Helicopter)u;
                    if (m.IsDeath())
                    {
                        m.Symbol = "D";

                    }//end if
                    if (m.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: m.MovePos(Direction.North); break;
                            case 1: m.MovePos(Direction.East); break;
                            case 2: m.MovePos(Direction.South); break;
                            case 3: m.MovePos(Direction.West); break;
                        }//end switch
                    }//end if
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (m.WithinRange(e))
                            {
                                m.Fight(e);
                                inCombat = true;
                            }//end if
                        }//end foreach
                        if (!inCombat)
                        {
                            Unit c = m.NearestUnit(map.Units);
                            m.MovePos(m.DirectionTo(c));
                        }//end if
                    }//end else


                }//end else if
            }//end foreach
        }// updates the map by chaging values of units. calls movement methods and fight methods to change values in order for the map to change.

       
        private void button_click(object sender, EventArgs e)
        {
            
            int x = (((Button)sender).Location.X - mapBox.Location.X) / SIZE;
            int y = (((Button)sender).Location.Y - mapBox.Location.Y) / SIZE;
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    Melee_Unit m = (Melee_Unit)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }//end if
                }//end if
                else if (u.GetType() == typeof(Ranged_Unit))
                {
                    Ranged_Unit m = (Ranged_Unit)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }//end if
                }//end else if 
                else if (u.GetType() == typeof(Tank))
                {
                    Tank m = (Tank)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }//end if
                }//end else if
                else if (u.GetType() == typeof(Helicopter))
                {
                    Helicopter m = (Helicopter)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }//end if
                }//end else if
                else if (u.GetType() == typeof(Fighter_Jets))
                {
                    Fighter_Jets m = (Fighter_Jets)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }//end if 
                }//end else if
            }//end foreach
        }//when a unit button is clicked on this method is used to display the information of the unit selected by clicking on it's button.

        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
            turn++;
            labTime.Text = turn + "";

        }//calls the updatemap and displaymap methods. increases the turn counter and updates the labtime lable.

        private void butStart_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }//enables the timer

        private void butStop_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }//disables the timer 

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter rstrm = File.CreateText("RangedUnit.txt");
            rstrm.Flush();
            rstrm.Close();
            StreamWriter mstrm = File.CreateText("MeleeUnit.txt");
            mstrm.Flush();
            mstrm.Close();
            StreamWriter ttrm = File.CreateText("Tank.txt");
            ttrm.Flush();
            ttrm.Close();
            StreamWriter htrm = File.CreateText("Helicopter.txt");
            htrm.Flush();
            htrm.Close();
            StreamWriter fjrm = File.CreateText("Fighter_Jets.txt");
            fjrm.Flush();
            fjrm.Close();
            StreamWriter fbstrm = File.CreateText("FactoryBuilding.txt");
            fbstrm.Flush();
            fbstrm.Close();
            StreamWriter rbstrm = File.CreateText("ResourceBuilding.txt");
            rbstrm.Flush();
            rbstrm.Close();
            StreamWriter fhstrm = File.CreateText("Field_Hospital.txt");
            fhstrm.Flush();
            fhstrm.Close();
            StreamWriter wustrm = File.CreateText("Weapon_Upgrade.txt");
            wustrm.Flush();
            wustrm.Close();

            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    Melee_Unit m = (Melee_Unit)u;

                    m.Save();
                }//end if
                else if (u.GetType() == typeof(Ranged_Unit))
                {
                    Ranged_Unit m = (Ranged_Unit)u;

                    m.Save();

                }//end else
                else if (u.GetType() == typeof(Tank))
                {
                    Tank m = (Tank)u;

                    m.Save();

                }//end else
                else if (u.GetType() == typeof(Helicopter))
                {
                    Helicopter m = (Helicopter)u;

                    m.Save();

                }//end else
                else if (u.GetType() == typeof(Fighter_Jets))
                {
                    Fighter_Jets m = (Fighter_Jets)u;

                    m.Save();

                }//end else



            }//end foreach
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding f = (FactoryBuilding)b;

                    f.Save();
                }//end if
                else if (b.GetType() == typeof(ResourceBuilding))
                {
                    ResourceBuilding r = (ResourceBuilding)b;

                    r.Save();

                }//end else
                else if (b.GetType() == typeof(Field_Hospital))
                {
                    Field_Hospital r = (Field_Hospital)b;

                    r.Save();

                }//end else
                else if (b.GetType() == typeof(Weapon_Upgrade))
                {
                    Weapon_Upgrade r = (Weapon_Upgrade)b;

                    r.Save();

                }//end else



            }//end foreach
        }// clears previous saves and calls methods to create new saves 

        private void btnLoad_Click(object sender, EventArgs e)
        {
      
            map.Read(20,8);
            DisplayMap();
        }//calls Read and DisplayMap Methods.
    }
}
