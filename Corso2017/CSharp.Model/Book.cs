using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Model
{
    /// <summary>
    /// Definisce un libro
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Apre il libro
        /// </summary>
        /// <returns>True se l'apertura è andata bene. False altrimenti</returns>
        public static bool Open()
        {
            return true;
        }

        /// <summary>
        /// Chiude il libro
        /// </summary>
        /// <returns>True se la chiusura è andata bene. False altrimenti</returns>
        public static bool Close()
        {
            Library.Store("questo libro");

            return true;
        }
    }
}
