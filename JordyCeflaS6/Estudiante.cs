using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JordyCeflaS6
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)] 
        public string nombre { get; set; }

        [MaxLength(50)]
        public string usuario { get; set; }

        [MaxLength(50)]
        public string contrasena { get; set;}

        
        

    }
}
