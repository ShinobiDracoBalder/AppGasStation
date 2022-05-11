using Common.GasStation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Common.GasStation.Helpers
{
    public class ReadPlaceXml
    {
        public void ReadDirectoryPlace() {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\GAS");
            FileInfo[] fileNames = directoryInfo.GetFiles("*.xml");
            for (int i = 0; i < fileNames.Length; i++) {
                var _Name = fileNames[i].Name;
                var _path = fileNames[i].FullName;

                if (_Name.Contains("places"))
                {
                    Console.WriteLine($"Read Place.xml  {_Name}");
                    Console.WriteLine($"Path Place.xml  {_path}");
                    var ListResult = ReadXmlPlaces(_path);
                }
            }
        }
        public List<Places> ReadXmlPlaces(string Path) {
            StringBuilder result = new StringBuilder();
            List<Places> Lplace = new List<Places>();
            foreach (XElement level1Element in XElement.Load(Path).Elements("place"))
            {
                result.AppendLine(level1Element.Attribute("place_id").Value);
                Console.WriteLine($"{"PermisoId        :"}{level1Element.Attribute("place_id").Value}");
                Console.WriteLine($"{"RazonSocial      :"}{level1Element.Element("name").Value}");
                Console.WriteLine($"{"NumeroPermiso    :"}{level1Element.Element("cre_id").Value}");

                Places _place = new Places
                {
                    PermisoId = level1Element.Attribute("place_id").Value,
                    RazonSocial = level1Element.Element("name").Value,
                    NumeroPermiso = level1Element.Element("cre_id").Value
                };

                foreach (XElement level2Element in level1Element.Elements("location"))
                {
                    Console.WriteLine($"{"longitude     :"}{level2Element.Element("x").Value}");
                    Console.WriteLine($"{"latitude      :"}{level2Element.Element("y").Value}");
                    _place.longitude = level2Element.Element("x").Value;
                    _place.latitude = level2Element.Element("y").Value;

                    Lplace.Add(_place);
                }
            }

            Console.WriteLine(Lplace.Count);
            //Console.WriteLine(result.ToString());
            return Lplace.OrderBy(p => p.PermisoId).ToList();
        }
    }
}
