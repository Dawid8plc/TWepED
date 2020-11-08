using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Xml;

namespace TWepED
{
    public class LocalWeaponHelper
    {
        public XmlDocument data = new XmlDocument();

        XmlNode weaponCollectionNode;

        public int nextSafeID;

        public LocalWeaponHelper(string path)
        {
            //Loads the desired Local.xml file
            data.Load(path);

            //Gets the WeaponFactoryCollective node which contains all the weapons
            weaponCollectionNode = data.SelectSingleNode(@"/xomArchive/xomObjects/WeaponFactoryCollective");

            //Gets the "nextSafeID" - the next ID that we can use for a weapon
            //Lets say our last custom weapon's ID is 22. 23 and 24 are the respective ids for the weapon and cluster nodes for the 22 weapon
            //Which means that the next safe id that we can use is 25
            nextSafeID = Convert.ToInt32(weaponCollectionNode.LastChild.Attributes["href"].Value.Split('-')[1]) + 3;
        }

        public void Save()
        {
            //XmlWriterSettings ensures that the saved XML file will be in the UTF-8 format. By default it would get saved in
            //UTF-8 bom which turned out to be crashing the game.
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true, Encoding = new UTF8Encoding(false) };

            //It creates a new file called NewLocal.xml which is a temporary file used for testing, soon its going to ask you
            //where your Local.xml file is, and will overwrite it. It might also make backups, who knows?
            XmlWriter writer = XmlWriter.Create(@"D:\NewLocal.xml", settings);

            data.Save(writer);

            writer.Close();
        }

        public List<Weapon> getFriendlyWeapons()
        {
            List<Weapon> weps = new List<Weapon>();

            //Gets every weapon node from the WeaponFactoryCollective node
            //Based on the ID from the said weapon node, it tries to track down the rest of the nodes that belong to the weapon
            //after it finds the required nodes, it creates an instance of the Weapon class with the said nodes
            //just so that they can be easily accessed later on, what's the point of getting the nodes in multiple functions if you can just
            //do it once?
            foreach (XmlNode item in getCustomWeapons())
            {
                XmlNode curwepnode = data.SelectSingleNode(@"/xomArchive/xomObjects//*[@id='" + item.Attributes["href"].Value + "']");

                XmlNode actualwepnode = data.SelectSingleNode(@"/xomArchive/xomObjects//*[@id='" + curwepnode.ChildNodes[1].Attributes["href"].Value + "']");

                XmlNode clustrNode = data.SelectSingleNode(@"/xomArchive/xomObjects//*[@id='" + curwepnode.ChildNodes[2].Attributes["href"].Value + "']");

                XmlNode nameNode = data.SelectSingleNode(@"/xomArchive/xomObjects/*[@id='" + actualwepnode.ChildNodes[1].InnerText + "']");

                string[] ID = item.Attributes["href"].Value.Split('-');

                XmlNode stringvarnode = data.SelectSingleNode(@"/xomArchive/xomObjects/XDataBank/*[@href='Text.cWeapon-" + ID[1] + "']");

                Weapon wep = new Weapon
                {
                    Name = (nameNode == null) ? actualwepnode.ChildNodes[1].InnerText : nameNode.FirstChild.InnerText,
                    storeNode = curwepnode,
                    weaponNode = actualwepnode,
                    clusterNode = clustrNode,
                    nameNode = nameNode,
                    collectionNode = item,
                    stringVarNode = stringvarnode,
                    Type = (WeaponType)Convert.ToInt32(actualwepnode.FirstChild.InnerText)
                };

                weps.Add(wep);
            }

            return weps;
        }

        public List<XmlNode> getCustomWeapons()
        {
            //Returns the custom weaopns from the WeaponFactoryCollective node. Ignores the default weapons
            List<XmlNode> nodes = weaponCollectionNode.Cast<XmlNode>().ToList();
            return nodes.GetRange(7, nodes.Count - 7);
        }

