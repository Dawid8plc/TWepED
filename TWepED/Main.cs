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
        LocalWeaponHelper weaponhelper;
        int selectedItemIndex = -1;

        string gamePath;
        public Main(string filename)
        {
            InitializeComponent();

            //Enable double buffering on the panel to prevent flickering while refreshing view
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            weaponItemPanel, new object[] { true });

            gamePath = filename;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize the LocalWeaponHelper
            weaponhelper = new LocalWeaponHelper(gamePath + @"\data\Tweak\Local.xml");

            //Refreshes the weaponItemPanel
            refreshView();
        }

        public void refreshView()
        {
            //Clears the weaponItemPanel
            weaponItemPanel.Controls.Clear();

            //Gets the list of the weapons
            List<Weapon> weapons = weaponhelper.getFriendlyWeapons();

            //Creates a WeaponItem for every custom weapon, and adds it to the weaponItemPanel
            for (int i = 0; i < weapons.Count; i++)
            {
                Weapon item = weapons[i];
                var itemui = new WeaponItem(item, i);

                //Events that trigger when you click on the weaponItem, that will change the selectedItemIndex variable
                itemui.Click += Itemui_Click;
                itemui.weaponNameLabel.Click += Subitemui_Click;
                itemui.weaponTypePicture.Click += Subitemui_Click;

                if(weapons.Count > 5)
                {
                    itemui.Width = 783;
                }

                if(i == selectedItemIndex)
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

                weaponItemPanel.Controls.Add(itemui);
            }
        }

        private void Subitemui_Click(object sender, EventArgs e)
        {
            WeaponItem item = (sender as Control).Parent as WeaponItem;
            selectedItemIndex = item.ID;

            int ID = item.ID;

            for (int i = 0; i < weaponItemPanel.Controls.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    weaponItemPanel.Controls[i].BackColor = Color.FromArgb(209, 209, 209);
                }
                else
                {
                    weaponItemPanel.Controls[i].BackColor = Color.FromArgb(176, 176, 176);
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
            WeaponItem item = (sender as WeaponItem);
            selectedItemIndex = item.ID;

            int ID = item.ID;

            for (int i = 0; i < weaponItemPanel.Controls.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    (weaponItemPanel.Controls[i] as WeaponItem).BackColor = Color.FromArgb(209, 209, 209);
                }
                else
                {
                    (weaponItemPanel.Controls[i] as WeaponItem).BackColor = Color.FromArgb(176, 176, 176);
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

        private void newWeaponButton_Click(object sender, EventArgs e)
        {
            //Creates a new instance of the WeaponTypeSelect dialog, that allows you to select the type of the weapon you want to create
            WeaponTypeSelect dialog = new WeaponTypeSelect();

            dialog.ShowDialog();

            if (dialog.selectedType == WeaponType.Unknown) return;

            //Create a new weapon based on the selected weapon type
            weaponhelper.addNewWeapon(dialog.selectedType);

            refreshView();
        }

        private void removeWeaponButton_Click(object sender, EventArgs e)
        {
            if (selectedItemIndex == -1)
            {
                return;
            }

            //Gets the weapon from the selected weaponItem and removes it
            var weapon = (weaponItemPanel.Controls[selectedItemIndex] as WeaponItem);

            weaponhelper.removeWeapon(weapon.curWeapon, weapon.ID);

            refreshView();
        }

        private void editWeaponButton_Click(object sender, EventArgs e)
        {
            if (selectedItemIndex == -1)
            {
                return;
            }

            //Creates a new instance of the WepED (Weapon Editor) dialog and passes the selected weapon to it
            WepED editor = new WepED(weaponhelper.getFriendlyWeapons()[selectedItemIndex]);
            editor.ShowDialog();

            refreshView();

            weaponhelper.Save();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Saves all the changes to the Local.xml file
            weaponhelper.Save();
        }
    }
}
