using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TWepED.Properties;

namespace TWepED
{
    public partial class Main : Form
    {
        //XmlDocument data = new XmlDocument();

        LocalWeaponHelper weaponhelper;
        int selectedItem = -1;
        public Main()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            flowLayoutPanel1, new object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            weaponhelper = new LocalWeaponHelper(@"D:\Local.xml");

            flowLayoutPanel1.HorizontalScroll.Visible = false;

            refreshView();
        }

        public void refreshView()
        {
            //listBox1.Items.Clear();
            flowLayoutPanel1.Controls.Clear();

            List<Weapon> weps = weaponhelper.getFriendlyWeapons();

            for (int i = 0; i < weps.Count; i++)
            {
                Weapon item = weps[i];
                var itemui = new WeaponItem(item, i);
                itemui.Click += Itemui_Click;
                itemui.label1.Click += Subitemui_Click;
                itemui.pictureBox1.Click += Subitemui_Click;

                if(item.Type == WeaponType.Bazooka)
                {
                    itemui.pictureBox1.Image = Resources.bazooka;
                }else if(item.Type == WeaponType.Grenade)
                {
                    itemui.pictureBox1.Image = Resources.grenade;
                }
                else if(item.Type == WeaponType.Airstrike)
                {
                    itemui.pictureBox1.Image = Resources.airstrike;
                }
                else
                {
                    itemui.pictureBox1.Image = Resources.unknown;
                }

                if(weps.Count > 5)
                {
                    itemui.Width = 783;
                }

                if(i == selectedItem)
                {
                    if((i + 1) % 2 != 0)
                    {
                        itemui.BackColor = Color.FromArgb(236, 95, 0);
                    }
                    else
                    {
                        itemui.BackColor = Color.FromArgb(192, 64, 0);
                    }
                }
                else
                {
                    if ((i + 1) % 2 != 0)
                    {
                        itemui.BackColor = Color.FromArgb(209, 209, 209);
                    }
                    else
                    {
                        itemui.BackColor = Color.FromArgb(176, 176, 176);
                    }
                }

                flowLayoutPanel1.Controls.Add(itemui);
            }
        }

        private void Subitemui_Click(object sender, EventArgs e)
        {
            selectedItem = ((sender as Control).Parent as WeaponItem).ID;

            int ID = ((sender as Control).Parent as WeaponItem).ID;

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    flowLayoutPanel1.Controls[i].BackColor = Color.FromArgb(209, 209, 209);
                }
                else
                {
                    flowLayoutPanel1.Controls[i].BackColor = Color.FromArgb(176, 176, 176);
                }
            }

            if ((ID + 1) % 2 != 0)
            {
                (sender as Control).Parent.BackColor = Color.FromArgb(236, 95, 0);
            }
            else
            {
                (sender as Control).Parent.BackColor = Color.FromArgb(192, 64, 0);
            }
        }

        private void Itemui_Click(object sender, EventArgs e)
        {
            selectedItem = (sender as WeaponItem).ID;

            int ID = (sender as WeaponItem).ID;

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    (flowLayoutPanel1.Controls[i] as WeaponItem).BackColor = Color.FromArgb(209, 209, 209);
                }
                else
                {
                    (flowLayoutPanel1.Controls[i] as WeaponItem).BackColor = Color.FromArgb(176, 176, 176);
                }
            }

            if ((ID + 1) % 2 != 0)
            {
                (sender as WeaponItem).BackColor = Color.FromArgb(236, 95, 0);
            }
            else
            {
                (sender as WeaponItem).BackColor = Color.FromArgb(192, 64, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WeaponTypeSelect dialog = new WeaponTypeSelect();

            dialog.ShowDialog();

            if (dialog.selectedType == WeaponType.Unknown) return;

            weaponhelper.addNewWeapon(dialog.selectedType);

            refreshView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1)
            {
                return;
            }

            WepED ed = new WepED(weaponhelper.getFriendlyWeapons()[selectedItem]);
            ed.ShowDialog();

            refreshView();

            weaponhelper.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            weaponhelper.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1)
            {
                return;
            }
            var h = (flowLayoutPanel1.Controls[selectedItem] as WeaponItem);
            weaponhelper.removeWeapon(h.curWeapon, h.ID);

            refreshView();
        }
    }
}
