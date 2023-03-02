using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    public enum Nyelvcsaladok { moduláris, strukturált, funkcionális, objektumorientált };

    public class Nyelv
    {
        string neve;
        bool forditosE;
        Nyelvcsaladok nyelvcsalad;
        int megjelenesEve;
        bool alacsonySzintuE;
        int nepszeruseg2022;

        public Nyelv(string neve,
                     bool forditosE,
                     Nyelvcsaladok nyelvcsalad,
                     int megjelenesEve,
                     bool alacsonySzintuE,
                     int nepszeruseg2022)
        {
            this.neve = neve;
            this.forditosE = forditosE;
            this.nyelvcsalad = nyelvcsalad;
            this.megjelenesEve = megjelenesEve;
            this.alacsonySzintuE = alacsonySzintuE;
            this.nepszeruseg2022 = nepszeruseg2022;
        }

        public string Neve { get => neve; set => neve = value; }
        public bool ForditosE { get => forditosE; set => forditosE = value; }
        public Nyelvcsaladok Nyelvcsalad { get => nyelvcsalad; set => nyelvcsalad = value; }
        public int MegjelenesEve { get => megjelenesEve; set => megjelenesEve = value; }
        public bool AlacsonySzintuE { get => alacsonySzintuE; set => alacsonySzintuE = value; }
        public int Nepszeruseg2022 { get => nepszeruseg2022; set => nepszeruseg2022 = value; }

        /// <summary>
        ///
        /// </summary>
        /// <returns>Ha a legnépszerűbb 3-ba tartozik</returns>
        public bool NepszeruE() {
            return this.nepszeruseg2022 <= 3;
        }
    }
}
