using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PS2JsonAPI
{
    class Program
    {
        public static class PS2JSONPaths
        {
            public static string CharacterID
            {
                get { return "character_list[0].character_id"; }
            
            }
            public static string CharacterName
            {
                get {return "character_list[0].name.first"; }
            }
            public static string CharacterCreationDate
            {
                get { return "character_list[0].times.creation_date"; }
            }
        }
        public class PS2CharacterData
        {
            public Int64 ID;
            public string Name;
            public DateTime CreationDate;
            public PS2CharacterData(string inJson)
            {
                JObject o = JObject.Parse(inJson);
                //JToken TempToken = o.GetValue("character_id");
                //JToken TheActualCharacter = o.GetValue("character_list");
                //JToken TempToken = TheActualCharacter.SelectToken("")

                this.ID = (Int64)o.SelectToken(PS2JSONPaths.CharacterID);
                this.Name = (string)o.SelectToken(PS2JSONPaths.CharacterName);
                this.CreationDate = (DateTime)o.SelectToken(PS2JSONPaths.CharacterCreationDate);
                
            }

        }

        static void Main(string[] args)
        {
            StreamReader TempReader = new StreamReader(@"C:\APS\weapon_stat_by_Faction.json");
            string PSWSBF = TempReader.ReadToEnd();
            PS2CharacterData PS2Char = new PS2CharacterData(PSWSBF);
        }
    }
}
