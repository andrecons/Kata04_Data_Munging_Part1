using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata04_Data_Munging_Part1.Objects
{
    public class Row
    {
        private int id { get; set; }
        private decimal firstColumn { get; set; }
        private decimal secondColumn { get; set; }

        public Row() { }

        public Row(int inputId, decimal inputFirstColumn, decimal inputSecondColumn)
        {
            this.id = inputId;
            this.firstColumn = inputFirstColumn;
            this.secondColumn = inputSecondColumn;
        }

        public decimal GetSpread()
        {
            return firstColumn - secondColumn;
        }

        public int GetId()
        { return id; }
        public decimal GetFirstColumn()
        { return firstColumn; }
        public decimal GetSecondColumn()
        { return secondColumn; }

        public void SettId(int inputId)
        { id = inputId; }
        public void SetFirstColumn(int inputFirstColumn)
        { firstColumn = inputFirstColumn; }
        public void SetSecondColumn(int inputSecondColumn)
        { secondColumn = inputSecondColumn; }

        public string ToString()
        {
            return "id: " + id + ";" + " firstColumn: " + firstColumn + ";" + "secondColumn: " + secondColumn;
        }
    }
}
