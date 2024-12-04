using System;

namespace KantinaWeb.Models
{   
    public class Matvarer
    {
        public int Mat_id { get; set; }
        public string Mat_vare { get; set; }
        public string Mat_desk { get; set; }
        public decimal Mat_pris { get; set; }

        public Matvarer(int mat_id, string mat_vare, string mat_desk, decimal mat_pris)
        {
            Mat_id = mat_id;
            Mat_vare = mat_vare;
            Mat_desk = mat_desk;
            Mat_pris = mat_pris;
        }
    }

    public class Drikkevarer
    {
        public int Drikke_id { get; set; }
        public string Drikke_vare { get; set; }
        public string Drikke_desk { get; set ;}
        public decimal Drikke_pris { get; set; }

        public Drikkevarer(int drikke_id, string drikke_vare, string drikke_desk, decimal drikke_pris)
        {
          Drikke_id = drikke_id;
          Drikke_vare = drikke_vare;
          Drikke_desk = drikke_desk;
          Drikke_pris = drikke_pris;
        }
    }
}