        public void degradeElement(XmlNode node, string attribute)
        {
            //Lowers the ID for the specific node by 3, used when deleting weapons
            string curpart = node.Attributes[attribute].Value;

            string[] a = curpart.Split('-');

            curpart = a[0];
            curpart += "-" + (Convert.ToInt32(a[1]) - 3);

            node.Attributes[attribute].Value = curpart;
        }

        public void removeWeapon(Weapon weapon, int orderID)
        {
            //Gets a list of every single weapon
            List<Weapon> nodes = getFriendlyWeapons();

            //Lowers the ID for every single weapon that appears AFTER the deleted weapon
            for (int i = orderID + 1; i < nodes.Count; i++)
            {
                //WeaponFactoryContainer Weapon
                degradeElement(nodes[i].weaponNode, "id");

                //WeaponFactoryContainer Cluster
                degradeElement(nodes[i].clusterNode, "id");


                //StoreWeaponFactory
                degradeElement(nodes[i].storeNode, "id");

                //Stage 2 Children nodes - Weapon
                degradeElement(nodes[i].storeNode.ChildNodes[1], "href");

                //Stage 2 Children nodes - Cluster
                degradeElement(nodes[i].storeNode.ChildNodes[2], "href");

                //WeaponFactoryCollective
                degradeElement(nodes[i].collectionNode, "href");

                //StringResources
                degradeElement(nodes[i].stringVarNode, "href");

                //XStringResourceDetails
                degradeElement(nodes[i].nameNode, "id");

                string curpart = nodes[i].nameNode.ChildNodes[1].InnerText;

                string[] a = curpart.Split('-');

                curpart = a[0];
                curpart += "-" + (Convert.ToInt32(a[1]) - 3);

                nodes[i].nameNode.ChildNodes[1].InnerText = curpart;

                //Degrade Weapon Name
                nodes[i].weaponNode.ChildNodes[1].InnerText = curpart;

            }

            if (weapon.nameNode != null)
            {
                weapon.nameNode.ParentNode.RemoveChild(weapon.nameNode);
                weapon.stringVarNode.ParentNode.RemoveChild(weapon.stringVarNode);
            }

            weapon.storeNode.ParentNode.RemoveChild(weapon.storeNode);
            weapon.weaponNode.ParentNode.RemoveChild(weapon.weaponNode);
            weapon.collectionNode.ParentNode.RemoveChild(weapon.collectionNode);

            Save();
        }

