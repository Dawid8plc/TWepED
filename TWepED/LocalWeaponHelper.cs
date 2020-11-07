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
            data.Load(path);

            weaponCollectionNode = data.SelectSingleNode(@"/xomArchive/xomObjects/WeaponFactoryCollective");

            nextSafeID = Convert.ToInt32(weaponCollectionNode.LastChild.Attributes["href"].Value.Split('-')[1]) + 3;
        }

        public void Save()
        {
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true, Encoding = new UTF8Encoding(false) };
            XmlWriter writer = XmlWriter.Create(@"D:\NewLocal.xml", settings);

            data.Save(writer);

            writer.Close();
        }

        public List<Weapon> getFriendlyWeapons()
        {
            List<Weapon> weps = new List<Weapon>();

            foreach (XmlNode item in getCustomWeapons())
            {
                XmlNode curwepnode = data.SelectSingleNode(@"/xomArchive/xomObjects//*[@id='" + item.Attributes["href"].Value + "']");

                XmlNode actualwepnode = data.SelectSingleNode(@"/xomArchive/xomObjects//*[@id='" + curwepnode.ChildNodes[1].Attributes["href"].Value + "']");

                XmlNode clustrNode = data.SelectSingleNode(@"/xomArchive/xomObjects//*[@id='" + curwepnode.ChildNodes[2].Attributes["href"].Value + "']");

                XmlNode nameNode = data.SelectSingleNode(@"/xomArchive/xomObjects/*[@id='" + actualwepnode.ChildNodes[1].InnerText + "']");

                string[] oop = item.Attributes["href"].Value.Split('-');

                XmlNode stringvarnode = data.SelectSingleNode(@"/xomArchive/xomObjects/XDataBank/*[@href='Text.cWeapon-" + oop[1] + "']");

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
            List<XmlNode> nodes = weaponCollectionNode.Cast<XmlNode>().ToList();
            return nodes.GetRange(7, nodes.Count - 7);
        }

        public void degradeElement(XmlNode node, string attribute)
        {
            string curpart = node.Attributes[attribute].Value;

            string[] a = curpart.Split('-');

            curpart = a[0];
            curpart += "-" + (Convert.ToInt32(a[1]) - 3);

            node.Attributes[attribute].Value = curpart;
        }

        public void removeWeapon(Weapon weapon, int orderID)
        {
            int thisID = Convert.ToInt32(weapon.storeNode.Attributes["id"].Value.Split('-')[1]);

            List<Weapon> nodes = getFriendlyWeapons();

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
            XmlNode idkbruh = data.SelectSingleNode(@"/xomArchive/xomObjects");


            XmlNode storewepnode = data.CreateNode(XmlNodeType.Element, "StoreWeaponFactory", "");
            storewepnode.InnerXml = @"<StockWeapon>true</StockWeapon><Weapon href='DATA.LockedWeapons-" + (nextSafeID + 1) + "'/><Cluster href='DATA.LockedWeapons-" + (nextSafeID + 2) + "'/>";

            XmlAttribute storeattr = data.CreateAttribute("id");
            storeattr.Value = "DATA.LockedWeapons-" + nextSafeID;
            storewepnode.Attributes.Append(storeattr);

            idkbruh.AppendChild(storewepnode);



            XmlNode bruh = data.CreateNode(XmlNodeType.Element, "WeaponFactoryContainer", "");
            var idattr = data.CreateAttribute("id");
            idattr.Value = "DATA.LockedWeapons-" + (nextSafeID + 1);
            bruh.Attributes.Append(idattr);

            string cleanedWeapon = "";

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

            cleanedWeapon = cleanedWeapon.Replace("REPLACENAMEHERE", "Text.cWeapon-" + nextSafeID);

            bruh.InnerXml = cleanedWeapon;

            idkbruh.AppendChild(bruh);

            XmlNode cluster = data.CreateNode(XmlNodeType.Element, "WeaponFactoryContainer", "");
            var clusterattr = data.CreateAttribute("id");
            clusterattr.Value = "DATA.LockedWeapons-" + (nextSafeID + 2);
            cluster.Attributes.Append(clusterattr);

            string cleanedCluster = "";

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

            cluster.InnerXml = cleanedCluster;

            idkbruh.AppendChild(cluster);

            //stage 2 add to wep collection
            XmlNode wepnode = data.SelectSingleNode(@"/xomArchive/xomObjects/WeaponFactoryCollective");

            XmlNode newwep = data.CreateNode(XmlNodeType.Element, "Weapons", "");
            XmlAttribute newattr = data.CreateAttribute("href");
            newattr.Value = "DATA.LockedWeapons-" + nextSafeID;
            newwep.Attributes.Append(newattr);

            wepnode.AppendChild(newwep);




            XmlNode variablesNode = data.SelectSingleNode(@"/xomArchive/xomObjects/XDataBank");

            XmlNode stringResourceNode = data.CreateNode(XmlNodeType.Element, "StringResources", "");
            XmlAttribute stringhref = data.CreateAttribute("href");
            stringhref.Value = "Text.cWeapon-" + nextSafeID;

            stringResourceNode.Attributes.Append(stringhref);

            variablesNode.AppendChild(stringResourceNode);


            XmlNode variableDetailsNode = data.SelectSingleNode(@"/xomArchive/xomObjects");

            XmlNode stringDetailsNode = data.CreateNode(XmlNodeType.Element, "XStringResourceDetails", "");
            XmlAttribute stringdetailid = data.CreateAttribute("id");
            stringdetailid.Value = "Text.cWeapon-" + nextSafeID;

            stringDetailsNode.InnerXml = @"<Value>My Great Weapon</Value><Name>Text.cWeapon-" + nextSafeID + "</Name><Flags>64</Flags>";

            stringDetailsNode.Attributes.Append(stringdetailid);

            variableDetailsNode.AppendChild(stringDetailsNode);

            nextSafeID += 3;

            Save();
        }
    }
}
