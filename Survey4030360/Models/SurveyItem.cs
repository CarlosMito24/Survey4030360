using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey4030360.Models
{
    public class SurveyItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string EquipoFavorito  { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Año { get; set; }
    }
}