        public void addNewWeapon(WeaponType type)
        {
            //Gets the xomObjects node
            XmlNode xomObjects = data.SelectSingleNode(@"/xomArchive/xomObjects");

            //Creates a new StoreWeaponFactory node
            XmlNode storewepnode = data.CreateNode(XmlNodeType.Element, "StoreWeaponFactory", "");
            storewepnode.InnerXml = @"<StockWeapon>true</StockWeapon><Weapon href='DATA.LockedWeapons-" + (nextSafeID + 1) + "'/><Cluster href='DATA.LockedWeapons-" + (nextSafeID + 2) + "'/>";

            XmlAttribute storeattr = data.CreateAttribute("id");
            storeattr.Value = "DATA.LockedWeapons-" + nextSafeID;
            storewepnode.Attributes.Append(storeattr);

            //Adds the StoreWeaponFactory node to the xomObjects node
            xomObjects.AppendChild(storewepnode);

            //Creates a new WeaponFactoryContainer node which is used for the weapon
            XmlNode weaponnode = data.CreateNode(XmlNodeType.Element, "WeaponFactoryContainer", "");
            var idattr = data.CreateAttribute("id");
            idattr.Value = "DATA.LockedWeapons-" + (nextSafeID + 1);
            weaponnode.Attributes.Append(idattr);

            string cleanedWeapon = "";

            //Takes the weapon template from the WeaponTemplate struct, and gets rid of the whitespaces
            if (type == WeaponType.Bazooka)
            {
                cleanedWeapon = Regex.Replace(WeaponTemplate.Bazooka, @"\s+", "");
            }else if(type == WeaponType.Grenade)
            {
                cleanedWeapon = Regex.Replace(WeaponTemplate.Grenade, @"\s+", "");
            }else if(type == WeaponType.Airstrike)
            {
                cleanedWeapon = Regex.Replace(WeaponTemplate.Airstrike, @"\s+", "");
            }

            //Replaces the Name of the weapon with an unique string resource id
            //The game later on uses this ID to get the actual name of the weapon
            cleanedWeapon = cleanedWeapon.Replace("REPLACENAMEHERE", "Text.cWeapon-" + nextSafeID);

            //Puts the "cleaned" template into the Weapon node
            weaponnode.InnerXml = cleanedWeapon;

            //And adds it afterwards to the xomObjects node
            xomObjects.AppendChild(weaponnode);

            //Creates a new WeaponFactoryContainer node which is used for the cluster
            XmlNode cluster = data.CreateNode(XmlNodeType.Element, "WeaponFactoryContainer", "");
            var clusterattr = data.CreateAttribute("id");
            clusterattr.Value = "DATA.LockedWeapons-" + (nextSafeID + 2);
            cluster.Attributes.Append(clusterattr);

            string cleanedCluster = "";

            //Takes the cluster template from the WeaponTemplate struct, and gets rid of the whitespaces
            if (type == WeaponType.Bazooka)
            {
                cleanedCluster = Regex.Replace(WeaponTemplate.BazookaCluster, @"\s+", "");
            }
            else if (type == WeaponType.Grenade)
            {
                cleanedCluster = Regex.Replace(WeaponTemplate.GrenadeCluster, @"\s+", "");
            }
            else if (type == WeaponType.Airstrike)
            {
                cleanedCluster = Regex.Replace(WeaponTemplate.AirstrikeCluster, @"\s+", "");
            }

            //Puts the "cleaned" template into the Weapon node
            cluster.InnerXml = cleanedCluster;

            //And adds it afterwards to the xomObjects node
            xomObjects.AppendChild(cluster);

            //Gets the WeaponFactoryCollective node
            XmlNode weaponCollectiveNode = data.SelectSingleNode(@"/xomArchive/xomObjects/WeaponFactoryCollective");

            //Creates a new Weapons node
            XmlNode newwep = data.CreateNode(XmlNodeType.Element, "Weapons", "");
            XmlAttribute newattr = data.CreateAttribute("href");
            newattr.Value = "DATA.LockedWeapons-" + nextSafeID;
            newwep.Attributes.Append(newattr);

            //And adds it to the Collective node
            weaponCollectiveNode.AppendChild(newwep);

            //Gets the XDataBank node, which contains the various variables and resources
            XmlNode variablesNode = data.SelectSingleNode(@"/xomArchive/xomObjects/XDataBank");

            //Creates a new StringResources node, which points at the XStringResourceDetails node that we will create afterwards
            XmlNode stringResourceNode = data.CreateNode(XmlNodeType.Element, "StringResources", "");
            XmlAttribute stringhref = data.CreateAttribute("href");
            stringhref.Value = "Text.cWeapon-" + nextSafeID;

            stringResourceNode.Attributes.Append(stringhref);

            //Adds the StringResources node
            variablesNode.AppendChild(stringResourceNode);

            //Creates a new XStringResourceDetails node that will contain the actual name of the weapon
            XmlNode stringDetailsNode = data.CreateNode(XmlNodeType.Element, "XStringResourceDetails", "");
            XmlAttribute stringdetailid = data.CreateAttribute("id");
            stringdetailid.Value = "Text.cWeapon-" + nextSafeID;

            stringDetailsNode.InnerXml = @"<Value>My Great Weapon</Value><Name>Text.cWeapon-" + nextSafeID + "</Name><Flags>64</Flags>";

            stringDetailsNode.Attributes.Append(stringdetailid);

            xomObjects.AppendChild(stringDetailsNode);

            nextSafeID += 3;

            Save();
        }
    }
}
